using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public abstract class Cmd
    {
        public uint Frame;
        public uint SyncCmdType;
        public long ActorId;
    }
}
