
#include "NFPumpkinBattleModule.h"
#include "NFComm/NFMessageDefine/NFMsgDefine.h"

bool NFPumpkinBattleModule::Init()
{
	m_pNetModule = pPluginManager->FindModule<NFINetModule>();
	return true;
}


bool NFPumpkinBattleModule::Shut()
{
	return true;
}

bool NFPumpkinBattleModule::Execute()
{
	return true;
}

bool NFPumpkinBattleModule::AfterInit()
{
	m_pNetModule->AddReceiveCallBack(NFMsg::BATTLE_ATTACK_CMD, this, &NFPumpkinBattleModule::OnAttackCmd);

	return true;
}

void NFPumpkinBattleModule::OnAttackCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len)
{
	NFGUID clientID;
}