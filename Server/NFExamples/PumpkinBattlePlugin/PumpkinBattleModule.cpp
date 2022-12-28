
#include "PumpkinBattleModule.h"
#include "NFComm/NFMessageDefine/NFProtocolDefine.hpp"

bool PumpkinBattleModule::Init()
{
	m_pNetModule = pPluginManager->FindModule<NFINetModule>();
	m_pKernelModule = pPluginManager->FindModule<NFIKernelModule>();
	m_pLogModule = pPluginManager->FindModule<NFILogModule>();
	m_pGameServerNet_ServerModule = pPluginManager->FindModule<NFIGameServerNet_ServerModule>();

	return true;
}

bool PumpkinBattleModule::AfterInit()
{
	m_pNetModule->AddReceiveCallBack(NFMsg::BATTLE_CLIENT_CMD, this, &PumpkinBattleModule::OnBattleClientCmd);

	return true;
}

bool PumpkinBattleModule::Shut()
{

	return true;
}

bool PumpkinBattleModule::Execute()
{
	return true;
}

void PumpkinBattleModule::OnBattleClientCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len)
{
	CLIENT_MSG_PROCESS(msgID, msg, len, NFMsg::C2G_MoveCmd);

	
}