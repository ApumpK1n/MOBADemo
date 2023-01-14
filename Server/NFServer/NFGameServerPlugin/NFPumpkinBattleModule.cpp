
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

	NFMsg::C2G_AttackCmd xMsg;
	if (!m_pNetModule->ReceivePB(msgID, msg, len, xMsg, clientID))
	{
		return;
	}

	NetObject* pNetObject = m_pNetModule->GetNet()->GetNetObject(sockIndex);
	if (pNetObject) {
		NFMsg::G2C_AttackCmd xSendMsg;
		xSendMsg.mutable_framecmd()->CopyFrom(xMsg.framecmd());
		m_pNetModule->SendMsgPB(NFMsg::BATTLE_ATTACK_CMD, xSendMsg, sockIndex);
	}

}

void NFPumpkinBattleModule::OnPerformCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len)
{
	NFGUID clientID;

	NFMsg::C2G_PerformCmd xMsg;
	if (!m_pNetModule->ReceivePB(msgID, msg, len, xMsg, clientID))
	{
		return;
	}

	NetObject* pNetObject = m_pNetModule->GetNet()->GetNetObject(sockIndex);
	if (pNetObject) {
		NFMsg::G2C_PerformCmd xSendMsg;
		xSendMsg.mutable_framecmd()->CopyFrom(xMsg.framecmd());
		m_pNetModule->SendMsgPB(NFMsg::BATTLE_PERFORM_CMD, xSendMsg, sockIndex);
	}

}