using System;
using System.Collections.Generic;
using System.Linq;
using NFSDK;

namespace Pumpkin
{
    public class NetPlugin : NFIPlugin
    {

        public NetPlugin(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override string GetPluginName()
        {
            return "NetPlugin";
        }

        public override void Install()
        {
            AddModule<C2SMsgModule>(new C2SMsgModule(mPluginManager));
            AddModule<S2CMsgModule>(new S2CMsgModule(mPluginManager));
        }

        public override void Uninstall()
        {
            mPluginManager.RemoveModule<C2SMsgModule>();
            mPluginManager.RemoveModule<S2CMsgModule>();

            mModules.Clear();
        }
    }
}
