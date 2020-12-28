// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.SlimPlayerArenaProfileRequest
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class SlimPlayerArenaProfileRequest : IMessage<SlimPlayerArenaProfileRequest>, IMessage, IEquatable<SlimPlayerArenaProfileRequest>, IDeepCloneable<SlimPlayerArenaProfileRequest>
  {
    private static readonly MessageParser<SlimPlayerArenaProfileRequest> _parser = new MessageParser<SlimPlayerArenaProfileRequest>((Func<SlimPlayerArenaProfileRequest>) (() => new SlimPlayerArenaProfileRequest()));
    private UnknownFieldSet _unknownFields;
    public const int PlayerIdFieldNumber = 1;
    private string playerId_ = "";
    public const int AllyCodeFieldNumber = 2;
    private string allyCode_ = "";

    [DebuggerNonUserCode]
    public static MessageParser<SlimPlayerArenaProfileRequest> Parser => SlimPlayerArenaProfileRequest._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => SlimPlayerProfileReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor Google.Protobuf.IMessage.Descriptor => SlimPlayerArenaProfileRequest.Descriptor;

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileRequest()
    {
    }

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileRequest(SlimPlayerArenaProfileRequest other)
      : this()
    {
      this.playerId_ = other.playerId_;
      this.allyCode_ = other.allyCode_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileRequest Clone() => new SlimPlayerArenaProfileRequest(this);

    [DebuggerNonUserCode]
    public string PlayerId
    {
      get => this.playerId_;
      set => this.playerId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public string AllyCode
    {
      get => this.allyCode_;
      set => this.allyCode_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as SlimPlayerArenaProfileRequest);

    [DebuggerNonUserCode]
    public bool Equals(SlimPlayerArenaProfileRequest other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.PlayerId != other.PlayerId) && !(this.AllyCode != other.AllyCode) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.PlayerId.Length != 0)
        num ^= this.PlayerId.GetHashCode();
      if (this.AllyCode.Length != 0)
        num ^= this.AllyCode.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.PlayerId.Length != 0)
      {
        output.WriteRawTag((byte) 10);
        output.WriteString(this.PlayerId);
      }
      if (this.AllyCode.Length != 0)
      {
        output.WriteRawTag((byte) 18);
        output.WriteString(this.AllyCode);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.PlayerId.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.PlayerId);
      if (this.AllyCode.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.AllyCode);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(SlimPlayerArenaProfileRequest other)
    {
      if (other == null)
        return;
      if (other.PlayerId.Length != 0)
        this.PlayerId = other.PlayerId;
      if (other.AllyCode.Length != 0)
        this.AllyCode = other.AllyCode;
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
            this.PlayerId = input.ReadString();
            continue;
          case 18:
            this.AllyCode = input.ReadString();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
