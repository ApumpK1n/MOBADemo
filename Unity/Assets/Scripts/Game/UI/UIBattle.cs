using System;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Pumpkin
{
    public class UIBattle : UIDialog
    {
        public Button m_AttackButton;
        public Button m_PerformButton;

        private C2SMsgModule m_C2SMsgModule;
        private CommandQueueModule m_CommandQueueModule;

        public override void OnLoad()
        {
            base.OnLoad();
            m_AttackButton.onClick.AddListener(OnAttackButton);
            m_PerformButton.onClick.AddListener(OnPerformButton);

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

        private void OnPerformButton()
        {
            PerformCommand performCommand = new PerformCommand();
            performCommand.PlayerId = "233";
            performCommand.SyncCmdType = NFMsg.AllCmdType.Perform;
            performCommand.SkillId = 1001;
            m_CommandQueueModule.AddCmdToSendQueue(performCommand);
        }
    }
}
