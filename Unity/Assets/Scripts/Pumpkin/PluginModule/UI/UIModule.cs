using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class UIModule : Module
    {
        private Dictionary<string, UIDialog> m_AllDialogs;
        private Queue<UIDialog> m_HistoryDialogs;
        private UIDialog m_CurrentDialog;
        private Transform m_Root;

        public UIModule(PluginManager pluginManager)
        {
            m_AllDialogs = new Dictionary<string, UIDialog>();
            m_HistoryDialogs = new Queue<UIDialog>();

            m_PluginManager = pluginManager;
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

            string name = typeof(T).ToString();
            if (!m_AllDialogs.TryGetValue(name, out UIDialog ui))
            {
                // �滻��������
                GameObject prefab = Resources.Load<GameObject>("UI/" + name);
                GameObject go = GameObject.Instantiate(prefab);
                go.name = name;
                if (m_Root != null) go.transform.SetParent(m_Root, false);

                ui = go.GetComponent<T>();
                ui.OnInit();
                m_AllDialogs.Add(name, ui);
            }
            else
            {
                ui.gameObject.SetActive(true);
                ui.OnShow();
            }

            m_CurrentDialog = ui;

            if (bPushHistory)
            {
                m_HistoryDialogs.Enqueue(ui);
            }
            return (T)ui;
        }
    }
}