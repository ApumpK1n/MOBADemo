// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: NFDefine.proto

#include "NFDefine.pb.h"

#include <algorithm>

#include <google/protobuf/io/coded_stream.h>
#include <google/protobuf/extension_set.h>
#include <google/protobuf/wire_format_lite.h>
#include <google/protobuf/descriptor.h>
#include <google/protobuf/generated_message_reflection.h>
#include <google/protobuf/reflection_ops.h>
#include <google/protobuf/wire_format.h>
// @@protoc_insertion_point(includes)
#include <google/protobuf/port_def.inc>
namespace NFMsg {
}  // namespace NFMsg
static constexpr ::PROTOBUF_NAMESPACE_ID::Metadata* file_level_metadata_NFDefine_2eproto = nullptr;
static const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* file_level_enum_descriptors_NFDefine_2eproto[6];
static constexpr ::PROTOBUF_NAMESPACE_ID::ServiceDescriptor const** file_level_service_descriptors_NFDefine_2eproto = nullptr;
const ::PROTOBUF_NAMESPACE_ID::uint32 TableStruct_NFDefine_2eproto::offsets[1] = {};
static constexpr ::PROTOBUF_NAMESPACE_ID::internal::MigrationSchema* schemas = nullptr;
static constexpr ::PROTOBUF_NAMESPACE_ID::Message* const* file_default_instances = nullptr;

