using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumpkin
{
    public class SkillComponent : Component
    {
        public SkillConfigObject SkillConfig { get; set; }

        public override void Awake(object initData)
        {
            base.Awake(initData);
            SkillConfig = initData as SkillConfigObject;

            AddComponent<EffectComponent>(SkillConfig.Effects);

            //激活被动技能
            if (SkillConfig.Type == SkillType.Passive)
            {
                //TryActivateAbility();
            }
        }
    }
}
