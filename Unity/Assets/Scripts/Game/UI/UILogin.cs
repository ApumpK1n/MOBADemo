using System;
using System.Collections.Generic;
using Pumpkin;
using UnityEngine;
using UnityEngine.UI;
using NFSDK;
using NFrame;

public class UILogin : UIDialog
{
    public Button m_Login;
    public InputField m_Account;
    public InputField m_Password;
    public Dropdown m_ServerList;
    public Button m_Connect;

    private ServerConfig m_ServerConfig;
    private ServerConfig.Server m_CurrentServer;
    private NFNetModule m_NetModule;
    private NFLoginModule m_LoginModule;

    public override void OnLoad()
    {
        base.OnLoad();

        m_ServerConfig = new ServerConfig();
        m_ServerConfig.Load();

        m_NetModule = GameInit.Instance.PluginManager.FindModule<NFNetModule>();
        m_LoginModule = GameInit.Instance.PluginManager.FindModule<NFLoginModule>();

        m_ServerList.ClearOptions();
        List<string> serverNames = new List<string>();
        foreach (var server in m_ServerConfig.GetServerList())
        {
            serverNames.Add(server.strName);
        }
        m_ServerList.AddOptions(serverNames);

        m_ServerConfig.GetSelectServer(0, ref m_CurrentServer);

        m_Login.onClick.AddListener(OnLoginClick);
        m_Connect.onClick.AddListener(OnConnectClick);
        m_ServerList.onValueChanged.AddListener(OnSelectServer);
    }

    public override void OnShow()
    {
        m_Account.text = PlayerPrefs.GetString("account");
        m_Password.text = PlayerPrefs.GetString("password");
    }

    private void Update()
    {
        //if (CurrentState == UIState.NotLoad) return;

        //m_Connect.gameObject.SetActive(m_NetModule.GetState() == NFNetState.Disconnected);
    }

    private void OnConnectClick()
    {
        ConnectToServer();
    }

    private void OnLoginClick()
    {
        LoginToServer();
    }

    private void ConnectToServer()
    {
        m_NetModule.StartConnect(m_CurrentServer.strIP, m_CurrentServer.nPort);
    }

    private void OnSelectServer(int id)
    {
        m_ServerConfig.GetSelectServer(id, ref m_CurrentServer);
    }

    private void LoginToServer()
    {
        PlayerPrefs.SetString("account", m_Account.text);
        PlayerPrefs.SetString("password", m_Password.text);
        m_LoginModule.RequireVerifyWorldKey(m_Account.text, m_Password.text);
    }
}
