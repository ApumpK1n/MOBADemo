using System;
using System.Collections.Generic;

namespace Pumpkin
{
    public class UIPlugin : Plugin
    {
        public UIPlugin(PluginManager pluginManager)
        {
            m_PluginManager = pluginManager;
        }

        public override string GetPluginName()
        {
            return "UIPlugin";
        }

        public override void Install()
        {
            AddModule<UIModule>(new UIModule(m_PluginManager));
        }

        public override void Uninstall()
        {
            m_PluginManager.RemoveModule<UIModule>();

            m_Modules.Clear();
        }
    }
}
