// Decompiled with JetBrains decompiler
// Type: Ipd.GameClient.GameClient
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

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
    public string GameClientVersion { get; set; }

    public AuthGuestResponse GetGuestAuth() => AuthGuestResponse.Parser.ParseFrom(ResponseEnvelope.Parser.ParseFrom(this.BasicPostRequest(this.GetRequestEnvelope("AuthRpc", "DoAuthGuest", this.GetAuthGuestRequest())).GetResponseStream().ToByteArray()).Payload.ToByteArray().Unzip());

    public PlayerArena GetPlayerArenaRanks(string playerAllyCode, AuthGuestResponse auth)
    {
      ResponseEnvelope from1 = ResponseEnvelope.Parser.ParseFrom(this.BasicPostRequest(this.GetRequestEnvelope("PlayerRpc", "GetPlayerProfile", new PlayerProfileRequest()
      {
        PlayerId = "",
        AllyCode = playerAllyCode.Replace("-", "").Trim()
      }.ToByteString(), auth.AuthId, auth.AuthToken)).GetResponseStream().ToByteArray());
      if (from1.Code != ResponseCode.Ok)
        throw new GameClientApiException(string.Format("errorCode:{0}, allyCode:{1}, authId:{2}, token:{3}, {4}", (object) from1.Code, (object) playerAllyCode, (object) auth.AuthId, (object) auth.AuthToken, (object) from1.Message))
        {
          ErrorCode = from1.Code
        };
      PlayerProfileResponse from2 = PlayerProfileResponse.Parser.ParseFrom(from1.Payload.ToByteArray().Unzip());
      int place1 = from2.ArenaStatuses.First<PlayerArenaStatus>((Func<PlayerArenaStatus, bool>) (a => a.ArenaType == PlayerArenaType.SquadArena)).Place;
      int place2 = from2.ArenaStatuses.First<PlayerArenaStatus>((Func<PlayerArenaStatus, bool>) (a => a.ArenaType == PlayerArenaType.FleetArena)).Place;
      return new PlayerArena()
      {
        PlayerName = from2.Name,
        SquadArenaRank = place1,
        FleetArenaRank = place2
      };
    }

    private ByteString GetAuthGuestRequest()
    {
      AuthGuestRequest message = new AuthGuestRequest();
      message.Uid = this.GenerateRandomUid();
      message.Language = "en";
      message.BundleId = "com.ea.game.starwarscapital_row";
      message.Region = "NA";
      message.LocalTimeZoneOffsetMinutes = 960;
      byte[] array;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        message.WriteTo((Stream) memoryStream);
        array = memoryStream.ToArray();
      }
      return ByteString.CopyFrom(array);
    }

    private string GenerateRandomUid() => Guid.NewGuid().ToString().ToLower().Replace("-", "").Substring(0, 32);

    private byte[] GetRequestEnvelope(
      string serviceName,
      string requestMethod,
      ByteString payload,
      string auhtId = null,
      string authToken = null)
    {
      RequestEnvelope message = new RequestEnvelope();
      if (payload != (ByteString) null)
        message.Payload = payload;
      if (!string.IsNullOrEmpty(auhtId) && !string.IsNullOrEmpty(authToken))
      {
        message.AuthId = auhtId;
        message.AuthToken = authToken;
      }
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
      httpWebRequest.Headers.Add("Content-Type", "application/x-protobuf");
      httpWebRequest.Headers.Add("Connection", "Keep-Alive");
      httpWebRequest.Headers.Add("Accept-Encoding", "gzip");
      httpWebRequest.Headers.Add("Accept-Type", "application/x-protobuf");
      httpWebRequest.ContentLength = (long) body.Length;
      using (Stream requestStream = httpWebRequest.GetRequestStream())
        requestStream.Write(body, 0, body.Length);
      return (HttpWebResponse) httpWebRequest.GetResponse();
    }
  }
}
