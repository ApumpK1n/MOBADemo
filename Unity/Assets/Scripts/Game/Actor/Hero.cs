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

        protected override void AddActorComponent()
        {
            gameObject.AddComponent<MoveComponent>();
        }

        protected override void AddActorAbility()
        {
            base.AddActorAbility();

            Ability.Create<DamageAbility>();
        }
    }
}
