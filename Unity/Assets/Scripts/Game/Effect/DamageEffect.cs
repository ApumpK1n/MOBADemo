using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    [Effect("造成伤害", 10)]
    public class DamageEffect : Effect
    {
        public override string Label => "造成伤害";

        public DamageType DamageType;

        // 伤害取值
        public string DamageValueFormula;

        //能否暴击
        public bool CanCrit;

    }
}
