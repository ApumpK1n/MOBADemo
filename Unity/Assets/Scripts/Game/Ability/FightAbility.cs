
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    public class FightAbility : Ability
    {
        public Dictionary<string, SkillAbility> NameSkills { get; set; } = new Dictionary<string, SkillAbility>();
        public Dictionary<int, SkillAbility> IdSkills { get; set; } = new Dictionary<int, SkillAbility>();

        public Dictionary<KeyCode, SkillAbility> InputSkills { get; set; } = new Dictionary<KeyCode, SkillAbility>();

        public override void Awake()
        {
            

        }

        public SkillAbility AttachSkill(object configObject)
        {
            SkillAbility skill = AttachAbility<SkillAbility>(configObject);
            NameSkills.Add(skill.SkillConfig.Name, skill);
            IdSkills.Add(skill.SkillConfig.Id, skill);
            return skill;
        }

        public void BindSkillInput(SkillAbility abilityEntity, KeyCode keyCode)
        {
            InputSkills.Add(keyCode, abilityEntity);
        }

        public T AttachAbility<T>(object configObject) where T : Ability
        {
            var ability = AddChild<T>(configObject);
            return ability as T;
        }

        public bool PerformSkill(int skillId)
        {
            if (IdSkills.TryGetValue(skillId, out SkillAbility ability))
            {
                ability.Perform();
            }
            return false;
        }
    }
}
