using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public abstract class Plugin : Module
    {
        protected Dictionary<string, Module> m_Modules = new Dictionary<string, Module>();

        public abstract string GetPluginName();
        public abstract void Install();
        public abstract void Uninstall();
        public override void Awake()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.Awake();
                }
            }
        }

        public override void Init()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.Init();
                }
            }
        }

        public override void AfterInit()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.AfterInit();
                }
            }
        }

        public override void Execute()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.Execute();
                }
            }
        }

        public override void BeforeShut()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.BeforeShut();
                }
            }
        }

        public override void Shut()
        {
            foreach (Module module in m_Modules.Values)
            {
                if (module != null)
                {
                    module.Shut();
                }
            }
        }

        public void AddModule<T>(Module module) where T : Module
        {
            string strName = typeof(T).ToString();

            if (m_PluginManager.FindModule<T>() != null)
            {
                Debug.LogError($"plugin:{GetPluginName()} can not add already exist module: {strName}, please use FindModule");
                return;
            }
            m_Modules.Add(strName, module);
            m_PluginManager.AddModule(strName, module);
        }
    }
}
