// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.GameClient
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Ipd.Game.Protocol;
using Ipd.GameClient.Exeptions;
using Ipd.GameClient.Extensions;
using Ipd.GameClient.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;

namespace Ipd.GameClient
{
  public class GameClient : IGameClient
  {
    private readonly string _appVersion;

    public string GameClientVersion { get; set; }

    public GameClient(string appVrsion) => this._appVersion = appVrsion;

    public PlayerArena GetSlimPlayerArenaRanks(string playerAllyCode)
    {
      ResponseEnvelope from1 = ResponseEnvelope.Parser.ParseFrom(this.BasicPostRequest(this.GetRequestEnvelope("PlayerRpc", "GetPlayerArenaProfile", new PlayerProfileRequest()
      {
        PlayerId = "",
        AllyCode = playerAllyCode.Replace("-", "").Trim()
      }.ToByteString())).GetResponseStream().ToByteArray());
      if (from1.Code != ResponseCode.Ok)
        throw new GameClientApiException(string.Format("errorCode:{0}, allyCode:{1}, {2}", (object) from1.Code, (object) playerAllyCode, (object) from1.Message))
        {
          ErrorCode = from1.Code
        };
      SlimPlayerArenaProfileResponse from2 = SlimPlayerArenaProfileResponse.Parser.ParseFrom(from1.Payload.ToByteArray().Unzip());
      int num1 = -1;
      PlayerPvpProfile playerPvpProfile1 = from2.PvpProfile.FirstOrDefault<PlayerPvpProfile>((Func<PlayerPvpProfile, bool>) (a => a.Tab == PlayerProfileTab.Profilepvpcharacter));
      if (playerPvpProfile1 != null)
        num1 = playerPvpProfile1.Rank;
      int num2 = -1;
      PlayerPvpProfile playerPvpProfile2 = from2.PvpProfile.FirstOrDefault<PlayerPvpProfile>((Func<PlayerPvpProfile, bool>) (a => a.Tab == PlayerProfileTab.Profilepvpship));
      if (playerPvpProfile2 != null)
        num2 = playerPvpProfile2.Rank;
      return new PlayerArena()
      {
        PlayerName = from2.Name,
        SquadArenaRank = num1,
        FleetArenaRank = num2,
        PayoutOffsetMinutes = from2.LocalTimeZoneOffsetMinutes
      };
    }

    private byte[] GetRequestEnvelope(string serviceName, string requestMethod, ByteString payload)
    {
      RequestEnvelope message = new RequestEnvelope();
      if (payload != (ByteString) null)
        message.Payload = payload;
      message.CorrelationId = 0;
      message.ServiceName = serviceName;
      message.MethodName = requestMethod;
      message.ClientVersion = 181815;
      long num = (long) (Math.Floor((double) DateTime.Now.Ticks / 1000.0) - 10.0);
      message.ClientStartupTimestamp = num;
      message.Platform = "Android";
      message.Region = "NA";
      message.ClientExternalVersion = this.GameClientVersion ?? "99.99.99";
      message.ClientInternalVersion = this.GameClientVersion ?? "99.99.99";
      message.RequestId = Guid.NewGuid().ToString().ToLower();
      message.AcceptEncoding = AcceptEncoding.Gzipacceptencoding;
      message.CurrentClientTime = num + 8L;
      message.NetworkAccess = "W";
      message.Application = this._appVersion ?? "";
      using (MemoryStream memoryStream = new MemoryStream())
      {
        message.WriteTo((Stream) memoryStream);
        return memoryStream.ToArray();
      }
    }

    private HttpWebResponse BasicPostRequest(byte[] body)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create("https://swprod.capitalgames.com/rpc");
      httpWebRequest.Method = "POST";
      httpWebRequest.Headers.Add("Connection", "Keep-Alive");
      httpWebRequest.Headers.Add("Accept-Encoding", "gzip");
      httpWebRequest.Headers.Add("Accept-Type", "application/x-protobuf");
      httpWebRequest.ContentType = "application/x-protobuf";
      httpWebRequest.ContentLength = (long) body.Length;
      using (Stream requestStream = httpWebRequest.GetRequestStream())
        requestStream.Write(body, 0, body.Length);
      return (HttpWebResponse) httpWebRequest.GetResponse();
    }
  }
}
