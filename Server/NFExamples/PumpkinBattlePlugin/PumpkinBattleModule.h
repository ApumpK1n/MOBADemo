
#ifndef PUMPKIN_BATTLE_MODULE_H
#define PUMPKIN_BATTLE_MODULE_H

#include <memory>
#include "NFComm/NFPluginModule/NFINetModule.h"
#include "NFComm/NFPluginModule/NFILogModule.h"
#include "NFComm/NFPluginModule/NFIKernelModule.h"
#include "NFComm/NFPluginModule/NFIGameServerNet_ServerModule.h"

#include "NFComm/NFMessageDefine/NFProtocolDefine.hpp"
#include "NFComm/NFMessageDefine/NFMsgPreGame.pb.h"
////////////////////////////////////////////////////////////////////////////

class PumpkinIBattleModule
    : public NFIModule
 {

};

class PumpkinBattleModule
    : public PumpkinIBattleModule
{
public:
    PumpkinBattleModule(NFIPluginManager* p)
    {
        pPluginManager = p;
    }
    virtual bool Init() override;
    virtual bool Shut() override;
    virtual bool Execute() override;

    virtual bool AfterInit() override;

private:
	void OnBattleClientCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len);

protected:

    //////////////////////////////////////////////////////////////////////////
    NFILogModule* m_pLogModule;
	NFINetModule* m_pNetModule;
	NFIKernelModule* m_pKernelModule;
	NFIGameServerNet_ServerModule* m_pGameServerNet_ServerModule;
};
#endif
