using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class DamageAbility : Ability
    {
        public DamageEffectComponent DamageEffectComponent;

        public override void Awake(object initData)
        {
            base.Awake(initData);

            DamageEffectComponent = AddComponent<DamageEffectComponent>(initData);
            
        }
    }
}
