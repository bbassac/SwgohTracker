// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.DiscordMessenger
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 69A9BA34-EFF0-4B1E-91D5-6250FF6FB6E4
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.Core.dll

using Ipd.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class DiscordMessenger : IDiscordMessenger
  {
    public string DiscordWebHook { get; private set; }

    public DiscordMessenger(string webHook) => this.DiscordWebHook = webHook;

    private async Task SendMessage(string textMessage)
    {
      var data = new{ content = textMessage };
      using (HttpClient httpClient = new HttpClient())
      {
        using (StringContent content = new StringContent(JsonConvert.SerializeObject((object) data), Encoding.UTF8, "application/json"))
        {
          HttpResponseMessage httpResponseMessage = await Policy.HandleResult<HttpResponseMessage>((Func<HttpResponseMessage, bool>) (r => !r.IsSuccessStatusCode)).RetryAsync<HttpResponseMessage>(3, (Func<DelegateResult<HttpResponseMessage>, int, Context, Task>) (async (result, retryCount, context) =>
          {
            if (result.Result.StatusCode != HttpStatusCode.TooManyRequests)
              return;
            DiscrodRateLimitResponse rateLimitResponse = JsonConvert.DeserializeObject<DiscrodRateLimitResponse>(await result.Result.Content.ReadAsStringAsync(), new JsonSerializerSettings()
            {
              ContractResolver = (IContractResolver) new DefaultContractResolver()
              {
                NamingStrategy = (NamingStrategy) new SnakeCaseNamingStrategy()
              }
            });
            if (rateLimitResponse.RetryAfter != 0)
            {
              TimeSpan delay = TimeSpan.FromMilliseconds((double) rateLimitResponse.RetryAfter);
              if (retryCount >= 2)
                Console.WriteLine(string.Format("[DiscordMessenger]:Request failed with StatusCode({0}). Waiting {1} before next retry. Retry attempt {2}", (object) result.Result.StatusCode, (object) delay, (object) retryCount));
              await Task.Delay(delay);
            }
            else
            {
              TimeSpan delay = TimeSpan.FromMilliseconds(1000.0);
              if (retryCount >= 2)
                Console.WriteLine(string.Format("[DiscordMessenger]:Request failed with StatusCode({0}). Waiting {1} before next retry. Retry attempt {2}", (object) result.Result.StatusCode, (object) delay, (object) retryCount));
              await Task.Delay(delay);
            }
          })).ExecuteAsync((Func<Task<HttpResponseMessage>>) (() => httpClient.PostAsync(this.DiscordWebHook, (HttpContent) content)));
          if (httpResponseMessage.IsSuccessStatusCode)
            ;
          else
            Console.WriteLine(string.Format("[DiscordMessenger]:Request failed with StatusCode({0}).", (object) httpResponseMessage.StatusCode));
        }
      }
    }

    public async Task SendTextMessage(string textMessage)
    {
      try
      {
        await this.SendMessage(textMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine("[DiscordMessenger]:Request failed with Exception:[" + ex.Message + "].");
      }
    }

    public async Task SendTextTaggedMessage(string userDiscordId, string textMessage)
    {
      try
      {
        await this.SendMessage("<@" + userDiscordId + ">" + textMessage);
      }
      catch (Exception ex)
      {
        Console.WriteLine("[DiscordMessenger]:Request failed with Exception:[" + ex.Message + "].");
      }
    }
  }
}
