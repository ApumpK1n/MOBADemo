using System;
using System.Collections.Generic;
using NFSDK;

namespace Pumpkin
{
    public class CmdPlugin : NFIPlugin
    {
        public CmdPlugin(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override string GetPluginName()
        {
            return "CmdPlugin";
        }

        public override void Install()
        {
            AddModule<CmdDispatcherModule>(new CmdDispatcherModule(mPluginManager));
        }

        public override void Uninstall()
        {
            throw new NotImplementedException();
        }
    }
}