const char descriptor_table_protodef_NFDefine_2eproto[] PROTOBUF_SECTION_VARIABLE(protodesc_cold) =
  "\n\016NFDefine.proto\022\005NFMsg*\202\004\n\016EGameEventCo"
  "de\022\013\n\007SUCCESS\020\000\022\020\n\014UNKOWN_ERROR\020\001\022\021\n\rACC"
  "OUNT_EXIST\020\002\022\026\n\022ACCOUNTPWD_INVALID\020\003\022\021\n\r"
  "ACCOUNT_USING\020\004\022\022\n\016ACCOUNT_LOCKED\020\005\022\031\n\025A"
  "CCOUNT_LOGIN_SUCCESS\020\006\022\026\n\022VERIFY_KEY_SUC"
  "CESS\020\007\022\023\n\017VERIFY_KEY_FAIL\020\010\022\030\n\024SELECTSER"
  "VER_SUCCESS\020\t\022\025\n\021SELECTSERVER_FAIL\020\n\022\023\n\017"
  "CHARACTER_EXIST\020n\022\025\n\021SVRZONEID_INVALID\020o"
  "\022\024\n\020CHARACTER_NUMOUT\020p\022\025\n\021CHARACTER_INVA"
  "LID\020q\022\026\n\022CHARACTER_NOTEXIST\020r\022\023\n\017CHARACT"
  "ER_USING\020s\022\024\n\020CHARACTER_LOCKED\020t\022\021\n\rZONE"
  "_OVERLOAD\020u\022\016\n\nNOT_ONLINE\020v\022\031\n\024INSUFFICI"
  "ENT_DIAMOND\020\310\001\022\026\n\021INSUFFICIENT_GOLD\020\311\001\022\024"
  "\n\017INSUFFICIENT_SP\020\312\001*\304\020\n\nEGameMsgID\022\n\n\006U"
  "NKNOW\020\000\022\020\n\014EVENT_RESULT\020\001\022\023\n\017EVENT_TRANS"
  "PORT\020\002\022\020\n\014CLOSE_SOCKET\020\003\022\030\n\024WTM_WORLD_RE"
  "GISTERED\020\n\022\032\n\026WTM_WORLD_UNREGISTERED\020\013\022\025"
  "\n\021WTM_WORLD_REFRESH\020\014\022\030\n\024LTM_LOGIN_REGIS"
  "TERED\020\024\022\032\n\026LTM_LOGIN_UNREGISTERED\020\025\022\025\n\021L"
  "TM_LOGIN_REFRESH\020\026\022\031\n\025PTWG_PROXY_REGISTE"
  "RED\020\036\022\033\n\027PTWG_PROXY_UNREGISTERED\020\037\022\026\n\022PT"
  "WG_PROXY_REFRESH\020 \022\027\n\023GTW_GAME_REGISTERE"
  "D\020(\022\031\n\025GTW_GAME_UNREGISTERED\020)\022\024\n\020GTW_GA"
  "ME_REFRESH\020*\022\025\n\021DTW_DB_REGISTERED\020<\022\027\n\023D"
  "TW_DB_UNREGISTERED\020=\022\022\n\016DTW_DB_REFRESH\020>"
  "\022\020\n\014STS_NET_INFO\020F\022\020\n\014REQ_LAG_TEST\020P\022\025\n\021"
  "ACK_GATE_LAG_TEST\020Q\022\025\n\021ACK_GAME_LAG_TEST"
  "\020R\022\025\n\021STS_SERVER_REPORT\020Z\022\022\n\016STS_HEART_B"
  "EAT\020d\022\r\n\tREQ_LOGIN\020e\022\r\n\tACK_LOGIN\020f\022\016\n\nR"
  "EQ_LOGOUT\020g\022\022\n\016REQ_WORLD_LIST\020n\022\022\n\016ACK_W"
  "ORLD_LIST\020o\022\025\n\021REQ_CONNECT_WORLD\020p\022\025\n\021AC"
  "K_CONNECT_WORLD\020q\022\031\n\025REQ_KICKED_FROM_WOR"
  "LD\020r\022\023\n\017REQ_CONNECT_KEY\020x\022\023\n\017ACK_CONNECT"
  "_KEY\020z\022\026\n\021REQ_SELECT_SERVER\020\202\001\022\026\n\021ACK_SE"
  "LECT_SERVER\020\203\001\022\022\n\rREQ_ROLE_LIST\020\204\001\022\022\n\rAC"
  "K_ROLE_LIST\020\205\001\022\024\n\017REQ_CREATE_ROLE\020\206\001\022\024\n\017"
  "REQ_DELETE_ROLE\020\207\001\022\025\n\020REQ_RECOVER_ROLE\020\210"
  "\001\022\027\n\022REQ_LOAD_ROLE_DATA\020\214\001\022\027\n\022ACK_LOAD_R"
  "OLE_DATA\020\215\001\022\027\n\022REQ_SAVE_ROLE_DATA\020\216\001\022\027\n\022"
  "ACK_SAVE_ROLE_DATA\020\217\001\022\023\n\016REQ_ENTER_GAME\020"
  "\226\001\022\023\n\016ACK_ENTER_GAME\020\227\001\022\023\n\016REQ_LEAVE_GAM"
  "E\020\230\001\022\023\n\016ACK_LEAVE_GAME\020\231\001\022\023\n\016REQ_SWAP_SC"
  "ENE\020\233\001\022\023\n\016ACK_SWAP_SCENE\020\234\001\022\030\n\023REQ_SWAP_"
  "HOME_SCENE\020\235\001\022\030\n\023ACK_SWAP_HOME_SCENE\020\236\001\022"
  "\032\n\025REQ_ENTER_GAME_FINISH\020\237\001\022\032\n\025ACK_ENTER"
  "_GAME_FINISH\020\240\001\022\025\n\020ACK_OBJECT_ENTRY\020\310\001\022\025"
  "\n\020ACK_OBJECT_LEAVE\020\311\001\022\036\n\031ACK_OBJECT_PROP"
  "ERTY_ENTRY\020\312\001\022\034\n\027ACK_OBJECT_RECORD_ENTRY"
  "\020\313\001\022\025\n\020ACK_PROPERTY_INT\020\322\001\022\027\n\022ACK_PROPER"
  "TY_FLOAT\020\323\001\022\030\n\023ACK_PROPERTY_STRING\020\324\001\022\030\n"
  "\023ACK_PROPERTY_OBJECT\020\326\001\022\031\n\024ACK_PROPERTY_"
  "VECTOR2\020\327\001\022\031\n\024ACK_PROPERTY_VECTOR3\020\330\001\022\027\n"
  "\022ACK_PROPERTY_CLEAR\020\331\001\022\020\n\013ACK_ADD_ROW\020\334\001"
  "\022\023\n\016ACK_REMOVE_ROW\020\335\001\022\021\n\014ACK_SWAP_ROW\020\336\001"
  "\022\023\n\016ACK_RECORD_INT\020\337\001\022\025\n\020ACK_RECORD_FLOA"
  "T\020\340\001\022\026\n\021ACK_RECORD_STRING\020\342\001\022\026\n\021ACK_RECO"
  "RD_OBJECT\020\343\001\022\027\n\022ACK_RECORD_VECTOR2\020\344\001\022\027\n"
  "\022ACK_RECORD_VECTOR3\020\345\001\022\025\n\020ACK_RECORD_CLE"
  "AR\020\372\001\022\024\n\017ACK_RECORD_SORT\020\373\001\022\026\n\021ACK_DATA_"
  "FINISHED\020\204\002\022\r\n\010REQ_MOVE\020\254\002\022\r\n\010ACK_MOVE\020\255"
  "\002\022\r\n\010REQ_CHAT\020\336\002\022\r\n\010ACK_CHAT\020\337\002\022\026\n\021REQ_S"
  "KILL_OBJECTX\020\220\003\022\026\n\021ACK_SKILL_OBJECTX\020\221\003\022"
  "\022\n\rREQ_SKILL_POS\020\222\003\022\022\n\rACK_SKILL_POS\020\223\003\022"
  "\026\n\021ACK_ONLINE_NOTIFY\020\330\004\022\027\n\022ACK_OFFLINE_N"
  "OTIFY\020\331\004\022\020\n\013CREATE_ROOM\020\350\007\022\026\n\021BATTLE_CLI"
  "ENT_CMD\020\351\007\022\026\n\021BATTLE_ATTACK_CMD\020\352\007\022\027\n\022BA"
  "TTLE_PERFORM_CMD\020\353\007*G\n\tEItemType\022\r\n\tEIT_"
  "EQUIP\020\000\022\013\n\007EIT_GEM\020\001\022\016\n\nEIT_SUPPLY\020\002\022\016\n\n"
  "EIT_SCROLL\020\003*\267\001\n\nESkillType\022\026\n\022BRIEF_SIN"
  "GLE_SKILL\020\000\022\025\n\021BRIEF_GROUP_SKILL\020\001\022\027\n\023BU"
  "LLET_SINGLE_SKILL\020\002\022\030\n\024BULLET_REBOUND_SK"
  "ILL\020\003\022\034\n\030BULLET_TARGET_BOMB_SKILL\020\004\022\031\n\025B"
  "ULLET_POS_BOMB_SKILL\020\005\022\016\n\nFUNC_SKILL\020\006*M"
  "\n\nESceneType\022\020\n\014NORMAL_SCENE\020\000\022\026\n\022SINGLE"
  "_CLONE_SCENE\020\001\022\025\n\021MULTI_CLONE_SCENE\020\002*F\n"
  "\010ENPCType\022\016\n\nNORMAL_NPC\020\000\022\014\n\010HERO_NPC\020\001\022"
  "\016\n\nTURRET_NPC\020\002\022\014\n\010FUNC_NPC\020\003b\006proto3"
  ;
