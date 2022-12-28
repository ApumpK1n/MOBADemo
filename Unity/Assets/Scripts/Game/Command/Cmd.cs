using NFSDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public abstract class Cmd
    {
        public int Frame;
        public AllCmdType SyncCmdType;
        public string PlayerId;

    }
}
