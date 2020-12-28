// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.PlayerPvpProfile
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class PlayerPvpProfile : IMessage<PlayerPvpProfile>, IMessage, IEquatable<PlayerPvpProfile>, IDeepCloneable<PlayerPvpProfile>
  {
    private static readonly MessageParser<PlayerPvpProfile> _parser = new MessageParser<PlayerPvpProfile>((Func<PlayerPvpProfile>) (() => new PlayerPvpProfile()));
    private UnknownFieldSet _unknownFields;
    public const int TabFieldNumber = 1;
    private PlayerProfileTab tab_;
    public const int RankFieldNumber = 2;
    private int rank_;
    public const int EventIdFieldNumber = 4;
    private string eventId_ = "";

    [DebuggerNonUserCode]
    public static MessageParser<PlayerPvpProfile> Parser => PlayerPvpProfile._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => SlimPlayerProfileReflection.Descriptor.MessageTypes[2];

    [DebuggerNonUserCode]
    MessageDescriptor Google.Protobuf.IMessage.Descriptor => PlayerPvpProfile.Descriptor;

    [DebuggerNonUserCode]
    public PlayerPvpProfile()
    {
    }

    [DebuggerNonUserCode]
    public PlayerPvpProfile(PlayerPvpProfile other)
      : this()
    {
      this.tab_ = other.tab_;
      this.rank_ = other.rank_;
      this.eventId_ = other.eventId_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public PlayerPvpProfile Clone() => new PlayerPvpProfile(this);

    [DebuggerNonUserCode]
    public PlayerProfileTab Tab
    {
      get => this.tab_;
      set => this.tab_ = value;
    }

    [DebuggerNonUserCode]
    public int Rank
    {
      get => this.rank_;
      set => this.rank_ = value;
    }

    [DebuggerNonUserCode]
    public string EventId
    {
      get => this.eventId_;
      set => this.eventId_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as PlayerPvpProfile);

    [DebuggerNonUserCode]
    public bool Equals(PlayerPvpProfile other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return this.Tab == other.Tab && this.Rank == other.Rank && !(this.EventId != other.EventId) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.Tab != PlayerProfileTab.Default)
        num ^= this.Tab.GetHashCode();
      if (this.Rank != 0)
        num ^= this.Rank.GetHashCode();
      if (this.EventId.Length != 0)
        num ^= this.EventId.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.Tab != PlayerProfileTab.Default)
      {
        output.WriteRawTag((byte) 8);
        output.WriteEnum((int) this.Tab);
      }
      if (this.Rank != 0)
      {
        output.WriteRawTag((byte) 16);
        output.WriteInt32(this.Rank);
      }
      if (this.EventId.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteString(this.EventId);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.Tab != PlayerProfileTab.Default)
        num += 1 + CodedOutputStream.ComputeEnumSize((int) this.Tab);
      if (this.Rank != 0)
        num += 1 + CodedOutputStream.ComputeInt32Size(this.Rank);
      if (this.EventId.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.EventId);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(PlayerPvpProfile other)
    {
      if (other == null)
        return;
      if (other.Tab != PlayerProfileTab.Default)
        this.Tab = other.Tab;
      if (other.Rank != 0)
        this.Rank = other.Rank;
      if (other.EventId.Length != 0)
        this.EventId = other.EventId;
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
            this.tab_ = (PlayerProfileTab) input.ReadEnum();
            continue;
          case 16:
            this.Rank = input.ReadInt32();
            continue;
          case 34:
            this.EventId = input.ReadString();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
