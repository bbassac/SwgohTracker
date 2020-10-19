// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.AuthGuestRequest
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class AuthGuestRequest : IMessage<AuthGuestRequest>, IMessage, IEquatable<AuthGuestRequest>, IDeepCloneable<AuthGuestRequest>
  {
    private static readonly MessageParser<AuthGuestRequest> _parser = new MessageParser<AuthGuestRequest>((Func<AuthGuestRequest>) (() => new AuthGuestRequest()));
    private UnknownFieldSet _unknownFields;
    public const int UidFieldNumber = 1;
    private string uid_ = "";
    public const int DevicePlatformFieldNumber = 2;
    private string devicePlatform_ = "";
    public const int LanguageFieldNumber = 3;
    private string language_ = "";
    public const int PlayerNameFieldNumber = 4;
    private string playerName_ = "";
    public const int BundleIdFieldNumber = 5;
    private string bundleId_ = "";
    public const int RegionFieldNumber = 6;
    private string region_ = "";
    public const int LocalTimeZoneOffsetMinutesFieldNumber = 7;
    private int localTimeZoneOffsetMinutes_;
    public const int SessionStartContextFieldNumber = 8;
    private SessionStartContext sessionStartContext_;
    public const int DevicePreferencesFieldNumber = 9;
    private DevicePreferences devicePreferences_;

    [DebuggerNonUserCode]
    public static MessageParser<AuthGuestRequest> Parser => AuthGuestRequest._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => AuthGuestRequestReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.pb\u003A\u003AGoogle\u002EProtobuf\u002EIMessage\u002EDescriptor => AuthGuestRequest.Descriptor;

    [DebuggerNonUserCode]
    public AuthGuestRequest()
    {
    }

    [DebuggerNonUserCode]
    public AuthGuestRequest(AuthGuestRequest other)
      : this()
    {
      this.uid_ = other.uid_;
      this.devicePlatform_ = other.devicePlatform_;
      this.language_ = other.language_;
      this.playerName_ = other.playerName_;
      this.bundleId_ = other.bundleId_;
      this.region_ = other.region_;
      this.localTimeZoneOffsetMinutes_ = other.localTimeZoneOffsetMinutes_;
      this.sessionStartContext_ = other.sessionStartContext_;
      this.DevicePreferences = other.devicePreferences_ != null ? other.DevicePreferences.Clone() : (DevicePreferences) null;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public AuthGuestRequest Clone() => new AuthGuestRequest(this);

    [DebuggerNonUserCode]
    public string Uid
    {
      get => this.uid_;
      set => this.uid_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string DevicePlatform
    {
      get => this.devicePlatform_;
      set => this.devicePlatform_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Language
    {
      get => this.language_;
      set => this.language_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string PlayerName
    {
      get => this.playerName_;
      set => this.playerName_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string BundleId
    {
      get => this.bundleId_;
      set => this.bundleId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Region
    {
      get => this.region_;
      set => this.region_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int LocalTimeZoneOffsetMinutes
    {
      get => this.localTimeZoneOffsetMinutes_;
      set => this.localTimeZoneOffsetMinutes_ = value;
    }

    [DebuggerNonUserCode]
    public SessionStartContext SessionStartContext
    {
      get => this.sessionStartContext_;
      set => this.sessionStartContext_ = value;
    }

    [DebuggerNonUserCode]
    public DevicePreferences DevicePreferences
    {
      get => this.devicePreferences_;
      set => this.devicePreferences_ = value;
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as AuthGuestRequest);

    [DebuggerNonUserCode]
    public bool Equals(AuthGuestRequest other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.Uid != other.Uid) && !(this.DevicePlatform != other.DevicePlatform) && (!(this.Language != other.Language) && !(this.PlayerName != other.PlayerName)) && (!(this.BundleId != other.BundleId) && !(this.Region != other.Region) && (this.LocalTimeZoneOffsetMinutes == other.LocalTimeZoneOffsetMinutes && this.SessionStartContext == other.SessionStartContext)) && object.Equals((object) this.DevicePreferences, (object) other.DevicePreferences) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.Uid.Length != 0)
        num ^= this.Uid.GetHashCode();
      if (this.DevicePlatform.Length != 0)
        num ^= this.DevicePlatform.GetHashCode();
      if (this.Language.Length != 0)
        num ^= this.Language.GetHashCode();
      if (this.PlayerName.Length != 0)
        num ^= this.PlayerName.GetHashCode();
      if (this.BundleId.Length != 0)
        num ^= this.BundleId.GetHashCode();
      if (this.Region.Length != 0)
        num ^= this.Region.GetHashCode();
      if (this.LocalTimeZoneOffsetMinutes != 0)
        num ^= this.LocalTimeZoneOffsetMinutes.GetHashCode();
      if (this.SessionStartContext != SessionStartContext.Pushnote)
        num ^= this.SessionStartContext.GetHashCode();
      if (this.devicePreferences_ != null)
        num ^= this.DevicePreferences.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.Uid.Length != 0)
      {
        output.WriteRawTag((byte) 10);
        output.WriteString(this.Uid);
      }
      if (this.DevicePlatform.Length != 0)
      {
        output.WriteRawTag((byte) 18);
        output.WriteString(this.DevicePlatform);
      }
      if (this.Language.Length != 0)
      {
        output.WriteRawTag((byte) 26);
        output.WriteString(this.Language);
      }
      if (this.PlayerName.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteString(this.PlayerName);
      }
      if (this.BundleId.Length != 0)
      {
        output.WriteRawTag((byte) 42);
        output.WriteString(this.BundleId);
      }
      if (this.Region.Length != 0)
      {
        output.WriteRawTag((byte) 50);
        output.WriteString(this.Region);
      }
      if (this.LocalTimeZoneOffsetMinutes != 0)
      {
        output.WriteRawTag((byte) 56);
        output.WriteSInt32(this.LocalTimeZoneOffsetMinutes);
      }
      if (this.SessionStartContext != SessionStartContext.Pushnote)
      {
        output.WriteRawTag((byte) 64);
        output.WriteEnum((int) this.SessionStartContext);
      }
      if (this.devicePreferences_ != null)
      {
        output.WriteRawTag((byte) 74);
        output.WriteMessage((IMessage) this.DevicePreferences);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.Uid.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.Uid);
      if (this.DevicePlatform.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.DevicePlatform);
      if (this.Language.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.Language);
      if (this.PlayerName.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.PlayerName);
      if (this.BundleId.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.BundleId);
      if (this.Region.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.Region);
      if (this.LocalTimeZoneOffsetMinutes != 0)
        num += 1 + CodedOutputStream.ComputeSInt32Size(this.LocalTimeZoneOffsetMinutes);
      if (this.SessionStartContext != SessionStartContext.Pushnote)
        num += 1 + CodedOutputStream.ComputeEnumSize((int) this.SessionStartContext);
      if (this.devicePreferences_ != null)
        num += 1 + CodedOutputStream.ComputeMessageSize((IMessage) this.DevicePreferences);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(AuthGuestRequest other)
    {
      if (other == null)
        return;
      if (other.Uid.Length != 0)
        this.Uid = other.Uid;
      if (other.DevicePlatform.Length != 0)
        this.DevicePlatform = other.DevicePlatform;
      if (other.Language.Length != 0)
        this.Language = other.Language;
      if (other.PlayerName.Length != 0)
        this.PlayerName = other.PlayerName;
      if (other.BundleId.Length != 0)
        this.BundleId = other.BundleId;
      if (other.Region.Length != 0)
        this.Region = other.Region;
      if (other.LocalTimeZoneOffsetMinutes != 0)
        this.LocalTimeZoneOffsetMinutes = other.LocalTimeZoneOffsetMinutes;
      if (other.SessionStartContext != SessionStartContext.Pushnote)
        this.SessionStartContext = other.SessionStartContext;
      if (other.devicePreferences_ != null)
      {
        if (this.devicePreferences_ == null)
          this.devicePreferences_ = new DevicePreferences();
        this.DevicePreferences.MergeFrom(other.DevicePreferences);
      }
      this._unknownFields = UnknownFieldSet.MergeFrom(this._unknownFields, other._unknownFields);
    }

    [DebuggerNonUserCode]
    public void MergeFrom(CodedInputStream input)
    {
      uint num;
      while ((num = input.ReadTag()) != 0U)
      {
        switch (num)
        {
          case 10:
            this.Uid = input.ReadString();
            continue;
          case 18:
            this.DevicePlatform = input.ReadString();
            continue;
          case 26:
            this.Language = input.ReadString();
            continue;
          case 34:
            this.PlayerName = input.ReadString();
            continue;
          case 42:
            this.BundleId = input.ReadString();
            continue;
          case 50:
            this.Region = input.ReadString();
            continue;
          case 56:
            this.LocalTimeZoneOffsetMinutes = input.ReadSInt32();
            continue;
          case 64:
            this.sessionStartContext_ = (SessionStartContext) input.ReadEnum();
            continue;
          case 74:
            if (this.devicePreferences_ == null)
              this.devicePreferences_ = new DevicePreferences();
            input.ReadMessage((IMessage) this.devicePreferences_);
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
