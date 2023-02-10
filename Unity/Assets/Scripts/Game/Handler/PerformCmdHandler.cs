using System;
using System.Collections.Generic;

namespace Pumpkin
{
    [CommandHandler(CommandHandlerType = PerformCommand.CmdType)]
    public class PerformCmdHandler : Handler<PerformCommand>
    {
        protected override void Run(Actor actor, PerformCommand cmd)
        {
            actor.Preform(cmd.SkillId);
        }
    }
}
