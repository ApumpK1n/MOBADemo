using System;
using System.Collections.Generic;
using System.Linq;
using NFSDK;

namespace Pumpkin
{
    public class CommandQueuePlugin : NFIPlugin
    {
        public CommandQueuePlugin(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override string GetPluginName()
        {
            return nameof(CommandQueuePlugin);
        }

        public override void Install()
        {
            AddModule<CommandQueueModule>(new CommandQueueModule(mPluginManager));
        }

        public override void Uninstall()
        {
            mPluginManager.RemoveModule<CommandQueueModule>();

            mModules.Clear();
        }
    }
}
