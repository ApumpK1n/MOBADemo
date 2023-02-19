using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

            Vector3 target = cmd.TargetPos;
            MoveComponent moveComponent = actor.GetComponent<MoveComponent>();
            //MoveComponent.NavigationData navigationData = new MoveComponent.NavigationData()
            //{
            //    Position = pos,
            //    TargetPosition = target,
            //    StepTime = 1, // 未引入数值系统,后续根据移动速度和距离算出两点之间移动需要的时间
            //};
            //if (moveComponent.FindNavigatePath(navigationData))
            //{
            //    actor.ChangeState(ActorStateType.Run);
            //    moveComponent.StartNavigate(navigationData, actorTransformData);
            //}
            //else
            //{
            //    moveComponent.StopNavigate();
            //}
            moveComponent.StartNavigate(cmd.MovePoints, actorTransformData);
        }
    }
}
