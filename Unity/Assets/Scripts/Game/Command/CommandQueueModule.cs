using System;
using System.Collections.Generic;
using NFSDK;
using NFMsg;

namespace Pumpkin
{
    public class CommandQueueModule : NFIModule
    {
        private C2SMsgModule m_C2SMsgModule;

        public CommandQueueModule(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
        }

        public override void AfterInit()
        {

        }

        public override void Awake()
        {
            m_C2SMsgModule = mPluginManager.FindModule<C2SMsgModule>();
        }

        public override void BeforeShut()
        {

        }

        public override void Execute()
        {

        }

        public override void Init()
        {

        }

        public override void Shut()
        {
        }

        /// <summary>
        ///  将指令加入待发送列表，将在本帧末尾进行发送
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmdToSend"></param>
        public void AddCmdToSendQueue(Cmd cmdToSend, bool shouldAddToPlayerInputBuffer = true)
        {
            // TODO: Add Queue
            FrameCmd frameCmd = new FrameCmd
            {
                Frame = cmdToSend.Frame,
                PlayerId = cmdToSend.PlayerId,
                SyncCmdType = cmdToSend.SyncCmdType
            };

            switch (cmdToSend.SyncCmdType)
            {
                case NFMsg.AllCmdType.Move:
                    MoveCommand move = (MoveCommand)cmdToSend;
                    C2G_MoveCmd moveCmd = new C2G_MoveCmd
                    {
                        FrameCmd = frameCmd,
                        PosX = move.PosX,
                        PosY = move.PosY,
                        PosZ = move.PosZ,
                        TargetPosX = move.TargetPosX,
                        TargetPosY = move.TargetPosY,
                        TargetPosZ = move.TargetPosZ
                    };
                    m_C2SMsgModule.SendMsg(EGameMsgID.BattleClientCmd, moveCmd);
                    break;
                case NFMsg.AllCmdType.Attack:
                    AttackCommand attack = (AttackCommand)cmdToSend;
                    C2G_AttackCmd attackCmd = new C2G_AttackCmd
                    {
                        FrameCmd = frameCmd,
                        TargetId = attack.TargetId,
                    };
                    m_C2SMsgModule.SendMsg(EGameMsgID.BattleAttackCmd, attackCmd);
                    break;
            }
        }
    }
}
