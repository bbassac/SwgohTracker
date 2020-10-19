// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.PlayerArenaStatus
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class PlayerArenaStatus : IMessage<PlayerArenaStatus>, IMessage, IEquatable<PlayerArenaStatus>, IDeepCloneable<PlayerArenaStatus>
  {
    private static readonly MessageParser<PlayerArenaStatus> _parser = new MessageParser<PlayerArenaStatus>((Func<PlayerArenaStatus>) (() => new PlayerArenaStatus()));
    private UnknownFieldSet _unknownFields;
    public const int ArenaTypeFieldNumber = 1;
    private PlayerArenaType arenaType_;
    public const int PlaceFieldNumber = 2;
    private int place_;

    [DebuggerNonUserCode]
    public static MessageParser<PlayerArenaStatus> Parser => PlayerArenaStatus._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => PlayerProfileResponseReflection.Descriptor.MessageTypes[1];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.pb\u003A\u003AGoogle\u002EProtobuf\u002EIMessage\u002EDescriptor => PlayerArenaStatus.Descriptor;

    [DebuggerNonUserCode]
    public PlayerArenaStatus()
    {
    }

    [DebuggerNonUserCode]
    public PlayerArenaStatus(PlayerArenaStatus other)
      : this()
    {
      this.arenaType_ = other.arenaType_;
      this.place_ = other.place_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public PlayerArenaStatus Clone() => new PlayerArenaStatus(this);

    [DebuggerNonUserCode]
    public PlayerArenaType ArenaType
    {
      get => this.arenaType_;
      set => this.arenaType_ = value;
    }

    [DebuggerNonUserCode]
    public int Place
    {
      get => this.place_;
      set => this.place_ = value;
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as PlayerArenaStatus);

    [DebuggerNonUserCode]
    public bool Equals(PlayerArenaStatus other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return this.ArenaType == other.ArenaType && this.Place == other.Place && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.ArenaType != PlayerArenaType.PlayerArenaNone)
        num ^= this.ArenaType.GetHashCode();
      if (this.Place != 0)
        num ^= this.Place.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.ArenaType != PlayerArenaType.PlayerArenaNone)
      {
        output.WriteRawTag((byte) 8);
        output.WriteEnum((int) this.ArenaType);
      }
      if (this.Place != 0)
      {
        output.WriteRawTag((byte) 16);
        output.WriteInt32(this.Place);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.ArenaType != PlayerArenaType.PlayerArenaNone)
        num += 1 + CodedOutputStream.ComputeEnumSize((int) this.ArenaType);
      if (this.Place != 0)
        num += 1 + CodedOutputStream.ComputeInt32Size(this.Place);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(PlayerArenaStatus other)
    {
      if (other == null)
        return;
      if (other.ArenaType != PlayerArenaType.PlayerArenaNone)
        this.ArenaType = other.ArenaType;
      if (other.Place != 0)
        this.Place = other.Place;
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
            this.arenaType_ = (PlayerArenaType) input.ReadEnum();
            continue;
          case 16:
            this.Place = input.ReadInt32();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
