using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Pumpkin
{
    public class UIBattle : UIDialog
    {
        public Button m_AttackButton;

        private C2SMsgModule m_C2SMsgModule;
        private CommandQueueModule m_CommandQueueModule;

        public override void OnLoad()
        {
            base.OnLoad();
            m_AttackButton.onClick.AddListener(OnAttackButton);

            m_C2SMsgModule = GameInit.Instance.PluginManager.FindModule<C2SMsgModule>();

            m_CommandQueueModule = GameInit.Instance.PluginManager.FindModule<CommandQueueModule>();
        }

        private void OnAttackButton()
        {
            AttackCommand attackCommand = new AttackCommand();
            attackCommand.PlayerId = "233";
            attackCommand.SyncCmdType = NFMsg.AllCmdType.Attack;
            attackCommand.TargetId = "";
            m_CommandQueueModule.AddCmdToSendQueue(attackCommand);
        }
    }
}
