using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class SkillComponent : Component
    {
        public SkillConfigObject SkillConfig { get; set; }
        public ExecutionObject ExecutionObject { get; set; }

        private ExecutionComponent m_ExecutionComponent;

        public override void Awake(object initData)
        {
            SkillConfig = initData as SkillConfigObject;

            AddComponent<AssignEffectComponent>(SkillConfig.Effects);
            LoadExecutionObject();
            m_ExecutionComponent = AddComponent<ExecutionComponent>(ExecutionObject);

            //激活被动技能
            if (SkillConfig.Type == SkillType.Passive)
            {
                Activate();
            }
        }

        private void LoadExecutionObject()
        {
            ExecutionObject = AssetLoad.Load<ExecutionObject>($"Execution/Execution_{SkillConfig.Id}");
        }

        public void Activate()
        {
            m_ExecutionComponent.BeginExecute();
        }
    }
}
