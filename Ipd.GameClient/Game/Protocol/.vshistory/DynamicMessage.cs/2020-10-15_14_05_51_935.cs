// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.DynamicMessage
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class DynamicMessage : IMessage<DynamicMessage>, IMessage, IEquatable<DynamicMessage>, IDeepCloneable<DynamicMessage>
  {
    private static readonly MessageParser<DynamicMessage> _parser = new MessageParser<DynamicMessage>((Func<DynamicMessage>) (() => new DynamicMessage()));
    private UnknownFieldSet _unknownFields;
    public const int IdFieldNumber = 1;
    private string id_ = "";
    public const int TypeFieldNumber = 2;
    private string type_ = "";
    public const int DataFieldNumber = 3;
    private ByteString data_ = ByteString.Empty;
    public const int MessageIdFieldNumber = 4;
    private int messageId_;

    [DebuggerNonUserCode]
    public static MessageParser<DynamicMessage> Parser => DynamicMessage._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => ResponseEnvelopeReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.pb\u003A\u003AGoogle\u002EProtobuf\u002EIMessage\u002EDescriptor => DynamicMessage.Descriptor;

    [DebuggerNonUserCode]
    public DynamicMessage()
    {
    }

    [DebuggerNonUserCode]
    public DynamicMessage(DynamicMessage other)
      : this()
    {
      this.id_ = other.id_;
      this.type_ = other.type_;
      this.data_ = other.data_;
      this.messageId_ = other.messageId_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public DynamicMessage Clone() => new DynamicMessage(this);

    [DebuggerNonUserCode]
    public string Id
    {
      get => this.id_;
      set => this.id_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string Type
    {
      get => this.type_;
      set => this.type_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public ByteString Data
    {
      get => this.data_;
      set => this.data_ = ProtoPreconditions.CheckNotNull<ByteString>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int MessageId
    {
      get => this.messageId_;
      set => this.messageId_ = value;
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as DynamicMessage);

    [DebuggerNonUserCode]
    public bool Equals(DynamicMessage other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.Id != other.Id) && !(this.Type != other.Type) && (!(this.Data != other.Data) && this.MessageId == other.MessageId) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.Id.Length != 0)
        num ^= this.Id.GetHashCode();
      if (this.Type.Length != 0)
        num ^= this.Type.GetHashCode();
      if (this.Data.Length != 0)
        num ^= this.Data.GetHashCode();
      if (this.MessageId != 0)
        num ^= this.MessageId.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.Id.Length != 0)
      {
        output.WriteRawTag((byte) 10);
        output.WriteString(this.Id);
      }
      if (this.Type.Length != 0)
      {
        output.WriteRawTag((byte) 18);
        output.WriteString(this.Type);
      }
      if (this.Data.Length != 0)
      {
        output.WriteRawTag((byte) 26);
        output.WriteBytes(this.Data);
      }
      if (this.MessageId != 0)
      {
        output.WriteRawTag((byte) 32);
        output.WriteInt32(this.MessageId);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.Id.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.Id);
      if (this.Type.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.Type);
      if (this.Data.Length != 0)
        num += 1 + CodedOutputStream.ComputeBytesSize(this.Data);
      if (this.MessageId != 0)
        num += 1 + CodedOutputStream.ComputeInt32Size(this.MessageId);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(DynamicMessage other)
    {
      if (other == null)
        return;
      if (other.Id.Length != 0)
        this.Id = other.Id;
      if (other.Type.Length != 0)
        this.Type = other.Type;
      if (other.Data.Length != 0)
        this.Data = other.Data;
      if (other.MessageId != 0)
        this.MessageId = other.MessageId;
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
            this.Id = input.ReadString();
            continue;
          case 18:
            this.Type = input.ReadString();
            continue;
          case 26:
            this.Data = input.ReadBytes();
            continue;
          case 32:
            this.MessageId = input.ReadInt32();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
