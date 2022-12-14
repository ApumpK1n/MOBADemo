using System;

namespace Pumpkin
{
    public enum AnimationStateType
    {
        Idle = 0, 
        Death = 1,
        Run = 2,
        Crit = 3, // 暴击
        Dance = 4,
        Laugh = 5,
        Recall = 6, // 回城

        Attack = 10, // 普攻

        Spell1 = 20, // 技能1
        Spell2 = 21, // 技能2
        Spell3 = 22, // 技能3
        Spell4 = 23, // 技能4
    }
}
