using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class SkillAbility : Ability
    {
        public SkillComponent SkillComponent;
        public SkillConfigObject SkillConfig;

        public override void Awake(object initData)
        {
            SkillConfig = initData as SkillConfigObject;
            SkillComponent = AddComponent<SkillComponent>(initData);

        }

        public bool Perform()
        {
            PrePerform();

            OnPerform();
            return true;
        }

        private void PrePerform()
        {

        }

        private void OnPerform()
        {

        }
    }
}
