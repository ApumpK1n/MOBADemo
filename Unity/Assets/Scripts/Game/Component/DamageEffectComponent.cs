using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class DamageEffectComponent : Component
    {

        public DamageEffect EffectConfig;

        public override void Awake(object initData)
        {
            EffectConfig = initData as DamageEffect;
        }



    }
}
