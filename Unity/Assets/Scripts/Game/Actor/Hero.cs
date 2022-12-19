using System;
using System.Collections.Generic;

namespace Pumpkin
{
    public class Hero : Actor
    {

        protected override void AddActorData()
        {
            AddActorData(new ActorBaseData() { ActorType = ActorType.Hero });
            AddActorData(new ActorTransformData());
        }

        protected override void AddActorComponet()
        {
            gameObject.AddComponent<MoveComponent>();
        }
    }
}
