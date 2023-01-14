#pragma once


#ifndef NF_PUMPKINBATTLE_MODULE_H
#define NF_PUMPKINBATTLE_MODULE_H

#include <string>
#include <map>
#include <iostream>
#include "NFComm/NFPluginModule/NFIModule.h"
#include <NFComm/NFPluginModule/NFINetModule.h>


class NFIPumpkinBattleModule : public NFIModule
{

};

class NFPumpkinBattleModule
    : public NFIPumpkinBattleModule
{
public:
    NFPumpkinBattleModule(NFIPluginManager* p)
    {
        pPluginManager = p;
    }
    virtual ~NFPumpkinBattleModule() {};

    virtual bool Init();
    virtual bool Shut();
    virtual bool Execute();
    virtual bool AfterInit();

protected:
    void OnAttackCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len);
    void OnPerformCmd(const NFSOCK sockIndex, const int msgID, const char* msg, const uint32_t len);

private:
    NFINetModule* m_pNetModule;
};

#endif