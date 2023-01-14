// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: NFDefine.proto

#ifndef GOOGLE_PROTOBUF_INCLUDED_NFDefine_2eproto
#define GOOGLE_PROTOBUF_INCLUDED_NFDefine_2eproto

#include <limits>
#include <string>

#include <google/protobuf/port_def.inc>
#if PROTOBUF_VERSION < 3011000
#error This file was generated by a newer version of protoc which is
#error incompatible with your Protocol Buffer headers. Please update
#error your headers.
#endif
#if 3011003 < PROTOBUF_MIN_PROTOC_VERSION
#error This file was generated by an older version of protoc which is
#error incompatible with your Protocol Buffer headers. Please
#error regenerate this file with a newer version of protoc.
#endif

#include <google/protobuf/port_undef.inc>
#include <google/protobuf/io/coded_stream.h>
#include <google/protobuf/arena.h>
#include <google/protobuf/arenastring.h>
#include <google/protobuf/generated_message_table_driven.h>
#include <google/protobuf/generated_message_util.h>
#include <google/protobuf/inlined_string_field.h>
#include <google/protobuf/metadata.h>
#include <google/protobuf/generated_message_reflection.h>
#include <google/protobuf/repeated_field.h>  // IWYU pragma: export
#include <google/protobuf/extension_set.h>  // IWYU pragma: export
#include <google/protobuf/generated_enum_reflection.h>
// @@protoc_insertion_point(includes)
#include <google/protobuf/port_def.inc>
#define PROTOBUF_INTERNAL_EXPORT_NFDefine_2eproto
PROTOBUF_NAMESPACE_OPEN
namespace internal {
class AnyMetadata;
}  // namespace internal
PROTOBUF_NAMESPACE_CLOSE

