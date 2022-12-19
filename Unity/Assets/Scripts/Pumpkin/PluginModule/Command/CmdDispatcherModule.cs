using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using NFSDK;
using UnityEngine;

namespace Pumpkin
{
    public class CmdDispatcherModule : NFIModule
    {
        private Dictionary<uint, IHandler> m_Handlers = new Dictionary<uint, IHandler>();

        public CmdDispatcherModule(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override void AfterInit()
        {
            
        }

        public override void Awake()
        {
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach(Assembly assembly in assemblies)
            {
                Type[] types = assembly.GetTypes();
                foreach(Type type in types)
                {
                    if (type.IsAbstract && type.IsSealed)
                    {
                        continue;
                    }
                    object[] objects = type.GetCustomAttributes(typeof(CommandHandlerAttribute), true);
                    if (objects.Length == 0)
                    {
                        continue;
                    }

                    foreach (CommandHandlerAttribute commandHandlerAttribute in objects)
                    {
                        IHandler handler = Activator.CreateInstance(type) as IHandler;
                        m_Handlers.Add(commandHandlerAttribute.CommandHandlerType, handler);
                    }
                }
            }
        }

        public override void BeforeShut()
        {

        }

        public override void Execute()
        {

        }

        public override void Init()
        {

        }

        public override void Shut()
        {

        }

        public void Handle(Cmd cmd)
        {
            if (!m_Handlers.TryGetValue(cmd.SyncCmdType, out IHandler handler))
            {
                Debug.LogError($"帧同步指令没有处理: {cmd.SyncCmdType} {cmd.GetType()} {cmd}");
                return;
            }
            try
            {
                handler.Handle(cmd);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}
