using NFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using NFMsg;

namespace Pumpkin
{
    public class UIMianMenu : UIDialog
    {
        public Button m_CreateRoom;
        private C2SMsgModule m_C2SMsgModule;
        private NFLoginModule m_NFLoginModule;


        public override void OnLoad()
        {
            base.OnLoad();

            m_CreateRoom.onClick.AddListener(OnCreateRoom);

            m_C2SMsgModule = GameInit.Instance.PluginManager.FindModule<C2SMsgModule>();
            m_NFLoginModule = GameInit.Instance.PluginManager.FindModule<NFLoginModule>();
        }

        private void OnCreateRoom()
        {
            CreateRoom message = new CreateRoom
            {
                HolderPlayerId = m_NFLoginModule.mRoleID.ToString()
            };
            m_C2SMsgModule.SendMsg(EGameMsgID.CreateRoom, message);
        }
    }
}