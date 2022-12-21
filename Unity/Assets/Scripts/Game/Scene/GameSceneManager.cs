using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pumpkin.Utility;
using UnityEngine.SceneManagement;
using NFSDK;
using NFrame;

namespace Pumpkin
{
    public class GameSceneManager : SingletonBehaviour<GameSceneManager>
    {
        [SerializeField]
        private Dictionary<int, string> m_Scenes = new Dictionary<int, string>()
        {
            { 1, "MainMenu"}
        };

        private NFIEventModule m_EventModule;

        protected override void Awake()
        {
            base.Awake();

            DontDestroyOnLoad(gameObject);

            m_EventModule = GameInit.Instance.PluginManager.FindModule<NFIEventModule>();

            m_EventModule.RegisterCallback((int)NFLoginModule.Event.SwapSceneSuccess, OnSwapScene);
        }

        public bool LoadScene(int sceneId)
        {
            if (m_Scenes.TryGetValue(sceneId, out string sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName);
                return true;
            }
            return false;
        }

        private void OnSwapScene(int eventId, NFDataList valueList)
        {
            LoadScene((int)valueList.GetData(0).IntVal());
        }
    }
}
