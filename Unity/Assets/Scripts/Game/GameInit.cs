using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pumpkin;
using NFSDK;

namespace Pumpkin
{
    public class GameInit : MonoBehaviour
    {
        public Transform UIRoot;
        public static GameInit Instance => s_Instance;
        public NFPluginManager PluginManager => m_PluginManager;

        private NFPluginManager m_PluginManager;

        private static GameInit s_Instance;

        private UIModule m_UIModule;

        private void Awake()
        {
            m_PluginManager = new NFPluginManager();

            s_Instance = this;

            m_PluginManager.Registered(new NFSDKPlugin(m_PluginManager));
            m_PluginManager.Registered(new NetPlugin(m_PluginManager));
            m_PluginManager.Registered(new CmdPlugin(m_PluginManager));
            m_PluginManager.Registered(new CommandQueuePlugin(m_PluginManager));
            m_PluginManager.Registered(new UIPlugin(m_PluginManager));


            m_PluginManager.Awake();
            m_PluginManager.Init();
        }

        // Start is called before the first frame update
        void Start()
        {
            m_PluginManager.AfterInit();

            m_UIModule = m_PluginManager.FindModule<UIModule>();

            DontDestroyOnLoad(gameObject);

            m_UIModule.SetUIRoot(UIRoot);
            m_UIModule.ShowUI<UILogin>(false, false);
        }

        void OnDestroy()
        {
            m_PluginManager.BeforeShut();
            m_PluginManager.Shut();
            m_PluginManager = null;
        }

        // Update is called once per frame
        void Update()
        {
            m_PluginManager.Execute();
        }
    }

}
