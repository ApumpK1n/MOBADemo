/*
            This file is part of: 
                NoahFrame
            https://github.com/ketoo/NoahGameFrame

   Copyright 2009 - 2021 NoahFrame(NoahGameFrame)

   File creator: lvsheng.huang
   
   NoahFrame is open-source software and you can redistribute it and/or modify
   it under the terms of the License; besides, anyone who use this file/software must include this copyright announcement.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
#include "NFProxyLogicPlugin.h"
#include "NFProxyLogicModule.h"

bool NFProxyLogicModule::Init()
{



    return true;
}

bool NFProxyLogicModule::Shut()
{
    return true;
}

bool NFProxyLogicModule::Execute()
{


    return true;
}


bool NFProxyLogicModule::AfterInit()
{
    m_pKernelModule = pPluginManager->FindModule<NFIKernelModule>();
    m_pClassModule = pPluginManager->FindModule<NFIClassModule>();
	m_pNetModule = pPluginManager->FindModule<NFINetModule>();
	m_pNetClientModule = pPluginManager->FindModule<NFINetClientModule>();
    m_pSecurityModule = pPluginManager->FindModule<NFISecurityModule>();

	m_pNetModule->AddReceiveCallBack(NFMsg::REQ_LAG_TEST, this, &NFProxyLogicModule::OnLagTestProcess);
	
	m_pNetModule->AddReceiveCallBack(NFMsg::CREATE_ROOM, this, &NFProxyLogicModule::OnCreateRoom);

    return true;
}

void NFProxyLogicModule::OnLagTestProcess(const NFSOCK sockIndex, const int msgID, const char * msg, const uint32_t len)
{
	std::string msgDatag(msg, len);
	m_pNetModule->SendMsgWithOutHead(NFMsg::EGameMsgID::ACK_GATE_LAG_TEST, msgDatag, sockIndex);

	//TODO improve performance
	NetObject* pNetObject = m_pNetModule->GetNet()->GetNetObject(sockIndex);
	if (pNetObject)
	{
		const int gameID = pNetObject->GetGameID();
		m_pNetClientModule->SendByServerIDWithOutHead(gameID, msgID, msgDatag);
	}
}

void NFProxyLogicModule::OnCreateRoom(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len) 
{
    NetObject* pNetObject = m_pNetModule->GetNet()->GetNetObject(sockIndex);
    if (!pNetObject)
    {
        return;
    }

    std::string strMsgData = m_pSecurityModule->DecodeMsg(pNetObject->GetAccount(), pNetObject->GetSecurityKey(), msgID, msg, len);
    if (strMsgData.empty())
    {
        //decode failed
        return;
    }

    NFGUID nPlayerID;//no value
    NFMsg::ReqEnterGameServer xData;
    if (!m_pNetModule->ReceivePB(msgID, msg, len, xData, nPlayerID))
    {
        return;
    }

    NF_SHARE_PTR<ConnectData> pServerData = m_pNetClientModule->GetServerNetInfo(pNetObject->GetGameID());
    if (pServerData && ConnectDataState::NORMAL == pServerData->eState)
    {
        if (pNetObject->GetConnectKeyState() > 0
            && pNetObject->GetAccount() == xData.account()
            && !xData.name().empty()
            && !xData.account().empty())
        {
            NFMsg::MsgBase xMsg;
            if (!xData.SerializeToString(xMsg.mutable_msg_data()))
            {
                return;
            }

            //clientid
            xMsg.mutable_player_id()->CopyFrom(NFINetModule::NFToPB(pNetObject->GetClientID()));
            std::string msg;
            if (!xMsg.SerializeToString(&msg))
            {
                return;
            }

            m_pNetClientModule->SendByServerIDWithOutHead(pNetObject->GetGameID(), NFMsg::EGameMsgID::CREATE_ROOM, msg);
        }
    }
}
