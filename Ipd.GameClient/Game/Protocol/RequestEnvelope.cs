// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.RequestEnvelope
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class RequestEnvelope : IMessage<RequestEnvelope>, IMessage, IEquatable<RequestEnvelope>, IDeepCloneable<RequestEnvelope>
  {
    private static readonly MessageParser<RequestEnvelope> _parser = new MessageParser<RequestEnvelope>((Func<RequestEnvelope>) (() => new RequestEnvelope()));
    private UnknownFieldSet _unknownFields;
    public const int CorrelationIdFieldNumber = 1;
    private int correlationId_;
    public const int ServiceNameFieldNumber = 4;
    private string serviceName_ = "";
    public const int MethodNameFieldNumber = 5;
    private string methodName_ = "";
    public const int PayloadFieldNumber = 6;
    private ByteString payload_ = ByteString.Empty;
    public const int AuthIdFieldNumber = 7;
    private string authId_ = "";
    public const int AuthTokenFieldNumber = 8;
    private string authToken_ = "";
    public const int ClientVersionFieldNumber = 9;
    private int clientVersion_;
    public const int ClientStartupTimestampFieldNumber = 11;
    private long clientStartupTimestamp_;
    public const int PlatformFieldNumber = 12;
    private string platform_ = "";
    public const int RegionFieldNumber = 13;
    private string region_ = "";
    public const int ClientExternalVersionFieldNumber = 14;
    private string clientExternalVersion_ = "";
    public const int ClientInternalVersionFieldNumber = 15;
    private string clientInternalVersion_ = "";
    public const int RequestIdFieldNumber = 16;
    private string requestId_ = "";
    public const int AcceptEncodingFieldNumber = 17;
    private AcceptEncoding acceptEncoding_;
    public const int FlagFieldNumber = 18;
    private static readonly FieldCodec<string> _repeated_flag_codec = FieldCodec.ForString(146U);
    private readonly RepeatedField<string> flag_ = new RepeatedField<string>();
    public const int TelemetryEventFieldNumber = 19;
    private static readonly FieldCodec<string> _repeated_telemetryEvent_codec = FieldCodec.ForString(154U);
    private readonly RepeatedField<string> telemetryEvent_ = new RepeatedField<string>();
    public const int CurrentClientTimeFieldNumber = 20;
    private long currentClientTime_;
    public const int NimbleSessionIdFieldNumber = 21;
    private string nimbleSessionId_ = "";
    public const int TimezoneFieldNumber = 22;
    private string timezone_ = "";
    public const int FirmwareVersionFieldNumber = 23;
    private string firmwareVersion_ = "";
    public const int CarrierFieldNumber = 24;
    private string carrier_ = "";
    public const int NetworkAccessFieldNumber = 25;
    private string networkAccess_ = "";
    public const int HardwareIdFieldNumber = 26;
    private string hardwareId_ = "";
    public const int AdvertiserIdFieldNumber = 27;
    private string advertiserId_ = "";
    public const int VendorIdFieldNumber = 28;
    private string vendorId_ = "";
    public const int AndroidIdFieldNumber = 29;
    private string androidId_ = "";
    public const int JailbrokenFlagFieldNumber = 30;
    private int jailbrokenFlag_;
    public const int PiracyFlagFieldNumber = 31;
    private int piracyFlag_;
    public const int SynergyIdFieldNumber = 32;
    private string synergyId_ = "";
    public const int DeviceModelFieldNumber = 33;
    private string deviceModel_ = "";
    public const int DeviceIdFieldNumber = 34;
    private string deviceId_ = "";
    public const int ApplicationFieldNumber = 37;
    private string application_ = "";

    [DebuggerNonUserCode]
    public static MessageParser<RequestEnvelope> Parser => RequestEnvelope._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => RequestEnvelopeReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor Google.Protobuf.IMessage.Descriptor => RequestEnvelope.Descriptor;

    [DebuggerNonUserCode]
    public RequestEnvelope()
    {
    }

    [DebuggerNonUserCode]
    public RequestEnvelope(RequestEnvelope other)
      : this()
    {
      this.correlationId_ = other.correlationId_;
      this.serviceName_ = other.serviceName_;
      this.methodName_ = other.methodName_;
      this.payload_ = other.payload_;
      this.authId_ = other.authId_;
      this.authToken_ = other.authToken_;
      this.clientVersion_ = other.clientVersion_;
      this.clientStartupTimestamp_ = other.clientStartupTimestamp_;
      this.platform_ = other.platform_;
      this.region_ = other.region_;
      this.clientExternalVersion_ = other.clientExternalVersion_;
      this.clientInternalVersion_ = other.clientInternalVersion_;
      this.requestId_ = other.requestId_;
      this.acceptEncoding_ = other.acceptEncoding_;
      this.flag_ = other.flag_.Clone();
      this.telemetryEvent_ = other.telemetryEvent_.Clone();
      this.currentClientTime_ = other.currentClientTime_;
      this.nimbleSessionId_ = other.nimbleSessionId_;
      this.timezone_ = other.timezone_;
      this.firmwareVersion_ = other.firmwareVersion_;
      this.carrier_ = other.carrier_;
      this.networkAccess_ = other.networkAccess_;
      this.hardwareId_ = other.hardwareId_;
      this.advertiserId_ = other.advertiserId_;
      this.vendorId_ = other.vendorId_;
      this.androidId_ = other.androidId_;
      this.jailbrokenFlag_ = other.jailbrokenFlag_;
      this.piracyFlag_ = other.piracyFlag_;
      this.synergyId_ = other.synergyId_;
      this.deviceModel_ = other.deviceModel_;
      this.deviceId_ = other.deviceId_;
      this.application_ = other.application_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public RequestEnvelope Clone() => new RequestEnvelope(this);

    [DebuggerNonUserCode]
    public int CorrelationId
    {
      get => this.correlationId_;
      set => this.correlationId_ = value;
    }

    [DebuggerNonUserCode]
    public string ServiceName
    {
      get => this.serviceName_;
      set => this.serviceName_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string MethodName
    {
      get => this.methodName_;
      set => this.methodName_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public ByteString Payload
    {
      get => this.payload_;
      set => this.payload_ = ProtoPreconditions.CheckNotNull<ByteString>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string AuthId
    {
      get => this.authId_;
      set => this.authId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string AuthToken
    {
      get => this.authToken_;
      set => this.authToken_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int ClientVersion
    {
      get => this.clientVersion_;
      set => this.clientVersion_ = value;
    }

    [DebuggerNonUserCode]
    public long ClientStartupTimestamp
    {
      get => this.clientStartupTimestamp_;
      set => this.clientStartupTimestamp_ = value;
    }

    [DebuggerNonUserCode]
    public string Platform
    {
      get => this.platform_;
      set => this.platform_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Region
    {
      get => this.region_;
      set => this.region_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string ClientExternalVersion
    {
      get => this.clientExternalVersion_;
      set => this.clientExternalVersion_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string ClientInternalVersion
    {
      get => this.clientInternalVersion_;
      set => this.clientInternalVersion_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string RequestId
    {
      get => this.requestId_;
      set => this.requestId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public AcceptEncoding AcceptEncoding
    {
      get => this.acceptEncoding_;
      set => this.acceptEncoding_ = value;
    }

    [DebuggerNonUserCode]
    public RepeatedField<string> Flag => this.flag_;

    [DebuggerNonUserCode]
    public RepeatedField<string> TelemetryEvent => this.telemetryEvent_;

    [DebuggerNonUserCode]
    public long CurrentClientTime
    {
      get => this.currentClientTime_;
      set => this.currentClientTime_ = value;
    }

    [DebuggerNonUserCode]
    public string NimbleSessionId
    {
      get => this.nimbleSessionId_;
      set => this.nimbleSessionId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Timezone
    {
      get => this.timezone_;
      set => this.timezone_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string FirmwareVersion
    {
      get => this.firmwareVersion_;
      set => this.firmwareVersion_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Carrier
    {
      get => this.carrier_;
      set => this.carrier_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string NetworkAccess
    {
      get => this.networkAccess_;
      set => this.networkAccess_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string HardwareId
    {
      get => this.hardwareId_;
      set => this.hardwareId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string AdvertiserId
    {
      get => this.advertiserId_;
      set => this.advertiserId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string VendorId
    {
      get => this.vendorId_;
      set => this.vendorId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string AndroidId
    {
      get => this.androidId_;
      set => this.androidId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int JailbrokenFlag
    {
      get => this.jailbrokenFlag_;
      set => this.jailbrokenFlag_ = value;
    }

    [DebuggerNonUserCode]
    public int PiracyFlag
    {
      get => this.piracyFlag_;
      set => this.piracyFlag_ = value;
    }

    [DebuggerNonUserCode]
    public string SynergyId
    {
      get => this.synergyId_;
      set => this.synergyId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string DeviceModel
    {
      get => this.deviceModel_;
      set => this.deviceModel_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string DeviceId
    {
      get => this.deviceId_;
      set => this.deviceId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Application
    {
      get => this.application_;
      set => this.application_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as RequestEnvelope);

    [DebuggerNonUserCode]
    public bool Equals(RequestEnvelope other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return this.CorrelationId == other.CorrelationId && !(this.ServiceName != other.ServiceName) && (!(this.MethodName != other.MethodName) && !(this.Payload != other.Payload)) && (!(this.AuthId != other.AuthId) && !(this.AuthToken != other.AuthToken) && (this.ClientVersion == other.ClientVersion && this.ClientStartupTimestamp == other.ClientStartupTimestamp)) && (!(this.Platform != other.Platform) && !(this.Region != other.Region) && (!(this.ClientExternalVersion != other.ClientExternalVersion) && !(this.ClientInternalVersion != other.ClientInternalVersion)) && (!(this.RequestId != other.RequestId) && this.AcceptEncoding == other.AcceptEncoding && (this.flag_.Equals(other.flag_) && this.telemetryEvent_.Equals(other.telemetryEvent_)))) && (this.CurrentClientTime == other.CurrentClientTime && !(this.NimbleSessionId != other.NimbleSessionId) && (!(this.Timezone != other.Timezone) && !(this.FirmwareVersion != other.FirmwareVersion)) && (!(this.Carrier != other.Carrier) && !(this.NetworkAccess != other.NetworkAccess) && (!(this.HardwareId != other.HardwareId) && !(this.AdvertiserId != other.AdvertiserId))) && (!(this.VendorId != other.VendorId) && !(this.AndroidId != other.AndroidId) && (this.JailbrokenFlag == other.JailbrokenFlag && this.PiracyFlag == other.PiracyFlag) && (!(this.SynergyId != other.SynergyId) && !(this.DeviceModel != other.DeviceModel) && (!(this.DeviceId != other.DeviceId) && !(this.Application != other.Application))))) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num1 = 1;
      int num2;
      if (this.CorrelationId != 0)
      {
        int num3 = num1;
        num2 = this.CorrelationId;
        int hashCode = num2.GetHashCode();
        num1 = num3 ^ hashCode;
      }
      if (this.ServiceName.Length != 0)
        num1 ^= this.ServiceName.GetHashCode();
      if (this.MethodName.Length != 0)
        num1 ^= this.MethodName.GetHashCode();
      if (this.Payload.Length != 0)
        num1 ^= this.Payload.GetHashCode();
      if (this.AuthId.Length != 0)
        num1 ^= this.AuthId.GetHashCode();
      if (this.AuthToken.Length != 0)
        num1 ^= this.AuthToken.GetHashCode();
      if (this.ClientVersion != 0)
      {
        int num3 = num1;
        num2 = this.ClientVersion;
        int hashCode = num2.GetHashCode();
        num1 = num3 ^ hashCode;
      }
      long num4;
      if (this.ClientStartupTimestamp != 0L)
      {
        int num3 = num1;
        num4 = this.ClientStartupTimestamp;
        int hashCode = num4.GetHashCode();
        num1 = num3 ^ hashCode;
      }
      if (this.Platform.Length != 0)
        num1 ^= this.Platform.GetHashCode();
      if (this.Region.Length != 0)
        num1 ^= this.Region.GetHashCode();
      if (this.ClientExternalVersion.Length != 0)
        num1 ^= this.ClientExternalVersion.GetHashCode();
      if (this.ClientInternalVersion.Length != 0)
        num1 ^= this.ClientInternalVersion.GetHashCode();
      if (this.RequestId.Length != 0)
        num1 ^= this.RequestId.GetHashCode();
      if (this.AcceptEncoding != AcceptEncoding.Defaultacceptencoding)
        num1 ^= this.AcceptEncoding.GetHashCode();
      int num5 = num1 ^ this.flag_.GetHashCode() ^ this.telemetryEvent_.GetHashCode();
      if (this.CurrentClientTime != 0L)
      {
        int num3 = num5;
        num4 = this.CurrentClientTime;
        int hashCode = num4.GetHashCode();
        num5 = num3 ^ hashCode;
      }
      if (this.NimbleSessionId.Length != 0)
        num5 ^= this.NimbleSessionId.GetHashCode();
      if (this.Timezone.Length != 0)
        num5 ^= this.Timezone.GetHashCode();
      if (this.FirmwareVersion.Length != 0)
        num5 ^= this.FirmwareVersion.GetHashCode();
      if (this.Carrier.Length != 0)
        num5 ^= this.Carrier.GetHashCode();
      if (this.NetworkAccess.Length != 0)
        num5 ^= this.NetworkAccess.GetHashCode();
      if (this.HardwareId.Length != 0)
        num5 ^= this.HardwareId.GetHashCode();
      if (this.AdvertiserId.Length != 0)
        num5 ^= this.AdvertiserId.GetHashCode();
      if (this.VendorId.Length != 0)
        num5 ^= this.VendorId.GetHashCode();
      if (this.AndroidId.Length != 0)
        num5 ^= this.AndroidId.GetHashCode();
      if (this.JailbrokenFlag != 0)
      {
        int num3 = num5;
        num2 = this.JailbrokenFlag;
        int hashCode = num2.GetHashCode();
        num5 = num3 ^ hashCode;
      }
      if (this.PiracyFlag != 0)
      {
        int num3 = num5;
        num2 = this.PiracyFlag;
        int hashCode = num2.GetHashCode();
        num5 = num3 ^ hashCode;
      }
      if (this.SynergyId.Length != 0)
        num5 ^= this.SynergyId.GetHashCode();
      if (this.DeviceModel.Length != 0)
        num5 ^= this.DeviceModel.GetHashCode();
      if (this.DeviceId.Length != 0)
        num5 ^= this.DeviceId.GetHashCode();
      if (this.Application.Length != 0)
        num5 ^= this.Application.GetHashCode();
      if (this._unknownFields != null)
        num5 ^= this._unknownFields.GetHashCode();
      return num5;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.CorrelationId != 0)
      {
        output.WriteRawTag((byte) 8);
        output.WriteInt32(this.CorrelationId);
      }
      if (this.ServiceName.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteString(this.ServiceName);
      }
      if (this.MethodName.Length != 0)
      {
        output.WriteRawTag((byte) 42);
        output.WriteString(this.MethodName);
      }
      if (this.Payload.Length != 0)
      {
        output.WriteRawTag((byte) 50);
        output.WriteBytes(this.Payload);
      }
      if (this.AuthId.Length != 0)
      {
        output.WriteRawTag((byte) 58);
        output.WriteString(this.AuthId);
      }
      if (this.AuthToken.Length != 0)
      {
        output.WriteRawTag((byte) 66);
        output.WriteString(this.AuthToken);
      }
      if (this.ClientVersion != 0)
      {
        output.WriteRawTag((byte) 72);
        output.WriteInt32(this.ClientVersion);
      }
      if (this.ClientStartupTimestamp != 0L)
      {
        output.WriteRawTag((byte) 88);
        output.WriteInt64(this.ClientStartupTimestamp);
      }
      if (this.Platform.Length != 0)
      {
        output.WriteRawTag((byte) 98);
        output.WriteString(this.Platform);
      }
      if (this.Region.Length != 0)
      {
        output.WriteRawTag((byte) 106);
        output.WriteString(this.Region);
      }
      if (this.ClientExternalVersion.Length != 0)
      {
        output.WriteRawTag((byte) 114);
        output.WriteString(this.ClientExternalVersion);
      }
      if (this.ClientInternalVersion.Length != 0)
      {
        output.WriteRawTag((byte) 122);
        output.WriteString(this.ClientInternalVersion);
      }
      if (this.RequestId.Length != 0)
      {
        output.WriteRawTag((byte) 130, (byte) 1);
        output.WriteString(this.RequestId);
      }
      if (this.AcceptEncoding != AcceptEncoding.Defaultacceptencoding)
      {
        output.WriteRawTag((byte) 136, (byte) 1);
        output.WriteEnum((int) this.AcceptEncoding);
      }
      this.flag_.WriteTo(output, RequestEnvelope._repeated_flag_codec);
      this.telemetryEvent_.WriteTo(output, RequestEnvelope._repeated_telemetryEvent_codec);
      if (this.CurrentClientTime != 0L)
      {
        output.WriteRawTag((byte) 160, (byte) 1);
        output.WriteInt64(this.CurrentClientTime);
      }
      if (this.NimbleSessionId.Length != 0)
      {
        output.WriteRawTag((byte) 170, (byte) 1);
        output.WriteString(this.NimbleSessionId);
      }
      if (this.Timezone.Length != 0)
      {
        output.WriteRawTag((byte) 178, (byte) 1);
        output.WriteString(this.Timezone);
      }
      if (this.FirmwareVersion.Length != 0)
      {
        output.WriteRawTag((byte) 186, (byte) 1);
        output.WriteString(this.FirmwareVersion);
      }
      if (this.Carrier.Length != 0)
      {
        output.WriteRawTag((byte) 194, (byte) 1);
        output.WriteString(this.Carrier);
      }
      if (this.NetworkAccess.Length != 0)
      {
        output.WriteRawTag((byte) 202, (byte) 1);
        output.WriteString(this.NetworkAccess);
      }
      if (this.HardwareId.Length != 0)
      {
        output.WriteRawTag((byte) 210, (byte) 1);
        output.WriteString(this.HardwareId);
      }
      if (this.AdvertiserId.Length != 0)
      {
        output.WriteRawTag((byte) 218, (byte) 1);
        output.WriteString(this.AdvertiserId);
      }
      if (this.VendorId.Length != 0)
      {
        output.WriteRawTag((byte) 226, (byte) 1);
        output.WriteString(this.VendorId);
      }
      if (this.AndroidId.Length != 0)
      {
        output.WriteRawTag((byte) 234, (byte) 1);
        output.WriteString(this.AndroidId);
      }
      if (this.JailbrokenFlag != 0)
      {
        output.WriteRawTag((byte) 240, (byte) 1);
        output.WriteInt32(this.JailbrokenFlag);
      }
      if (this.PiracyFlag != 0)
      {
        output.WriteRawTag((byte) 248, (byte) 1);
        output.WriteInt32(this.PiracyFlag);
      }
      if (this.SynergyId.Length != 0)
      {
        output.WriteRawTag((byte) 130, (byte) 2);
        output.WriteString(this.SynergyId);
      }
      if (this.DeviceModel.Length != 0)
      {
        output.WriteRawTag((byte) 138, (byte) 2);
        output.WriteString(this.DeviceModel);
      }
      if (this.DeviceId.Length != 0)
      {
        output.WriteRawTag((byte) 146, (byte) 2);
        output.WriteString(this.DeviceId);
      }
      if (this.Application.Length != 0)
      {
        output.WriteRawTag((byte) 170, (byte) 2);
        output.WriteString(this.Application);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num1 = 0;
      if (this.CorrelationId != 0)
        num1 += 1 + CodedOutputStream.ComputeInt32Size(this.CorrelationId);
      if (this.ServiceName.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.ServiceName);
      if (this.MethodName.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.MethodName);
      if (this.Payload.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeBytesSize(this.Payload);
      if (this.AuthId.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.AuthId);
      if (this.AuthToken.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.AuthToken);
      if (this.ClientVersion != 0)
        num1 += 1 + CodedOutputStream.ComputeInt32Size(this.ClientVersion);
      if (this.ClientStartupTimestamp != 0L)
        num1 += 1 + CodedOutputStream.ComputeInt64Size(this.ClientStartupTimestamp);
      if (this.Platform.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.Platform);
      if (this.Region.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.Region);
      if (this.ClientExternalVersion.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.ClientExternalVersion);
      if (this.ClientInternalVersion.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.ClientInternalVersion);
      if (this.RequestId.Length != 0)
        num1 += 2 + CodedOutputStream.ComputeStringSize(this.RequestId);
      if (this.AcceptEncoding != AcceptEncoding.Defaultacceptencoding)
        num1 += 2 + CodedOutputStream.ComputeEnumSize((int) this.AcceptEncoding);
      int num2 = num1 + this.flag_.CalculateSize(RequestEnvelope._repeated_flag_codec) + this.telemetryEvent_.CalculateSize(RequestEnvelope._repeated_telemetryEvent_codec);
      if (this.CurrentClientTime != 0L)
        num2 += 2 + CodedOutputStream.ComputeInt64Size(this.CurrentClientTime);
      if (this.NimbleSessionId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.NimbleSessionId);
      if (this.Timezone.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.Timezone);
      if (this.FirmwareVersion.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.FirmwareVersion);
      if (this.Carrier.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.Carrier);
      if (this.NetworkAccess.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.NetworkAccess);
      if (this.HardwareId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.HardwareId);
      if (this.AdvertiserId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.AdvertiserId);
      if (this.VendorId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.VendorId);
      if (this.AndroidId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.AndroidId);
      if (this.JailbrokenFlag != 0)
        num2 += 2 + CodedOutputStream.ComputeInt32Size(this.JailbrokenFlag);
      if (this.PiracyFlag != 0)
        num2 += 2 + CodedOutputStream.ComputeInt32Size(this.PiracyFlag);
      if (this.SynergyId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.SynergyId);
      if (this.DeviceModel.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.DeviceModel);
      if (this.DeviceId.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.DeviceId);
      if (this.Application.Length != 0)
        num2 += 2 + CodedOutputStream.ComputeStringSize(this.Application);
      if (this._unknownFields != null)
        num2 += this._unknownFields.CalculateSize();
      return num2;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(RequestEnvelope other)
    {
      if (other == null)
        return;
      if (other.CorrelationId != 0)
        this.CorrelationId = other.CorrelationId;
      if (other.ServiceName.Length != 0)
        this.ServiceName = other.ServiceName;
      if (other.MethodName.Length != 0)
        this.MethodName = other.MethodName;
      if (other.Payload.Length != 0)
        this.Payload = other.Payload;
      if (other.AuthId.Length != 0)
        this.AuthId = other.AuthId;
      if (other.AuthToken.Length != 0)
        this.AuthToken = other.AuthToken;
      if (other.ClientVersion != 0)
        this.ClientVersion = other.ClientVersion;
      if (other.ClientStartupTimestamp != 0L)
        this.ClientStartupTimestamp = other.ClientStartupTimestamp;
      if (other.Platform.Length != 0)
        this.Platform = other.Platform;
      if (other.Region.Length != 0)
        this.Region = other.Region;
      if (other.ClientExternalVersion.Length != 0)
        this.ClientExternalVersion = other.ClientExternalVersion;
      if (other.ClientInternalVersion.Length != 0)
        this.ClientInternalVersion = other.ClientInternalVersion;
      if (other.RequestId.Length != 0)
        this.RequestId = other.RequestId;
      if (other.AcceptEncoding != AcceptEncoding.Defaultacceptencoding)
        this.AcceptEncoding = other.AcceptEncoding;
      this.flag_.Add((IEnumerable<string>) other.flag_);
      this.telemetryEvent_.Add((IEnumerable<string>) other.telemetryEvent_);
      if (other.CurrentClientTime != 0L)
        this.CurrentClientTime = other.CurrentClientTime;
      if (other.NimbleSessionId.Length != 0)
        this.NimbleSessionId = other.NimbleSessionId;
      if (other.Timezone.Length != 0)
        this.Timezone = other.Timezone;
      if (other.FirmwareVersion.Length != 0)
        this.FirmwareVersion = other.FirmwareVersion;
      if (other.Carrier.Length != 0)
        this.Carrier = other.Carrier;
      if (other.NetworkAccess.Length != 0)
        this.NetworkAccess = other.NetworkAccess;
      if (other.HardwareId.Length != 0)
        this.HardwareId = other.HardwareId;
      if (other.AdvertiserId.Length != 0)
        this.AdvertiserId = other.AdvertiserId;
      if (other.VendorId.Length != 0)
        this.VendorId = other.VendorId;
      if (other.AndroidId.Length != 0)
        this.AndroidId = other.AndroidId;
      if (other.JailbrokenFlag != 0)
        this.JailbrokenFlag = other.JailbrokenFlag;
      if (other.PiracyFlag != 0)
        this.PiracyFlag = other.PiracyFlag;
      if (other.SynergyId.Length != 0)
        this.SynergyId = other.SynergyId;
      if (other.DeviceModel.Length != 0)
        this.DeviceModel = other.DeviceModel;
      if (other.DeviceId.Length != 0)
        this.DeviceId = other.DeviceId;
      if (other.Application.Length != 0)
        this.Application = other.Application;
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
          case 8:
            this.CorrelationId = input.ReadInt32();
            continue;
          case 34:
            this.ServiceName = input.ReadString();
            continue;
          case 42:
            this.MethodName = input.ReadString();
            continue;
          case 50:
            this.Payload = input.ReadBytes();
            continue;
          case 58:
            this.AuthId = input.ReadString();
            continue;
          case 66:
            this.AuthToken = input.ReadString();
            continue;
          case 72:
            this.ClientVersion = input.ReadInt32();
            continue;
          case 88:
            this.ClientStartupTimestamp = input.ReadInt64();
            continue;
          case 98:
            this.Platform = input.ReadString();
            continue;
          case 106:
            this.Region = input.ReadString();
            continue;
          case 114:
            this.ClientExternalVersion = input.ReadString();
            continue;
          case 122:
            this.ClientInternalVersion = input.ReadString();
            continue;
          case 130:
            this.RequestId = input.ReadString();
            continue;
          case 136:
            this.acceptEncoding_ = (AcceptEncoding) input.ReadEnum();
            continue;
          case 146:
            this.flag_.AddEntriesFrom(input, RequestEnvelope._repeated_flag_codec);
            continue;
          case 154:
            this.telemetryEvent_.AddEntriesFrom(input, RequestEnvelope._repeated_telemetryEvent_codec);
            continue;
          case 160:
            this.CurrentClientTime = input.ReadInt64();
            continue;
          case 170:
            this.NimbleSessionId = input.ReadString();
            continue;
          case 178:
            this.Timezone = input.ReadString();
            continue;
          case 186:
            this.FirmwareVersion = input.ReadString();
            continue;
          case 194:
            this.Carrier = input.ReadString();
            continue;
          case 202:
            this.NetworkAccess = input.ReadString();
            continue;
          case 210:
            this.HardwareId = input.ReadString();
            continue;
          case 218:
            this.AdvertiserId = input.ReadString();
            continue;
          case 226:
            this.VendorId = input.ReadString();
            continue;
          case 234:
            this.AndroidId = input.ReadString();
            continue;
          case 240:
            this.JailbrokenFlag = input.ReadInt32();
            continue;
          case 248:
            this.PiracyFlag = input.ReadInt32();
            continue;
          case 258:
            this.SynergyId = input.ReadString();
            continue;
          case 266:
            this.DeviceModel = input.ReadString();
            continue;
          case 274:
            this.DeviceId = input.ReadString();
            continue;
          case 298:
            this.Application = input.ReadString();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
