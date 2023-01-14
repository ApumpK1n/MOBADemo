using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NFrame;
using NFSDK;

namespace Pumpkin
{
    public class S2CMsgModule : NFIModule
    {

        private CmdDispatcherModule m_CmdDispatcherModule;
        private NFNetModule m_NetModule;

        public S2CMsgModule(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override void AfterInit()
        {

        }

        public override void Awake()
        {
            m_NetModule = mPluginManager.FindModule<NFNetModule>();
            m_CmdDispatcherModule = GameInit.Instance.PluginManager.FindModule<CmdDispatcherModule>();
        }

        public override void BeforeShut()
        {

        }

        public override void Execute()
        {

        }

        public override void Init()
        {
            m_NetModule.AddReceiveCallBack((int)NFMsg.EGameMsgID.BattleAttackCmd, OnBattleAttackCmd);
        }

        public override void Shut()
        {
        }


        private void OnBattleAttackCmd(int id, MemoryStream stream)
        {
            NFMsg.MsgBase xMsg = NFMsg.MsgBase.Parser.ParseFrom(stream);
            NFMsg.G2C_AttackCmd xData = NFMsg.G2C_AttackCmd.Parser.ParseFrom(xMsg.MsgData);

            // TODO 接入数据处理
            AttackCommand attackCommand  = new AttackCommand();
            attackCommand.Frame = xData.FrameCmd.Frame;
            attackCommand.SyncCmdType = xData.FrameCmd.SyncCmdType;
            m_CmdDispatcherModule.Handle(attackCommand);
        }
    }
}
