
#include "NFPumpkinBattleModule.h"
#include "NFComm/NFMessageDefine/NFMsgDefine.h"

bool NFPumpkinBattleModule::Init()
{
	m_pNetModule = pPluginManager->FindModule<NFINetModule>();
	m_pNavigationModule = pPluginManager->FindModule<NFINavigationModule>();
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
	m_pNetModule->AddReceiveCallBack(NFMsg::BATTLE_PERFORM_CMD, this, &NFPumpkinBattleModule::OnPerformCmd);
	m_pNetModule->AddReceiveCallBack(NFMsg::BATTLE_MOVE_CMD, this, &NFPumpkinBattleModule::OnMoveCmd);
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
		// TODO: 验证技能ID
		xSendMsg.set_skillid(xMsg.skillid());
		m_pNetModule->SendMsgPB(NFMsg::BATTLE_PERFORM_CMD, xSendMsg, sockIndex);
	}

}

void NFPumpkinBattleModule::OnMoveCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len)
{
	NFGUID clientID;

	NFMsg::C2G_MoveCmd xMsg;
	if (!m_pNetModule->ReceivePB(msgID, msg, len, xMsg, clientID))
	{
		return;
	}	

	NetObject* pNetObject = m_pNetModule->GetNet()->GetNetObject(sockIndex);
	if (pNetObject) {
		NFVector3 start(xMsg.posx(), xMsg.posy(), xMsg.posz());
		NFVector3 end(xMsg.targetposx(), xMsg.targetposy(), xMsg.targetposz());
		vector<NFVector3> pathResult;

		int ret = m_pNavigationModule->FindPath(xMsg.sceneid(), start, end, pathResult);
		if (ret > 0)
		{
			NFMsg::G2C_MoveCmd xSendMsg;
			xSendMsg.mutable_framecmd()->CopyFrom(xMsg.framecmd());
			// TODO: 验证位置数据
			for (auto iter = pathResult.begin(); iter != pathResult.end(); iter++)
			{
				NFMsg::Vector3* point = xSendMsg.add_pathpoints();

				point->set_x((*iter).X());
				point->set_y((*iter).Y());
				point->set_z((*iter).Z());
			}
			m_pNetModule->SendMsgPB(NFMsg::BATTLE_MOVE_CMD, xSendMsg, sockIndex);
			std::cout << "FindPath Success" << std::endl;
		}
		else
		{
			std::cout << "FindPath Fail" << std::endl;
		}
	}
	
}