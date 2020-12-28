// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.SlimPlayerArenaProfileResponse
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
  public sealed class SlimPlayerArenaProfileResponse : IMessage<SlimPlayerArenaProfileResponse>, IMessage, IEquatable<SlimPlayerArenaProfileResponse>, IDeepCloneable<SlimPlayerArenaProfileResponse>
  {
    private static readonly MessageParser<SlimPlayerArenaProfileResponse> _parser = new MessageParser<SlimPlayerArenaProfileResponse>((Func<SlimPlayerArenaProfileResponse>) (() => new SlimPlayerArenaProfileResponse()));
    private UnknownFieldSet _unknownFields;
    public const int NameFieldNumber = 1;
    private string name_ = "";
    public const int LevelFieldNumber = 2;
    private int level_;
    public const int AllyCodeFieldNumber = 3;
    private long allyCode_;
    public const int PlayerIdFieldNumber = 4;
    private string playerId_ = "";
    public const int PvpProfileFieldNumber = 5;
    private static readonly FieldCodec<PlayerPvpProfile> _repeated_pvpProfile_codec = FieldCodec.ForMessage<PlayerPvpProfile>(42U, PlayerPvpProfile.Parser);
    private readonly RepeatedField<PlayerPvpProfile> pvpProfile_ = new RepeatedField<PlayerPvpProfile>();
    public const int LocalTimeZoneOffsetMinutesFieldNumber = 6;
    private int localTimeZoneOffsetMinutes_;

    [DebuggerNonUserCode]
    public static MessageParser<SlimPlayerArenaProfileResponse> Parser => SlimPlayerArenaProfileResponse._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => SlimPlayerProfileReflection.Descriptor.MessageTypes[1];

    [DebuggerNonUserCode]
    MessageDescriptor Google.Protobuf.IMessage.Descriptor => SlimPlayerArenaProfileResponse.Descriptor;

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileResponse()
    {
    }

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileResponse(SlimPlayerArenaProfileResponse other)
      : this()
    {
      this.name_ = other.name_;
      this.level_ = other.level_;
      this.allyCode_ = other.allyCode_;
      this.playerId_ = other.playerId_;
      this.pvpProfile_ = other.pvpProfile_.Clone();
      this.localTimeZoneOffsetMinutes_ = other.localTimeZoneOffsetMinutes_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public SlimPlayerArenaProfileResponse Clone() => new SlimPlayerArenaProfileResponse(this);

    [DebuggerNonUserCode]
    public string Name
    {
      get => this.name_;
      set => this.name_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public int Level
    {
      get => this.level_;
      set => this.level_ = value;
    }

    [DebuggerNonUserCode]
    public long AllyCode
    {
      get => this.allyCode_;
      set => this.allyCode_ = value;
    }

    [DebuggerNonUserCode]
    public string PlayerId
    {
      get => this.playerId_;
      set => this.playerId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public RepeatedField<PlayerPvpProfile> PvpProfile => this.pvpProfile_;

    [DebuggerNonUserCode]
    public int LocalTimeZoneOffsetMinutes
    {
      get => this.localTimeZoneOffsetMinutes_;
      set => this.localTimeZoneOffsetMinutes_ = value;
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as SlimPlayerArenaProfileResponse);

    [DebuggerNonUserCode]
    public bool Equals(SlimPlayerArenaProfileResponse other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.Name != other.Name) && this.Level == other.Level && (this.AllyCode == other.AllyCode && !(this.PlayerId != other.PlayerId)) && (this.pvpProfile_.Equals(other.pvpProfile_) && this.LocalTimeZoneOffsetMinutes == other.LocalTimeZoneOffsetMinutes) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num1 = 1;
      if (this.Name.Length != 0)
        num1 ^= this.Name.GetHashCode();
      if (this.Level != 0)
        num1 ^= this.Level.GetHashCode();
      if (this.AllyCode != 0L)
        num1 ^= this.AllyCode.GetHashCode();
      if (this.PlayerId.Length != 0)
        num1 ^= this.PlayerId.GetHashCode();
      int num2 = num1 ^ this.pvpProfile_.GetHashCode();
      if (this.LocalTimeZoneOffsetMinutes != 0)
        num2 ^= this.LocalTimeZoneOffsetMinutes.GetHashCode();
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
      if (this.Level != 0)
      {
        output.WriteRawTag((byte) 16);
        output.WriteInt32(this.Level);
      }
      if (this.AllyCode != 0L)
      {
        output.WriteRawTag((byte) 24);
        output.WriteInt64(this.AllyCode);
      }
      if (this.PlayerId.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteString(this.PlayerId);
      }
      this.pvpProfile_.WriteTo(output, SlimPlayerArenaProfileResponse._repeated_pvpProfile_codec);
      if (this.LocalTimeZoneOffsetMinutes != 0)
      {
        output.WriteRawTag((byte) 48);
        output.WriteSInt32(this.LocalTimeZoneOffsetMinutes);
      }
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
      if (this.Level != 0)
        num1 += 1 + CodedOutputStream.ComputeInt32Size(this.Level);
      if (this.AllyCode != 0L)
        num1 += 1 + CodedOutputStream.ComputeInt64Size(this.AllyCode);
      if (this.PlayerId.Length != 0)
        num1 += 1 + CodedOutputStream.ComputeStringSize(this.PlayerId);
      int num2 = num1 + this.pvpProfile_.CalculateSize(SlimPlayerArenaProfileResponse._repeated_pvpProfile_codec);
      if (this.LocalTimeZoneOffsetMinutes != 0)
        num2 += 1 + CodedOutputStream.ComputeSInt32Size(this.LocalTimeZoneOffsetMinutes);
      if (this._unknownFields != null)
        num2 += this._unknownFields.CalculateSize();
      return num2;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(SlimPlayerArenaProfileResponse other)
    {
      if (other == null)
        return;
      if (other.Name.Length != 0)
        this.Name = other.Name;
      if (other.Level != 0)
        this.Level = other.Level;
      if (other.AllyCode != 0L)
        this.AllyCode = other.AllyCode;
      if (other.PlayerId.Length != 0)
        this.PlayerId = other.PlayerId;
      this.pvpProfile_.Add((IEnumerable<PlayerPvpProfile>) other.pvpProfile_);
      if (other.LocalTimeZoneOffsetMinutes != 0)
        this.LocalTimeZoneOffsetMinutes = other.LocalTimeZoneOffsetMinutes;
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
          case 16:
            this.Level = input.ReadInt32();
            continue;
          case 24:
            this.AllyCode = input.ReadInt64();
            continue;
          case 34:
            this.PlayerId = input.ReadString();
            continue;
          case 42:
            this.pvpProfile_.AddEntriesFrom(input, SlimPlayerArenaProfileResponse._repeated_pvpProfile_codec);
            continue;
          case 48:
            this.LocalTimeZoneOffsetMinutes = input.ReadSInt32();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
