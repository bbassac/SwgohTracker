// Decompiled with JetBrains decompiler
// Type: Ipd.Core.Services.EnvTagsProvider
// Assembly: Ipd.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 10FD981A-2B33-4DE6-8525-B5BDF64E7AF8
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.Core.dll

using Ipd.Core.Extensions;
using Ipd.Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ipd.Core.Services
{
  public class EnvTagsProvider : ITagsProvider
  {
    private readonly ILog _logger;
    public const string TAGS_ENV_NAME = "DISCORD_TAGS";

    public EnvTagsProvider(ILog logger) => this._logger = logger;

    public Task<Dictionary<string, string>> GetTagsAsync()
    {
      try
      {
        List<string> stringList = new List<string>();
        foreach (DictionaryEntry environmentVariable in Environment.GetEnvironmentVariables())
        {
          if (environmentVariable.Key.ToString().StartsWith("DISCORD_TAGS"))
          {
            string str = environmentVariable.Value.ToString().Trim();
            if (!string.IsNullOrEmpty(str))
              stringList.AddRange((IEnumerable<string>) str.Split(','));
          }
        }
        Dictionary<string, string> result = new Dictionary<string, string>();
        stringList.ForEach((Action<string>) (t =>
        {
          string[] strArray = t.Trim().Split('|');
          if (strArray.Length != 2)
          {
            this._logger.Log("Invalid tag format in " + t);
          }
          else
          {
            string str = strArray[0].NormalizeAllyCode();
            long allycode = 0;
            if (!long.TryParse(str, out allycode) || str.Length != 9)
              this._logger.Log("Error: ally code `" + strArray[0] + "` should consist of 9 digits.");
         
          }
        }));
        return Task.FromResult<Dictionary<string, string>>(result);
      }
      catch (Exception ex)
      {
        this._logger.Log("Failed to process `TAGS_ENV_NAME` environment variable");
      }
      return Task.FromResult<Dictionary<string, string>>(new Dictionary<string, string>());
    }
  }
}
