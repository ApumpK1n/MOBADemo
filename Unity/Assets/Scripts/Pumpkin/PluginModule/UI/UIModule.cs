using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NFSDK;

namespace Pumpkin
{
    public class UIModule : NFIModule
    {
        private Dictionary<string, UIDialog> m_AllDialogs;
        private Queue<UIDialog> m_HistoryDialogs;
        private HashSet<UIDialog> m_ReadyToShow;

        private UIDialog m_CurrentDialog;
        private Transform m_Root;

        public UIModule(NFIPluginManager pluginManager)
        {
            m_AllDialogs = new Dictionary<string, UIDialog>();
            m_HistoryDialogs = new Queue<UIDialog>();

            mPluginManager = pluginManager;
        }

        public override void Awake()
        {
        }

        public override void Init()
        {
        }


        public override void AfterInit()
        {
        }

        public override void Execute()
        {

        }

        public override void BeforeShut()
        {
        }

        public override void Shut()
        {
        }

        public void SetUIRoot(Transform uiRoot)
        {
            m_Root = uiRoot;
        }

        public T ShowUI<T>(bool bCloseLastOne = true, bool bPushHistory = true) where T : UIDialog
        {
            // TODO 解决同一帧类多次打开界面的请求用队列处理
            string name = typeof(T).ToString();
            if (!m_AllDialogs.TryGetValue(name, out UIDialog ui))
            {
                // 替换成其他的资源方案
                GameObject prefab = Resources.Load<GameObject>("UI/"+ name);
                GameObject go = GameObject.Instantiate(prefab);
                go.name = name;
                if (m_Root != null) go.transform.SetParent(m_Root, false);

                ui = go.GetComponent<T>();
                ui.OnLoad();
                m_AllDialogs.Add(name, ui);
            }

            //m_ReadyToShow.Add(ui);
            ui.gameObject.SetActive(true);
            ui.OnShow();

            m_CurrentDialog = ui;

            if (bPushHistory)
            {
                m_HistoryDialogs.Enqueue(ui);
            }
            return (T)ui;
        }

        public bool CloseUI<T>() where T : UIDialog
        {
            string name = typeof(T).ToString();
            if (!m_AllDialogs.TryGetValue(name, out UIDialog ui))
            {
                Debug.LogError($"UIModule CloseUI {name} not open!");
                return false;
            }

            ui.OnHide();
            ui.gameObject.SetActive(false);

            return true;
        }
    }
}
