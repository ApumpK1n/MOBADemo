using System;
using System.Collections.Generic;
using Pumpkin;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : UIDialog
{
    public Button m_Login;
    public InputField m_Account;
    public InputField m_Password;
    public Dropdown m_ServerList;

    private ServerConfig m_ServerConfig;
    private string m_CurrentIp;

    public override void OnInit()
    {
        m_ServerConfig = new ServerConfig();
        m_ServerConfig.Load();


        m_ServerList.ClearOptions();
        List<string> serverNames = new List<string>();
        foreach (var server in m_ServerConfig.GetServerList())
        {
            serverNames.Add(server.strName);
        }
        m_ServerList.AddOptions(serverNames);

        m_ServerConfig.GetSelectServer(0, ref m_CurrentIp);

        m_Login.onClick.AddListener(OnLoginClick);
        m_ServerList.onValueChanged.AddListener(OnSelectServer);
    }

    public override void OnShow()
    {
        m_Account.text = PlayerPrefs.GetString("account");
        m_Password.text = PlayerPrefs.GetString("password");
    }

    private void OnLoginClick()
    {
        if (String.IsNullOrEmpty(m_CurrentIp))
        {
            Debug.LogError("do not select server!");
            return;
        }

        PlayerPrefs.SetString("account", m_Account.text);
        PlayerPrefs.SetString("password", m_Password.text);
        //mLoginModule.LoginPB(mAccount.text, mPassword.text, "");
        //mLoginModule.RequireVerifyWorldKey(mAccount.text, mPassword.text);
    }

    private void OnSelectServer(int id)
    {
        m_ServerConfig.GetSelectServer(id, ref m_CurrentIp);
    }
}
