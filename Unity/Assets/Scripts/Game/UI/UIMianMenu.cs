using NFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

namespace Pumpkin
{
    public class UIMianMenu : UIDialog
    {
        public Button m_CreateRoom;

        private NFNetModule m_NetModule;

        public override void OnLoad()
        {
            base.OnLoad();

            m_CreateRoom.onClick.AddListener(OnCreateRoom);

            m_NetModule = GameInit.Instance.PluginManager.FindModule<NFNetModule>();
        }

        private void OnCreateRoom()
        {

        }
    }
}