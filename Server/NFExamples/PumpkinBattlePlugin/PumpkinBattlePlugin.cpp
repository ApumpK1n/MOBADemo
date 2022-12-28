#include "PumpkinBattleModule.h"
#include "PumpkinBattlePlugin.h"

//
//
#ifdef NF_DYNAMIC_PLUGIN

NF_EXPORT void DllStartPlugin(NFIPluginManager* pm)
{

    CREATE_PLUGIN(pm, PumpkinBattlePlugin)

};

NF_EXPORT void DllStopPlugin(NFIPluginManager* pm)
{
    DESTROY_PLUGIN(pm, PumpkinBattlePlugin)
};

#endif
//////////////////////////////////////////////////////////////////////////

const int PumpkinBattlePlugin::GetPluginVersion()
{
    return 0;
}

const std::string PumpkinBattlePlugin::GetPluginName()
{
	return GET_CLASS_NAME(PumpkinBattlePlugin);
}

void PumpkinBattlePlugin::Install()
{
    REGISTER_MODULE(pPluginManager, PumpkinIBattleModule, PumpkinBattleModule)

}

void PumpkinBattlePlugin::Uninstall()
{
    UNREGISTER_MODULE(pPluginManager, PumpkinIBattleModule, PumpkinBattleModule)
}