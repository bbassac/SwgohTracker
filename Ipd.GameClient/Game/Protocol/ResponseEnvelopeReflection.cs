﻿// Decompiled with JetBrains decompiler
// Type: Ipd.Game.Protocol.ResponseEnvelopeReflection
// Assembly: Ipd.GameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3F1382BE-46D0-4B2A-9C39-C327EEFCB21C
// Assembly location: D:\workspaces\SwgohTracker\ImgTraker\archive\Ipd.GameClient.dll

using Google.Protobuf;
using Google.Protobuf.Reflection;
using System;

namespace Ipd.Game.Protocol
{
  public static class ResponseEnvelopeReflection
  {
    private static FileDescriptor descriptor = FileDescriptor.FromGeneratedCode(Convert.FromBase64String("ChZSZXNwb25zZUVudmVsb3BlLnByb3RvEhFpcGQuZ2FtZS5wcm90b2NvbCJM" + "Cg5EeW5hbWljTWVzc2FnZRIKCgJpZBgBIAEoCRIMCgR0eXBlGAIgASgJEgwK" + "BGRhdGEYAyABKAwSEgoKbWVzc2FnZV9pZBgEIAEoBSLwAgoQUmVzcG9uc2VF" + "bnZlbG9wZRIWCg5jb3JyZWxhdGlvbl9pZBgBIAEoBRIbChNjdXJyZW50X3Nl" + "cnZlcl90aW1lGAIgASgDEg8KB3BheWxvYWQYBCABKAwSLQoEY29kZRgFIAEo" + "DjIfLmlwZC5nYW1lLnByb3RvY29sLlJlc3BvbnNlQ29kZRIPCgdtZXNzYWdl" + "GAYgASgJEjwKEGNvbnRlbnRfZW5jb2RpbmcYByABKA4yIi5pcGQuZ2FtZS5w" + "cm90b2NvbC5Db250ZW50RW5jb2RpbmcSEwoLc3RhY2tfdHJhY2UYCCABKAkS" + "OgoPZHluYW1pY19tZXNzYWdlGAkgAygLMiEuaXBkLmdhbWUucHJvdG9jb2wu" + "RHluYW1pY01lc3NhZ2USGwoTbWFpbnRlbmFuY2VfbWVzc2FnZRgKIAEoCRIY" + "ChBtYWludGVuYW5jZV9saW5rGAsgASgJEhAKCHN1Yl9jb2RlGAwgASgFKkYK" + "D0NvbnRlbnRFbmNvZGluZxIaChZERUZBVUxUQ09OVEVOVEVOQ09ESU5HEAAS" + "FwoTR1pJUENPTlRFTlRFTkNPRElORxABKuwECgxSZXNwb25zZUNvZGUSCAoE" + "Tk9ORRAAEgYKAk9LEAESCQoFRVJST1IQAhIPCgtTRVJWRVJFUlJPUhADEhIK" + "DlNFU1NJT05FWFBJUkVEEAQSDgoKQVVUSEZBSUxFRBAFEhAKDFJBVEVFWENF" + "RURFRBAGEhUKEVNFUlZFUlVOQVZBSUxBQkxFEAcSEgoOSU5WQUxJRFJFUVVF" + "U1QQCBIPCgtJTlZBTElEREFUQRAJEh8KG0xFQURFUkJPQVJETUFUQ0hNQUtJ" + "TkdFUlJPUhAKEhAKDFVOQVVUSE9SSVpFRBALEg0KCVNVU1BFTkRFRBAMEhAK" + "DFNFUlZFUk9VVEFHRRANEhYKEk5FVFdPUktVTkFWQUlMQUJMRRAUEhAKDFNF" + "UVVFTkNFSElHSBAeEg8KC1NFUVVFTkNFTE9XEB8SEgoOUkVDT1JETk9URk9V" + "TkQQIBIRCg1FVkVOVE5PVEZPVU5EECESGQoVSU5TVUZGSUNJRU5UUkVTT1VS" + "Q0VTECgSGAoUSU5WQUxJRENMSUVOVFZFUlNJT04QMhIWChJGT1JDRUNMSUVO" + "VFJFU1RBUlQQMxIWChJJTkNPTVBBVElCTEVERVZJQ0UQNBISCg5BQ0NPVU5U" + "VVBEQVRFRBA1EhIKDklOVkFMSURSRUNFSVBUEDwSEgoOUEFZTUVOVFBFTkRJ" + "TkcQPRIUChBPUFBPTkVOVElOQkFUVExFEEcSDwoLVU5ERVJBVFRBQ0sQSBIV" + "ChFPUFBPTkVOVERBVEFTVEFMRRBJEhIKDkJBVFRMRVRJTUVET1VUEEoSEwoP" + "UExBWUVSUkFOS1NUQUxFEEtiBnByb3RvMw=="), new FileDescriptor[0], new GeneratedClrTypeInfo(new System.Type[2]
    {
      typeof (ContentEncoding),
      typeof (ResponseCode)
    }, new GeneratedClrTypeInfo[2]
    {
      new GeneratedClrTypeInfo(typeof (DynamicMessage), (MessageParser) DynamicMessage.Parser, new string[4]
      {
        "Id",
        "Type",
        "Data",
        "MessageId"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null),
      new GeneratedClrTypeInfo(typeof (ResponseEnvelope), (MessageParser) ResponseEnvelope.Parser, new string[11]
      {
        "CorrelationId",
        "CurrentServerTime",
        "Payload",
        "Code",
        "Message",
        "ContentEncoding",
        "StackTrace",
        "DynamicMessage",
        "MaintenanceMessage",
        "MaintenanceLink",
        "SubCode"
      }, (string[]) null, (System.Type[]) null, (GeneratedClrTypeInfo[]) null)
    }));

    public static FileDescriptor Descriptor => ResponseEnvelopeReflection.descriptor;
  }
}
