// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.DevicePreferences
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class DevicePreferences : IMessage<DevicePreferences>, IMessage, IEquatable<DevicePreferences>, IDeepCloneable<DevicePreferences>
  {
    private static readonly MessageParser<DevicePreferences> _parser = new MessageParser<DevicePreferences>((Func<DevicePreferences>) (() => new DevicePreferences()));
    private UnknownFieldSet _unknownFields;
    public const int PushnotesAllowedFieldNumber = 1;
    private bool pushnotesAllowed_;
    public const int MusicSettingFieldNumber = 2;
    private bool musicSetting_;
    public const int SfxSettingFieldNumber = 3;
    private bool sfxSetting_;
    public const int NetworkConnectionFieldNumber = 4;
    private string networkConnection_ = "";

    [DebuggerNonUserCode]
    public static MessageParser<DevicePreferences> Parser => DevicePreferences._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => AuthGuestRequestReflection.Descriptor.MessageTypes[1];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.pb\u003A\u003AGoogle\u002EProtobuf\u002EIMessage\u002EDescriptor => DevicePreferences.Descriptor;

    [DebuggerNonUserCode]
    public DevicePreferences()
    {
    }

    [DebuggerNonUserCode]
    public DevicePreferences(DevicePreferences other)
      : this()
    {
      this.pushnotesAllowed_ = other.pushnotesAllowed_;
      this.musicSetting_ = other.musicSetting_;
      this.sfxSetting_ = other.sfxSetting_;
      this.networkConnection_ = other.networkConnection_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public DevicePreferences Clone() => new DevicePreferences(this);

    [DebuggerNonUserCode]
    public bool PushnotesAllowed
    {
      get => this.pushnotesAllowed_;
      set => this.pushnotesAllowed_ = value;
    }

    [DebuggerNonUserCode]
    public bool MusicSetting
    {
      get => this.musicSetting_;
      set => this.musicSetting_ = value;
    }

    [DebuggerNonUserCode]
    public bool SfxSetting
    {
      get => this.sfxSetting_;
      set => this.sfxSetting_ = value;
    }

    [DebuggerNonUserCode]
    public string NetworkConnection
    {
      get => this.networkConnection_;
      set => this.networkConnection_ = ProtoPreconditions.CheckNotNull<string>(value, nameof (value));
    }

    [DebuggerNonUserCode]
    public override bool Equals(object other) => this.Equals(other as DevicePreferences);

    [DebuggerNonUserCode]
    public bool Equals(DevicePreferences other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return this.PushnotesAllowed == other.PushnotesAllowed && this.MusicSetting == other.MusicSetting && (this.SfxSetting == other.SfxSetting && !(this.NetworkConnection != other.NetworkConnection)) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num1 = 1;
      bool flag;
      if (this.PushnotesAllowed)
      {
        int num2 = num1;
        flag = this.PushnotesAllowed;
        int hashCode = flag.GetHashCode();
        num1 = num2 ^ hashCode;
      }
      if (this.MusicSetting)
      {
        int num2 = num1;
        flag = this.MusicSetting;
        int hashCode = flag.GetHashCode();
        num1 = num2 ^ hashCode;
      }
      if (this.SfxSetting)
      {
        int num2 = num1;
        flag = this.SfxSetting;
        int hashCode = flag.GetHashCode();
        num1 = num2 ^ hashCode;
      }
      if (this.NetworkConnection.Length != 0)
        num1 ^= this.NetworkConnection.GetHashCode();
      if (this._unknownFields != null)
        num1 ^= this._unknownFields.GetHashCode();
      return num1;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.PushnotesAllowed)
      {
        output.WriteRawTag((byte) 8);
        output.WriteBool(this.PushnotesAllowed);
      }
      if (this.MusicSetting)
      {
        output.WriteRawTag((byte) 16);
        output.WriteBool(this.MusicSetting);
      }
      if (this.SfxSetting)
      {
        output.WriteRawTag((byte) 24);
        output.WriteBool(this.SfxSetting);
      }
      if (this.NetworkConnection.Length != 0)
      {
        output.WriteRawTag((byte) 34);
        output.WriteString(this.NetworkConnection);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.PushnotesAllowed)
        num += 2;
      if (this.MusicSetting)
        num += 2;
      if (this.SfxSetting)
        num += 2;
      if (this.NetworkConnection.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.NetworkConnection);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(DevicePreferences other)
    {
      if (other == null)
        return;
      if (other.PushnotesAllowed)
        this.PushnotesAllowed = other.PushnotesAllowed;
      if (other.MusicSetting)
        this.MusicSetting = other.MusicSetting;
      if (other.SfxSetting)
        this.SfxSetting = other.SfxSetting;
      if (other.NetworkConnection.Length != 0)
        this.NetworkConnection = other.NetworkConnection;
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
            this.PushnotesAllowed = input.ReadBool();
            continue;
          case 16:
            this.MusicSetting = input.ReadBool();
            continue;
          case 24:
            this.SfxSetting = input.ReadBool();
            continue;
          case 34:
            this.NetworkConnection = input.ReadString();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
