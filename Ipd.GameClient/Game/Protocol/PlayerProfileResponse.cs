// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.PlayerProfileResponse
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
  public sealed class PlayerProfileResponse : IMessage<PlayerProfileResponse>, IMessage, IEquatable<PlayerProfileResponse>, IDeepCloneable<PlayerProfileResponse>
  {
    private static readonly MessageParser<PlayerProfileResponse> _parser = new MessageParser<PlayerProfileResponse>((Func<PlayerProfileResponse>) (() => new PlayerProfileResponse()));
    private UnknownFieldSet _unknownFields;
    public const int NameFieldNumber = 1;
    private string name_ = "";
    public const int ArenaStatusesFieldNumber = 17;
    private static readonly FieldCodec<PlayerArenaStatus> _repeated_arenaStatuses_codec = FieldCodec.ForMessage<PlayerArenaStatus>(138U, PlayerArenaStatus.Parser);
    private readonly RepeatedField<PlayerArenaStatus> arenaStatuses_ = new RepeatedField<PlayerArenaStatus>();

    [DebuggerNonUserCode]
    public static MessageParser<PlayerProfileResponse> Parser => PlayerProfileResponse._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => PlayerProfileResponseReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.Descriptor => ResponseEnvelope.Descriptor;

        [DebuggerNonUserCode]
    public PlayerProfileResponse()
    {
    }

    [DebuggerNonUserCode]
    public PlayerProfileResponse(PlayerProfileResponse other)
      : this()
    {
      this.name_ = other.name_;
      this.arenaStatuses_ = other.arenaStatuses_.Clone();
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public PlayerProfileResponse Clone() => new PlayerProfileResponse(this);

    [DebuggerNonUserCode]
    public string Name
    {
      get => this.name_;
      set => this.name_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public RepeatedField<PlayerArenaStatus> ArenaStatuses => this.arenaStatuses_;

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as PlayerProfileResponse);

    [DebuggerNonUserCode]
    public bool Equals(PlayerProfileResponse other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.Name != other.Name) && this.arenaStatuses_.Equals(other.arenaStatuses_) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num1 = 1;
      if (this.Name.Length != 0)
        num1 ^= this.Name.GetHashCode();
      int num2 = num1 ^ this.arenaStatuses_.GetHashCode();
      if (this._unknownFields != null)
        num2 ^= this._unknownFields.GetHashCode();
      return num2;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.Name.Length != 0)
      {
        output.WriteRawTag((byte) 10);
        output.WriteString(this.Name);
      }
      this.arenaStatuses_.WriteTo(output, PlayerProfileResponse._repeated_arenaStatuses_codec);
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num1 = 0;
      if (this.Name.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.Name);
      int num2 = num1 + this.arenaStatuses_.CalculateSize(PlayerProfileResponse._repeated_arenaStatuses_codec);
      if (this._unknownFields != null)
        num2 += this._unknownFields.CalculateSize();
      return num2;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(PlayerProfileResponse other)
    {
      if (other == null)
        return;
      if (other.Name.Length != 0)
        this.Name = other.Name;
      this.arenaStatuses_.Add((IEnumerable<PlayerArenaStatus>) other.arenaStatuses_);
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
            this.Name = input.ReadString();
            continue;
          case 138:
            this.arenaStatuses_.AddEntriesFrom(input, PlayerProfileResponse._repeated_arenaStatuses_codec);
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
