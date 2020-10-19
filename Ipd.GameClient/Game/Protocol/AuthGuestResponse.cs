// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.AuthGuestResponse
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;
using System.Diagnostics;

namespace Ipd.Game.Protocol
{
  public sealed class AuthGuestResponse : IMessage<AuthGuestResponse>, IMessage, IEquatable<AuthGuestResponse>, IDeepCloneable<AuthGuestResponse>
  {
    private static readonly MessageParser<AuthGuestResponse> _parser = new MessageParser<AuthGuestResponse>((Func<AuthGuestResponse>) (() => new AuthGuestResponse()));
    private UnknownFieldSet _unknownFields;
    public const int AuthIdFieldNumber = 1;
    private string authId_ = "";
    public const int AuthTokenFieldNumber = 2;
    private string authToken_ = "";

    [DebuggerNonUserCode]
    public static MessageParser<AuthGuestResponse> Parser => AuthGuestResponse._parser;

    [DebuggerNonUserCode]
    public static MessageDescriptor Descriptor => AuthGuestResponseReflection.Descriptor.MessageTypes[0];

    [DebuggerNonUserCode]
    MessageDescriptor IMessage.Descriptor => ResponseEnvelope.Descriptor;

        [DebuggerNonUserCode]
    public AuthGuestResponse()
    {
    }

    [DebuggerNonUserCode]
    public AuthGuestResponse(AuthGuestResponse other)
      : this()
    {
      this.authId_ = other.authId_;
      this.authToken_ = other.authToken_;
      this._unknownFields = UnknownFieldSet.Clone(other._unknownFields);
    }

    [DebuggerNonUserCode]
    public AuthGuestResponse Clone() => new AuthGuestResponse(this);

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
    public override bool Equals(object other) => this.Equals(other as AuthGuestResponse);

    [DebuggerNonUserCode]
    public bool Equals(AuthGuestResponse other)
    {
      if (other == null)
        return false;
      if (other == this)
        return true;
      return !(this.AuthId != other.AuthId) && !(this.AuthToken != other.AuthToken) && object.Equals((object) this._unknownFields, (object) other._unknownFields);
    }

    [DebuggerNonUserCode]
    public override int GetHashCode()
    {
      int num = 1;
      if (this.AuthId.Length != 0)
        num ^= this.AuthId.GetHashCode();
      if (this.AuthToken.Length != 0)
        num ^= this.AuthToken.GetHashCode();
      if (this._unknownFields != null)
        num ^= this._unknownFields.GetHashCode();
      return num;
    }

    [DebuggerNonUserCode]
    public override string ToString() => JsonFormatter.ToDiagnosticString((IMessage) this);

    [DebuggerNonUserCode]
    public void WriteTo(CodedOutputStream output)
    {
      if (this.AuthId.Length != 0)
      {
        output.WriteRawTag((byte) 10);
        output.WriteString(this.AuthId);
      }
      if (this.AuthToken.Length != 0)
      {
        output.WriteRawTag((byte) 18);
        output.WriteString(this.AuthToken);
      }
      if (this._unknownFields == null)
        return;
      this._unknownFields.WriteTo(output);
    }

    [DebuggerNonUserCode]
    public int CalculateSize()
    {
      int num = 0;
      if (this.AuthId.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.AuthId);
      if (this.AuthToken.Length != 0)
        num += 1 + CodedOutputStream.ComputeStringSize(this.AuthToken);
      if (this._unknownFields != null)
        num += this._unknownFields.CalculateSize();
      return num;
    }

    [DebuggerNonUserCode]
    public void MergeFrom(AuthGuestResponse other)
    {
      if (other == null)
        return;
      if (other.AuthId.Length != 0)
        this.AuthId = other.AuthId;
      if (other.AuthToken.Length != 0)
        this.AuthToken = other.AuthToken;
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
            this.AuthId = input.ReadString();
            continue;
          case 18:
            this.AuthToken = input.ReadString();
            continue;
          default:
            this._unknownFields = UnknownFieldSet.MergeFieldFrom(this._unknownFields, input);
            continue;
        }
      }
    }
  }
}
