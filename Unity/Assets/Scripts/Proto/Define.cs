// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: define.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Pumpkin {

  /// <summary>Holder for reflection information generated from define.proto</summary>
  public static partial class DefineReflection {

    #region Descriptor
    /// <summary>File descriptor for define.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DefineReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CgxkZWZpbmUucHJvdG8SB1B1bXBraW4qKAoJR2FtZU1zZ0lEEgoKBlVua25v",
            "dxAAEg8KCkNyZWF0ZVJvb20Q6AdiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(new[] {typeof(global::Pumpkin.GameMsgID), }, null, null));
    }
    #endregion

  }
  #region Enums
  public enum GameMsgID {
    [pbr::OriginalName("Unknow")] Unknow = 0,
    /// <summary>
    /// NoahGameFrame 会占用一部分
    /// </summary>
    [pbr::OriginalName("CreateRoom")] CreateRoom = 1000,
  }

  #endregion

}

#endregion Designer generated code