// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.ResponseEnvelope
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Collections;
using Google.Protobuf.Reflection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class ResponseEnvelope : IMessage<ResponseEnvelope>, IMessage, IEquatable<ResponseEnvelope>, IDeepCloneable<ResponseEnvelope>
  {
    private static readonly MessageParser<ResponseEnvelope> _parser = new MessageParser<ResponseEnvelope>((Func<ResponseEnvelope>) (() => new ResponseEnvelope()));
    private UnknownFieldSet _unknownFields;
    public const int CorrelationIdFieldNumber = 1;
    private int correlationId_;
    public const int CurrentServerTimeFieldNumber = 2;
    private long currentServerTime_;
    public const int PayloadFieldNumber = 4;
    private ByteString payload_ = ByteString.Empty;
    public const int CodeFieldNumber = 5;
    private ResponseCode code_;
    public const int MessageFieldNumber = 6;
    private string message_ = "";
    public const int ContentEncodingFieldNumber = 7;
    private ContentEncoding contentEncoding_;
    public const int StackTraceFieldNumber = 8;
    private string stackTrace_ = "";
    public const int DynamicMessageFieldNumber = 9;
    private static readonly FieldCodec<Ipd.Game.Protocol.DynamicMessage> _repeated_dynamicMessage_codec = FieldCodec.ForMessage<Ipd.Game.Protocol.DynamicMessage>(74U, Ipd.Game.Protocol.DynamicMessage.Parser);
    private readonly RepeatedField<Ipd.Game.Protocol.DynamicMessage> dynamicMessage_ = new RepeatedField<Ipd.Game.Protocol.DynamicMessage>();
    public const int MaintenanceMessageFieldNumber = 10;
    private string maintenanceMessage_ = "";
    public const int MaintenanceLinkFieldNumber = 11;
    private string maintenanceLink_ = "";
    public const int SubCodeFieldNumber = 12;
    private int subCode_;

    [DebuggerNonUserCode]
    public static MessageParser<ResponseEnvelope> Parser => ResponseEnvelope._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => ResponseEnvelopeReflection.Descriptor.MessageTypes[1];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.Descriptor => ResponseEnvelope.Descriptor;

    [DebuggerNonUserCode]
    public ResponseEnvelope()
    {
    }

    [DebuggerNonUserCode]
    public ResponseEnvelope(ResponseEnvelope other)
      : this()
    {
      this.correlationId_ = other.correlationId_;
      this.currentServerTime_ = other.currentServerTime_;
      this.payload_ = other.payload_;
      this.code_ = other.code_;
      this.message_ = other.message_;
      this.contentEncoding_ = other.contentEncoding_;
      this.stackTrace_ = other.stackTrace_;
      this.dynamicMessage_ = other.dynamicMessage_.Clone();
      this.maintenanceMessage_ = other.maintenanceMessage_;
      this.maintenanceLink_ = other.maintenanceLink_;
      this.subCode_ = other.subCode_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public ResponseEnvelope Clone() => new ResponseEnvelope(this);

    [DebuggerNonUserCode]
    public int CorrelationId
    {
      get => this.correlationId_;
      set => this.correlationId_ = value;
    }

    [DebuggerNonUserCode]
    public long CurrentServerTime
    {
      get => this.currentServerTime_;
      set => this.currentServerTime_ = value;
    }

    [DebuggerNonUserCode]
    public ByteString Payload
    {
      get => this.payload_;
      set => this.payload_ = ProtoPreconditions.CheckNotNull<ByteString>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public ResponseCode Code
    {
      get => this.code_;
      set => this.code_ = value;
    }

    [DebuggerNonUserCode]
    public string Message
    {
      get => this.message_;
      set => this.message_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public ContentEncoding ContentEncoding
    {
      get => this.contentEncoding_;
      set => this.contentEncoding_ = value;
    }

    [DebuggerNonUserCode]
    public string StackTrace
    {
      get => this.stackTrace_;
      set => this.stackTrace_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public RepeatedField<Ipd.Game.Protocol.DynamicMessage> DynamicMessage => this.dynamicMessage_;

    [DebuggerNonUserCode]
    public string MaintenanceMessage
    {
      get => this.maintenanceMessage_;
      set => this.maintenanceMessage_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string MaintenanceLink
    {
      get => this.maintenanceLink_;
      set => this.maintenanceLink_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int SubCode
    {
      get => this.subCode_;
      set => this.subCode_ = value;
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as ResponseEnvelope);

    [DebuggerNonUserCode]
    public bool Equals(ResponseEnvelope other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return this.CorrelationId == other.CorrelationId && this.CurrentServerTime == other.CurrentServerTime && (!(this.Payload != other.Payload) && this.Code == other.Code) && (!(this.Message != other.Message) && this.ContentEncoding == other.ContentEncoding && (!(this.StackTrace != other.StackTrace) && this.dynamicMessage_.Equals(other.dynamicMessage_))) && (!(this.MaintenanceMessage != other.MaintenanceMessage) && !(this.MaintenanceLink != other.MaintenanceLink) && this.SubCode == other.SubCode) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
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
      if (this.CurrentServerTime != 0L)
        num1 ^= this.CurrentServerTime.GetHashCode();
      if (this.Payload.Length != 0)
        num1 ^= this.Payload.GetHashCode();
      if (this.Code != ResponseCode.None)
        num1 ^= this.Code.GetHashCode();
      if (this.Message.Length != 0)
        num1 ^= this.Message.GetHashCode();
      if (this.ContentEncoding != ContentEncoding.Defaultcontentencoding)
        num1 ^= this.ContentEncoding.GetHashCode();
      if (this.StackTrace.Length != 0)
        num1 ^= this.StackTrace.GetHashCode();
      int num4 = num1 ^ this.dynamicMessage_.GetHashCode();
      if (this.MaintenanceMessage.Length != 0)
        num4 ^= this.MaintenanceMessage.GetHashCode();
      if (this.MaintenanceLink.Length != 0)
        num4 ^= this.MaintenanceLink.GetHashCode();
      if (this.SubCode != 0)
      {
        int num3 = num4;
        num2 = this.SubCode;
        int hashCode = num2.GetHashCode();
        num4 = num3 ^ hashCode;
      }
      if (this._unknownFields != null)
        num4 ^= this._unknownFields.GetHashCode();
      return num4;
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
      if (this.CurrentServerTime != 0L)
      {
        output.WriteRawTag((byte) 16);
        output.WriteInt64(this.CurrentServerTime);
      }
      if (this.Payload.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteBytes(this.Payload);
      }
      if (this.Code != ResponseCode.None)
      {
        output.WriteRawTag((byte) 40);
        output.WriteEnum((int) this.Code);
      }
      if (this.Message.Length != 0)
      {
        output.WriteRawTag((byte) 50);
        output.WriteString(this.Message);
      }
      if (this.ContentEncoding != ContentEncoding.Defaultcontentencoding)
      {
        output.WriteRawTag((byte) 56);
        output.WriteEnum((int) this.ContentEncoding);
      }
      if (this.StackTrace.Length != 0)
      {
        output.WriteRawTag((byte) 66);
        output.WriteString(this.StackTrace);
      }
      this.dynamicMessage_.WriteTo(output, ResponseEnvelope._repeated_dynamicMessage_codec);
      if (this.MaintenanceMessage.Length != 0)
      {
        output.WriteRawTag((byte) 82);
        output.WriteString(this.MaintenanceMessage);
      }
      if (this.MaintenanceLink.Length != 0)
      {
        output.WriteRawTag((byte) 90);
        output.WriteString(this.MaintenanceLink);
      }
      if (this.SubCode != 0)
      {
        output.WriteRawTag((byte) 96);
        output.WriteInt32(this.SubCode);
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
      if (this.CurrentServerTime != 0L)
        num1 += 1 + CodedOutputStream.ComputeInt64Size(this.CurrentServerTime);
      if (this.Payload.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeBytesSize(this.Payload);
      if (this.Code != ResponseCode.None)
        num1 += 1 + CodedOutputStream.ComputeEnumSize((int) this.Code);
      if (this.Message.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.Message);
      if (this.ContentEncoding != ContentEncoding.Defaultcontentencoding)
        num1 += 1 + CodedOutputStream.ComputeEnumSize((int) this.ContentEncoding);
      if (this.StackTrace.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.StackTrace);
      int num2 = num1 + this.dynamicMessage_.CalculateSize(ResponseEnvelope._repeated_dynamicMessage_codec);
      if (this.MaintenanceMessage.Length != 0)
        num2 += 1 + CodedOutputStream.ComputeStringSize(this.MaintenanceMessage);
      if (this.MaintenanceLink.Length != 0)
        num2 += 1 + CodedOutputStream.ComputeStringSize(this.MaintenanceLink);
      if (this.SubCode != 0)
        num2 += 1 + CodedOutputStream.ComputeInt32Size(this.SubCode);
      if (this._unknownFields != null)
        num2 += this._unknownFields.CalculateSize();
      return num2;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(ResponseEnvelope other)
    {
      if (other == null)
        return;
      if (other.CorrelationId != 0)
        this.CorrelationId = other.CorrelationId;
      if (other.CurrentServerTime != 0L)
        this.CurrentServerTime = other.CurrentServerTime;
      if (other.Payload.Length != 0)
        this.Payload = other.Payload;
      if (other.Code != ResponseCode.None)
        this.Code = other.Code;
      if (other.Message.Length != 0)
        this.Message = other.Message;
      if (other.ContentEncoding != ContentEncoding.Defaultcontentencoding)
        this.ContentEncoding = other.ContentEncoding;
      if (other.StackTrace.Length != 0)
        this.StackTrace = other.StackTrace;
      this.dynamicMessage_.Add((IEnumerable<Ipd.Game.Protocol.DynamicMessage>) other.dynamicMessage_);
      if (other.MaintenanceMessage.Length != 0)
        this.MaintenanceMessage = other.MaintenanceMessage;
      if (other.MaintenanceLink.Length != 0)
        this.MaintenanceLink = other.MaintenanceLink;
      if (other.SubCode != 0)
        this.SubCode = other.SubCode;
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
          case 16:
            this.CurrentServerTime = input.ReadInt64();
            continue;
          case 34:
            this.Payload = input.ReadBytes();
            continue;
          case 40:
            this.code_ = (ResponseCode) input.ReadEnum();
            continue;
          case 50:
            this.Message = input.ReadString();
            continue;
          case 56:
            this.contentEncoding_ = (ContentEncoding) input.ReadEnum();
            continue;
          case 66:
            this.StackTrace = input.ReadString();
            continue;
          case 74:
            this.dynamicMessage_.AddEntriesFrom(input, ResponseEnvelope._repeated_dynamicMessage_codec);
            continue;
          case 82:
            this.MaintenanceMessage = input.ReadString();
            continue;
          case 90:
            this.MaintenanceLink = input.ReadString();
            continue;
          case 96:
            this.SubCode = input.ReadInt32();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
