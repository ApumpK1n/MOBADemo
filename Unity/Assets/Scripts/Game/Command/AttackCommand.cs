using System;
using System.Collections.Generic;

namespace Pumpkin
{
    public class AttackCommand : Cmd
    {
        public const NFMsg.AllCmdType CmdType = NFMsg.AllCmdType.Attack;

        public string TargetId;
    }
}
