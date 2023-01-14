using NFSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using NFMsg;

namespace Pumpkin
{
    public abstract class Cmd
    {
        public int Frame;
        public NFMsg.AllCmdType SyncCmdType;
        public string PlayerId;

    }
}
