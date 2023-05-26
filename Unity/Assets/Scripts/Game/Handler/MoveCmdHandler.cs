using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pumpkin.Utility;


namespace Pumpkin
{
    [CommandHandler(CommandHandlerType = MoveCommand.CmdType)]
    public class MoveCmdHandler : Handler<MoveCommand>
    {

        protected override void Run(Actor actor, MoveCommand cmd)
        {
            //Vector3 pos = cmd.Pos;
            Quaternion rotation = new Quaternion(cmd.RotX, cmd.RotY, cmd.RotZ, cmd.RotW);
            ActorTransformData actorTransformData = actor.GetActorData<ActorTransformData>();
            //actorTransformData.Position = pos;
            actorTransformData.Rotation = rotation;

            actor.ChangeState(ActorStateType.Run);

            MoveComponent moveComponent = actor.GetComponent<MoveComponent>();
            moveComponent.StartNavigate(cmd.MovePoints, actorTransformData,
                () => { actor.ChangeState(ActorStateType.Idle); });

#if UNITY_EDITOR
            MoveListener.Instance.SetDebugPoints(cmd.MovePoints);
#endif
        }
    }
}
