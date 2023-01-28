
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class FightAbility : Ability
    {
        public Dictionary<string, SkillAbility> NameSkills { get; set; } = new Dictionary<string, SkillAbility>();
        public Dictionary<uint, SkillAbility> IdSkills { get; set; } = new Dictionary<uint, SkillAbility>();

        public override void Awake()
        {
            

        }

        public SkillAbility AttachSkill(object configObject)
        {
            var skill = AttachAbility<SkillAbility>(configObject);
            NameSkills.Add(skill.SkillConfig.Name, skill);
            IdSkills.Add(skill.SkillConfig.Id, skill);
            return skill;
        }

        public T AttachAbility<T>(object configObject) where T : Ability
        {
            var ability = AddChild<T>(configObject);
            return ability as T;
        }

        public bool PerformSkill(uint skillId)
        {
            if (IdSkills.TryGetValue(skillId, out SkillAbility ability))
            {
                ability.Perform();
            }
            return false;
        }
    }
}
