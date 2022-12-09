using System;
using System.Collections.Generic;
using NFSDK;

namespace Pumpkin
{
    public class UIPlugin : NFIPlugin
    {
        public UIPlugin(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override string GetPluginName()
        {
            return "UIPlugin";
        }

        public override void Install()
        {
            AddModule<UIModule>(new UIModule(mPluginManager));
        }

        public override void Uninstall()
        {
            mPluginManager.RemoveModule<UIModule>();

            mModules.Clear();
        }
    }
}