static const ::PROTOBUF_NAMESPACE_ID::internal::DescriptorTable*const descriptor_table_NFDefine_2eproto_deps[1] = {
};
static ::PROTOBUF_NAMESPACE_ID::internal::SCCInfoBase*const descriptor_table_NFDefine_2eproto_sccs[1] = {
};
static ::PROTOBUF_NAMESPACE_ID::internal::once_flag descriptor_table_NFDefine_2eproto_once;
static bool descriptor_table_NFDefine_2eproto_initialized = false;
const ::PROTOBUF_NAMESPACE_ID::internal::DescriptorTable descriptor_table_NFDefine_2eproto = {
  &descriptor_table_NFDefine_2eproto_initialized, descriptor_table_protodef_NFDefine_2eproto, "NFDefine.proto", 3077,
  &descriptor_table_NFDefine_2eproto_once, descriptor_table_NFDefine_2eproto_sccs, descriptor_table_NFDefine_2eproto_deps, 0, 0,
  schemas, file_default_instances, TableStruct_NFDefine_2eproto::offsets,
  file_level_metadata_NFDefine_2eproto, 0, file_level_enum_descriptors_NFDefine_2eproto, file_level_service_descriptors_NFDefine_2eproto,
};

// Force running AddDescriptors() at dynamic initialization time.
static bool dynamic_init_dummy_NFDefine_2eproto = (  ::PROTOBUF_NAMESPACE_ID::internal::AddDescriptors(&descriptor_table_NFDefine_2eproto), true);
namespace NFMsg {
const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EGameEventCode_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[0];
}
bool EGameEventCode_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
    case 6:
    case 7:
    case 8:
    case 9:
    case 10:
    case 110:
    case 111:
    case 112:
    case 113:
    case 114:
    case 115:
    case 116:
    case 117:
    case 118:
    case 200:
    case 201:
    case 202:
      return true;
    default:
      return false;
  }
}

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EGameMsgID_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[1];
}
bool EGameMsgID_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
    case 3:
    case 10:
    case 11:
    case 12:
    case 20:
    case 21:
    case 22:
    case 30:
    case 31:
    case 32:
    case 40:
    case 41:
    case 42:
    case 60:
    case 61:
    case 62:
    case 70:
    case 80:
    case 81:
    case 82:
    case 90:
    case 100:
    case 101:
    case 102:
    case 103:
    case 110:
    case 111:
    case 112:
    case 113:
    case 114:
    case 120:
    case 122:
    case 130:
    case 131:
    case 132:
    case 133:
    case 134:
    case 135:
    case 136:
    case 140:
    case 141:
    case 142:
    case 143:
    case 150:
    case 151:
    case 152:
    case 153:
    case 155:
    case 156:
    case 157:
    case 158:
    case 159:
    case 160:
    case 200:
    case 201:
    case 202:
    case 203:
    case 210:
    case 211:
    case 212:
    case 214:
    case 215:
    case 216:
    case 217:
    case 220:
    case 221:
    case 222:
    case 223:
    case 224:
    case 226:
    case 227:
    case 228:
    case 229:
    case 250:
    case 251:
    case 260:
    case 300:
    case 301:
    case 350:
    case 351:
    case 400:
    case 401:
    case 402:
    case 403:
    case 600:
    case 601:
    case 1000:
    case 1001:
    case 1002:
    case 1003:
      return true;
    default:
      return false;
  }
}

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* EItemType_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[2];
}
bool EItemType_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
    case 3:
      return true;
    default:
      return false;
  }
}

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ESkillType_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[3];
}
bool ESkillType_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
    case 3:
    case 4:
    case 5:
    case 6:
      return true;
    default:
      return false;
  }
}

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ESceneType_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[4];
}
bool ESceneType_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
      return true;
    default:
      return false;
  }
}

const ::PROTOBUF_NAMESPACE_ID::EnumDescriptor* ENPCType_descriptor() {
  ::PROTOBUF_NAMESPACE_ID::internal::AssignDescriptors(&descriptor_table_NFDefine_2eproto);
  return file_level_enum_descriptors_NFDefine_2eproto[5];
}
bool ENPCType_IsValid(int value) {
  switch (value) {
    case 0:
    case 1:
    case 2:
    case 3:
      return true;
    default:
      return false;
  }
}


// @@protoc_insertion_point(namespace_scope)
}  // namespace NFMsg
PROTOBUF_NAMESPACE_OPEN
PROTOBUF_NAMESPACE_CLOSE

// @@protoc_insertion_point(global_scope)
#include <google/protobuf/port_undef.inc>
