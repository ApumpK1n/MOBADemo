using NFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using NFMsg;

namespace Pumpkin
{
    public class UIMainMenu : UIDialog
    {
        public Button m_CreateRoom;
        public Button m_TestMove;
        private C2SMsgModule m_C2SMsgModule;
        private NFLoginModule m_NFLoginModule;
        private CommandQueueModule m_CommandQueueModule;

        public override void OnLoad()
        {
            base.OnLoad();

            m_CreateRoom.onClick.AddListener(OnCreateRoom);

            m_TestMove.onClick.AddListener(OnTestMove);

            m_C2SMsgModule = GameInit.Instance.PluginManager.FindModule<C2SMsgModule>();
            m_NFLoginModule = GameInit.Instance.PluginManager.FindModule<NFLoginModule>();

            m_CommandQueueModule = GameInit.Instance.PluginManager.FindModule<CommandQueueModule>();
        }

        private void OnCreateRoom()
        {
            CreateRoom message = new CreateRoom
            {
                HolderPlayerId = m_NFLoginModule.mRoleID.ToString()
            };
            m_C2SMsgModule.SendMsg(EGameMsgID.CreateRoom, message);
        }

        private void OnTestMove()
        {
            MoveCommand moveCommand = new MoveCommand();
            moveCommand.PlayerId = "233";
            moveCommand.SyncCmdType = NFMsg.AllCmdType.Move;
            m_CommandQueueModule.AddCmdToSendQueue(moveCommand);
        }
    }
}