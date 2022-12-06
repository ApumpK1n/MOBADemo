using System;
using System.Collections.Generic;
using Pumpkin;
using UnityEngine;
using UnityEngine.UI;

public class UILogin : UIDialog
{
    private ServerConfig m_ServerConfig;


    public Button m_Login;
    public override void OnInit()
    {
        m_ServerConfig = new ServerConfig();
        m_ServerConfig.Load();


        m_Login.onClick.AddListener(OnLoginClick);
    }


    private void OnLoginClick()
    {
        //PlayerPrefs.SetString("account", mAccount.text);
        //PlayerPrefs.SetString("password", mPassword.text);
        //mLoginModule.LoginPB(mAccount.text, mPassword.text, "");
        //mLoginModule.RequireVerifyWorldKey(mAccount.text, mPassword.text);
    }
}
