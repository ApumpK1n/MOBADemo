using System;
using System.Collections.Generic;


namespace Pumpkin
{
    public class PerformCommand : Cmd
    {
        public const NFMsg.AllCmdType CmdType = NFMsg.AllCmdType.Perform;

        public int SkillId;
    }
}
