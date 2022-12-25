using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Google.Protobuf;
using NFMsg;
using NFrame;
using NFSDK;

namespace Pumpkin
{
    public class C2SMsgModule : NFIModule
    {
        private MemoryStream m_Body;
        private NFNetModule m_NetModule;

        public C2SMsgModule(NFIPluginManager pluginManager)
        {
            mPluginManager = pluginManager;
            m_Body = new MemoryStream();
        }

        public override void AfterInit()
        {
            
        }

        public override void Awake()
        {
            m_Body.SetLength(0);
            m_NetModule = GameInit.Instance.PluginManager.FindModule<NFNetModule>();
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

        public void SendMsg(EGameMsgID gameMsgID, IMessage message)
        {
            m_Body.SetLength(0);
            message.WriteTo(m_Body);

            m_NetModule.SendMsg((int)gameMsgID, m_Body);
        }
    }
}
