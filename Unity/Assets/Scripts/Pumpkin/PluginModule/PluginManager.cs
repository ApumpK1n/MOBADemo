using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    /// <summary>
    /// 对扩展和模块生命周期管理
    /// </summary>
    public class PluginManager : Module
    {
        private Dictionary<string, Plugin> m_Plugins;
        private Dictionary<string, Module> m_Modules;

        public PluginManager()
        {
            m_Plugins = new Dictionary<string, Plugin>();
            m_Modules = new Dictionary<string, Module>();
        }

        public override void Awake()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.Awake();
                }
            }
        }

        public override void AfterInit()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.Init();
                }
            }
        }

        public override void Init()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.AfterInit();
                }
            }
        }

        public override void Execute()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.Execute();
                }
            }
        }

        public override void BeforeShut()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.BeforeShut();
                }
            }
        }

        public override void Shut()
        {
            foreach (Plugin plugin in m_Plugins.Values)
            {
                if (plugin != null)
                {
                    plugin.Shut();
                }
            }
        }

        public T FindModule<T>() where T : Module
        {
            Module module = FindModule(typeof(T).ToString());

            return (T)module;
        }

        private Module FindModule(string strModuleName)
        {
            m_Modules.TryGetValue(strModuleName, out Module module);
            return module;
        }

        public void Registered(Plugin plugin)
        {
            if (m_Plugins.ContainsKey(plugin.GetPluginName()))
            {
                Debug.LogError($"PluginManager can not Registered already exist plugin");
                return;
            }
            m_Plugins.Add(plugin.GetPluginName(), plugin);
            plugin.Install();
        }

        public void UnRegistered(Plugin plugin)
        {
            if (m_Plugins.ContainsKey(plugin.GetPluginName()))
            {
                m_Plugins.Remove(plugin.GetPluginName());
                plugin.Uninstall();
            }
            else
            {
                Debug.LogError($"PluginManager can not UnRegistered not exist plugin");
            }
        }

        public void AddModule(string strModuleName, Module pModule)
        {
            m_Modules.Add(strModuleName, pModule);
        }
        public void RemoveModule(string strModuleName)
        {
            m_Modules.Remove(strModuleName);
        }

        public void RemoveModule<T>() where T : Module
        {
            RemoveModule(typeof(T).ToString());
        }
    }
}
