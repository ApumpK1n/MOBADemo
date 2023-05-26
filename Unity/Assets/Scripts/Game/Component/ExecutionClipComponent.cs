using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class ExecutionClipComponent : Component
    {
        public ExecuteClipData ExecuteClipData { get; set; }
        public event Action<ExecutionClipComponent> ExecutedAction;
        public bool Executing;
        private Component m_ExecuteComponent;
        private float m_timer;

        public override void Awake(object initData)
        {
            ExecuteClipData = initData as ExecuteClipData;

            switch (ExecuteClipData.ExecuteClipType)
            {
                case ExecuteClipType.Animation:
                    m_ExecuteComponent = AddComponent<ExecutionAnimationComponent>(ExecuteClipData.AnimationData.AnimationClip);
                    break;
            }
        }

        public override void Execute()
        {
            Executing = true;
            m_timer = 0;
            m_ExecuteComponent.Execute();
        }

        public override void EndExecute()
        {
            Executing = false;
            Enable = false;
            m_ExecuteComponent.EndExecute();
        }

        public override void PreUpdate(float delta)
        {
            if (!Executing) return;
            m_timer += delta;
            if (m_timer >= ExecuteClipData.Duration)
            {
                Executing = false;
                ExecutedAction?.Invoke(this);
            }
        }
    }
}
