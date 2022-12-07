using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pumpkin;

public class GameInit : MonoBehaviour
{
    public Transform UIRoot;
    public static GameInit Instance => s_Instance;

    private PluginManager m_PluginManager;

    private static GameInit s_Instance;

    private UIModule m_UIModule;

    private void Awake()
    {
        m_PluginManager = new PluginManager();

        s_Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_PluginManager.Registered(new UIPlugin(m_PluginManager));

        m_PluginManager.Awake();
        m_PluginManager.Init();
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
        
    }
}
