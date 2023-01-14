using System;
using System.Collections.Generic;

namespace Pumpkin
{
    [CommandHandler(CommandHandlerType = AttackCommand.CmdType)]
    public class AttackCmdHandler : Handler<AttackCommand>
    {
        protected override void Run(Actor actor, AttackCommand cmd)
        {
            actor.ChangeState(ActorStateType.Attack);
        }
    }
}