// Internal implementation detail -- do not use these members.
struct TableStruct_NFDefine_2eproto {
  static const ::PROTOBUF_NAMESPACE_ID::internal::ParseTableField entries[]
    PROTOBUF_SECTION_VARIABLE(protodesc_cold);
  static const ::PROTOBUF_NAMESPACE_ID::internal::AuxillaryParseTableField aux[]
    PROTOBUF_SECTION_VARIABLE(protodesc_cold);
  static const ::PROTOBUF_NAMESPACE_ID::internal::ParseTable schema[1]
    PROTOBUF_SECTION_VARIABLE(protodesc_cold);
  static const ::PROTOBUF_NAMESPACE_ID::internal::FieldMetadata field_metadata[];
  static const ::PROTOBUF_NAMESPACE_ID::internal::SerializationTable serialization_table[];
  static const ::PROTOBUF_NAMESPACE_ID::uint32 offsets[];
};
extern const ::PROTOBUF_NAMESPACE_ID::internal::DescriptorTable descriptor_table_NFDefine_2eproto;
PROTOBUF_NAMESPACE_OPEN
PROTOBUF_NAMESPACE_CLOSE
namespace NFMsg {

enum EGameEventCode : int {
  SUCCESS = 0,
  UNKOWN_ERROR = 1,
  ACCOUNT_EXIST = 2,
  ACCOUNTPWD_INVALID = 3,
  ACCOUNT_USING = 4,
  ACCOUNT_LOCKED = 5,
  ACCOUNT_LOGIN_SUCCESS = 6,
  VERIFY_KEY_SUCCESS = 7,
  VERIFY_KEY_FAIL = 8,
  SELECTSERVER_SUCCESS = 9,
  SELECTSERVER_FAIL = 10,
  CHARACTER_EXIST = 110,
  SVRZONEID_INVALID = 111,
  CHARACTER_NUMOUT = 112,
  CHARACTER_INVALID = 113,
  CHARACTER_NOTEXIST = 114,
  CHARACTER_USING = 115,
  CHARACTER_LOCKED = 116,
  ZONE_OVERLOAD = 117,
  NOT_ONLINE = 118,
  INSUFFICIENT_DIAMOND = 200,
  INSUFFICIENT_GOLD = 201,
  INSUFFICIENT_SP = 202,
  EGameEventCode_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  EGameEventCode_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool EGameEventCode_IsValid(int value);
constexpr EGameEventCode EGameEventCode_MIN = SUCCESS;
constexpr EGameEventCode EGameEventCode_MAX = INSUFFICIENT_SP;
constexpr int EGameEventCode_ARRAYSIZE = EGameEventCode_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EGameEventCode_descriptor();
template<typename T>
inline const std::string& EGameEventCode_Name(T enum_t_value) {
  static_assert(::std::is_same<T, EGameEventCode>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function EGameEventCode_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    EGameEventCode_descriptor(), enum_t_value);
}
inline bool EGameEventCode_Parse(
    const std::string& name, EGameEventCode* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<EGameEventCode>(
    EGameEventCode_descriptor(), name, value);
}
enum EGameMsgID : int {
  UNKNOW = 0,
  EVENT_RESULT = 1,
  EVENT_TRANSPORT = 2,
  CLOSE_SOCKET = 3,
  WTM_WORLD_REGISTERED = 10,
  WTM_WORLD_UNREGISTERED = 11,
  WTM_WORLD_REFRESH = 12,
  LTM_LOGIN_REGISTERED = 20,
  LTM_LOGIN_UNREGISTERED = 21,
  LTM_LOGIN_REFRESH = 22,
  PTWG_PROXY_REGISTERED = 30,
  PTWG_PROXY_UNREGISTERED = 31,
  PTWG_PROXY_REFRESH = 32,
  GTW_GAME_REGISTERED = 40,
  GTW_GAME_UNREGISTERED = 41,
  GTW_GAME_REFRESH = 42,
  DTW_DB_REGISTERED = 60,
  DTW_DB_UNREGISTERED = 61,
  DTW_DB_REFRESH = 62,
  STS_NET_INFO = 70,
  REQ_LAG_TEST = 80,
  ACK_GATE_LAG_TEST = 81,
  ACK_GAME_LAG_TEST = 82,
  STS_SERVER_REPORT = 90,
  STS_HEART_BEAT = 100,
  REQ_LOGIN = 101,
  ACK_LOGIN = 102,
  REQ_LOGOUT = 103,
  REQ_WORLD_LIST = 110,
  ACK_WORLD_LIST = 111,
  REQ_CONNECT_WORLD = 112,
  ACK_CONNECT_WORLD = 113,
  REQ_KICKED_FROM_WORLD = 114,
  REQ_CONNECT_KEY = 120,
  ACK_CONNECT_KEY = 122,
  REQ_SELECT_SERVER = 130,
  ACK_SELECT_SERVER = 131,
  REQ_ROLE_LIST = 132,
  ACK_ROLE_LIST = 133,
  REQ_CREATE_ROLE = 134,
  REQ_DELETE_ROLE = 135,
  REQ_RECOVER_ROLE = 136,
  REQ_LOAD_ROLE_DATA = 140,
  ACK_LOAD_ROLE_DATA = 141,
  REQ_SAVE_ROLE_DATA = 142,
  ACK_SAVE_ROLE_DATA = 143,
  REQ_ENTER_GAME = 150,
  ACK_ENTER_GAME = 151,
  REQ_LEAVE_GAME = 152,
  ACK_LEAVE_GAME = 153,
  REQ_SWAP_SCENE = 155,
  ACK_SWAP_SCENE = 156,
  REQ_SWAP_HOME_SCENE = 157,
  ACK_SWAP_HOME_SCENE = 158,
  REQ_ENTER_GAME_FINISH = 159,
  ACK_ENTER_GAME_FINISH = 160,
  ACK_OBJECT_ENTRY = 200,
  ACK_OBJECT_LEAVE = 201,
  ACK_OBJECT_PROPERTY_ENTRY = 202,
  ACK_OBJECT_RECORD_ENTRY = 203,
  ACK_PROPERTY_INT = 210,
  ACK_PROPERTY_FLOAT = 211,
  ACK_PROPERTY_STRING = 212,
  ACK_PROPERTY_OBJECT = 214,
  ACK_PROPERTY_VECTOR2 = 215,
  ACK_PROPERTY_VECTOR3 = 216,
  ACK_PROPERTY_CLEAR = 217,
  ACK_ADD_ROW = 220,
  ACK_REMOVE_ROW = 221,
  ACK_SWAP_ROW = 222,
  ACK_RECORD_INT = 223,
  ACK_RECORD_FLOAT = 224,
  ACK_RECORD_STRING = 226,
  ACK_RECORD_OBJECT = 227,
  ACK_RECORD_VECTOR2 = 228,
  ACK_RECORD_VECTOR3 = 229,
  ACK_RECORD_CLEAR = 250,
  ACK_RECORD_SORT = 251,
  ACK_DATA_FINISHED = 260,
  REQ_MOVE = 300,
  ACK_MOVE = 301,
  REQ_CHAT = 350,
  ACK_CHAT = 351,
  REQ_SKILL_OBJECTX = 400,
  ACK_SKILL_OBJECTX = 401,
  REQ_SKILL_POS = 402,
  ACK_SKILL_POS = 403,
  ACK_ONLINE_NOTIFY = 600,
  ACK_OFFLINE_NOTIFY = 601,
  CREATE_ROOM = 1000,
  BATTLE_CLIENT_CMD = 1001,
  BATTLE_ATTACK_CMD = 1002,
  BATTLE_PERFORM_CMD = 1003,
  EGameMsgID_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  EGameMsgID_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool EGameMsgID_IsValid(int value);
constexpr EGameMsgID EGameMsgID_MIN = UNKNOW;
constexpr EGameMsgID EGameMsgID_MAX = BATTLE_PERFORM_CMD;
constexpr int EGameMsgID_ARRAYSIZE = EGameMsgID_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EGameMsgID_descriptor();
template<typename T>
inline const std::string& EGameMsgID_Name(T enum_t_value) {
  static_assert(::std::is_same<T, EGameMsgID>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function EGameMsgID_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    EGameMsgID_descriptor(), enum_t_value);
}
inline bool EGameMsgID_Parse(
    const std::string& name, EGameMsgID* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<EGameMsgID>(
    EGameMsgID_descriptor(), name, value);
}
enum EItemType : int {
  EIT_EQUIP = 0,
  EIT_GEM = 1,
  EIT_SUPPLY = 2,
  EIT_SCROLL = 3,
  EItemType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  EItemType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool EItemType_IsValid(int value);
constexpr EItemType EItemType_MIN = EIT_EQUIP;
constexpr EItemType EItemType_MAX = EIT_SCROLL;
constexpr int EItemType_ARRAYSIZE = EItemType_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EItemType_descriptor();
template<typename T>
inline const std::string& EItemType_Name(T enum_t_value) {
  static_assert(::std::is_same<T, EItemType>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function EItemType_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    EItemType_descriptor(), enum_t_value);
}
inline bool EItemType_Parse(
    const std::string& name, EItemType* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<EItemType>(
    EItemType_descriptor(), name, value);
}
enum ESkillType : int {
  BRIEF_SINGLE_SKILL = 0,
  BRIEF_GROUP_SKILL = 1,
  BULLET_SINGLE_SKILL = 2,
  BULLET_REBOUND_SKILL = 3,
  BULLET_TARGET_BOMB_SKILL = 4,
  BULLET_POS_BOMB_SKILL = 5,
  FUNC_SKILL = 6,
  ESkillType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  ESkillType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool ESkillType_IsValid(int value);
constexpr ESkillType ESkillType_MIN = BRIEF_SINGLE_SKILL;
constexpr ESkillType ESkillType_MAX = FUNC_SKILL;
constexpr int ESkillType_ARRAYSIZE = ESkillType_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ESkillType_descriptor();
template<typename T>
inline const std::string& ESkillType_Name(T enum_t_value) {
  static_assert(::std::is_same<T, ESkillType>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function ESkillType_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    ESkillType_descriptor(), enum_t_value);
}
inline bool ESkillType_Parse(
    const std::string& name, ESkillType* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ESkillType>(
    ESkillType_descriptor(), name, value);
}
enum ESceneType : int {
  NORMAL_SCENE = 0,
  SINGLE_CLONE_SCENE = 1,
  MULTI_CLONE_SCENE = 2,
  ESceneType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  ESceneType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool ESceneType_IsValid(int value);
constexpr ESceneType ESceneType_MIN = NORMAL_SCENE;
constexpr ESceneType ESceneType_MAX = MULTI_CLONE_SCENE;
constexpr int ESceneType_ARRAYSIZE = ESceneType_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ESceneType_descriptor();
template<typename T>
inline const std::string& ESceneType_Name(T enum_t_value) {
  static_assert(::std::is_same<T, ESceneType>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function ESceneType_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    ESceneType_descriptor(), enum_t_value);
}
inline bool ESceneType_Parse(
    const std::string& name, ESceneType* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ESceneType>(
    ESceneType_descriptor(), name, value);
}
enum ENPCType : int {
  NORMAL_NPC = 0,
  HERO_NPC = 1,
  TURRET_NPC = 2,
  FUNC_NPC = 3,
  ENPCType_INT_MIN_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::min(),
  ENPCType_INT_MAX_SENTINEL_DO_NOT_USE_ = std::numeric_limits<::PROTOBUF_NAMESPACE_ID::int32>::max()
};
bool ENPCType_IsValid(int value);
constexpr ENPCType ENPCType_MIN = NORMAL_NPC;
constexpr ENPCType ENPCType_MAX = FUNC_NPC;
constexpr int ENPCType_ARRAYSIZE = ENPCType_MAX + 1;

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ENPCType_descriptor();
template<typename T>
inline const std::string& ENPCType_Name(T enum_t_value) {
  static_assert(::std::is_same<T, ENPCType>::value ||
    ::std::is_integral<T>::value,
    "Incorrect type passed to function ENPCType_Name.");
  return ::PROTOBUF_NAMESPACE_ID::internal::NameOfEnum(
    ENPCType_descriptor(), enum_t_value);
}
inline bool ENPCType_Parse(
    const std::string& name, ENPCType* value) {
  return ::PROTOBUF_NAMESPACE_ID::internal::ParseNamedEnum<ENPCType>(
    ENPCType_descriptor(), name, value);
}
// ===================================================================


// ===================================================================


// ===================================================================

#ifdef __GNUC__
  #pragma GCC diagnostic push
  #pragma GCC diagnostic ignored "-Wstrict-aliasing"
#endif  // __GNUC__
#ifdef __GNUC__
  #pragma GCC diagnostic pop
#endif  // __GNUC__

// @@protoc_insertion_point(namespace_scope)

}  // namespace NFMsg

PROTOBUF_NAMESPACE_OPEN

template <> struct is_proto_enum< ::NFMsg::EGameEventCode> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::EGameEventCode>() {
  return ::NFMsg::EGameEventCode_descriptor();
}
template <> struct is_proto_enum< ::NFMsg::EGameMsgID> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::EGameMsgID>() {
  return ::NFMsg::EGameMsgID_descriptor();
}
template <> struct is_proto_enum< ::NFMsg::EItemType> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::EItemType>() {
  return ::NFMsg::EItemType_descriptor();
}
template <> struct is_proto_enum< ::NFMsg::ESkillType> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::ESkillType>() {
  return ::NFMsg::ESkillType_descriptor();
}
template <> struct is_proto_enum< ::NFMsg::ESceneType> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::ESceneType>() {
  return ::NFMsg::ESceneType_descriptor();
}
template <> struct is_proto_enum< ::NFMsg::ENPCType> : ::std::true_type {};
template <>
inline const EnumDescriptor* GetEnumDescriptor< ::NFMsg::ENPCType>() {
  return ::NFMsg::ENPCType_descriptor();
}

PROTOBUF_NAMESPACE_CLOSE

// @@protoc_insertion_point(global_scope)

#include <google/protobuf/port_undef.inc>
#endif  // GOOGLE_PROTOBUF_INCLUDED_GOOGLE_PROTOBUF_INCLUDED_NFDefine_2eproto
