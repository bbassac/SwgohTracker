﻿// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.RequestEnvelopeReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C5118B-19F9-4A1A-8B17-10E7D299DD18
// Assembly location: E:\workspace\Workspace-perso\app-tracker-swgoh\app\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class RequestEnvelopeReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChVSZXF1ZXN0RW52ZWxvcGUucHJvdG8SEWlwZC5nYW1lLnByb3RvY29sIuoF" + "Cg9SZXF1ZXN0RW52ZWxvcGUSFgoOY29ycmVsYXRpb25faWQYASABKAUSFAoM" + "c2VydmljZV9uYW1lGAQgASgJEhMKC21ldGhvZF9uYW1lGAUgASgJEg8KB3Bh" + "eWxvYWQYBiABKAwSDwoHYXV0aF9pZBgHIAEoCRISCgphdXRoX3Rva2VuGAgg" + "ASgJEhYKDmNsaWVudF92ZXJzaW9uGAkgASgFEiAKGGNsaWVudF9zdGFydHVw" + "X3RpbWVzdGFtcBgLIAEoAxIQCghwbGF0Zm9ybRgMIAEoCRIOCgZyZWdpb24Y" + "DSABKAkSHwoXY2xpZW50X2V4dGVybmFsX3ZlcnNpb24YDiABKAkSHwoXY2xp" + "ZW50X2ludGVybmFsX3ZlcnNpb24YDyABKAkSEgoKcmVxdWVzdF9pZBgQIAEo" + "CRI6Cg9hY2NlcHRfZW5jb2RpbmcYESABKA4yIS5pcGQuZ2FtZS5wcm90b2Nv" + "bC5BY2NlcHRFbmNvZGluZxIMCgRmbGFnGBIgAygJEhcKD3RlbGVtZXRyeV9l" + "dmVudBgTIAMoCRIbChNjdXJyZW50X2NsaWVudF90aW1lGBQgASgDEhkKEW5p" + "bWJsZV9zZXNzaW9uX2lkGBUgASgJEhAKCHRpbWV6b25lGBYgASgJEhgKEGZp" + "cm13YXJlX3ZlcnNpb24YFyABKAkSDwoHY2FycmllchgYIAEoCRIWCg5uZXR3" + "b3JrX2FjY2VzcxgZIAEoCRITCgtoYXJkd2FyZV9pZBgaIAEoCRIVCg1hZHZl" + "cnRpc2VyX2lkGBsgASgJEhEKCXZlbmRvcl9pZBgcIAEoCRISCgphbmRyb2lk" + "X2lkGB0gASgJEhcKD2phaWxicm9rZW5fZmxhZxgeIAEoBRITCgtwaXJhY3lf" + "ZmxhZxgfIAEoBRISCgpzeW5lcmd5X2lkGCAgASgJEhQKDGRldmljZV9tb2Rl" + "bBghIAEoCRIRCglkZXZpY2VfaWQYIiABKAkqQwoOQWNjZXB0RW5jb2RpbmcS" + "GQoVREVGQVVMVEFDQ0VQVEVOQ09ESU5HEAASFgoSR1pJUEFDQ0VQVEVOQ09E" + "SU5HEAFiBnByb3RvMw=="), new FileDescriptor[0], new GeneratedClrTypeInfo(new System.Type[1]
    {
      typeof (AcceptEncoding)
    }, new GeneratedClrTypeInfo[1]
    {
      new GeneratedClrTypeInfo(typeof (RequestEnvelope), (MessageParser) RequestEnvelope.Parser, new string[31]
      {
        "CorrelationId",
        "ServiceName",
        "MethodName",
        "Payload",
        "AuthId",
        "AuthToken",
        "ClientVersion",
        "ClientStartupTimestamp",
        "Platform",
        "Region",
        "ClientExternalVersion",
        "ClientInternalVersion",
        "RequestId",
        "AcceptEncoding",
        "Flag",
        "TelemetryEvent",
        "CurrentClientTime",
        "NimbleSessionId",
        "Timezone",
        "FirmwareVersion",
        "Carrier",
        "NetworkAccess",
        "HardwareId",
        "AdvertiserId",
        "VendorId",
        "AndroidId",
        "JailbrokenFlag",
        "PiracyFlag",
        "SynergyId",
        "DeviceModel",
        "DeviceId"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => RequestEnvelopeReflection.descriptor;
  }
}
