
#ifndef PUMPKIN_BATTLE_PLUGIN_H
#define PUMPKIN_BATTLE_PLUGIN_H

///
#include "NFComm/NFPluginModule/NFIPlugin.h"
#include "NFComm/NFPluginModule/NFIPluginManager.h"

class PumpkinBattlePlugin : public NFIPlugin
{
public:
    PumpkinBattlePlugin(NFIPluginManager* p)
    {
        pPluginManager = p;
    }
    virtual const int GetPluginVersion();

    virtual const std::string GetPluginName();

    virtual void Install();

    virtual void Uninstall();
};
#endif