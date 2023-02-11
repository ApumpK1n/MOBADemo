using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class ExecutionComponent : Component
    {
        public ExecutionObject ExecutionObject { get; private set; }

        private List<ExecutionClipComponent> m_ExecutionClipComponents = new List<ExecutionClipComponent>();
        private float m_Timer;
        private bool m_IsExecuting = false;
        private int m_Index;

        public override void Awake(object initData)
        {
            ExecutionObject = initData as ExecutionObject;
            foreach (var clip in ExecutionObject.ExecuteClips)
            {
                ExecutionClipComponent clipComponent = AddComponent<ExecutionClipComponent>(clip.Name, clip);
                m_ExecutionClipComponents.Add(clipComponent);
            }
        }


        public void BeginExecute()
        {
            if (ExecutionObject == null) return;

            if (m_IsExecuting) return;

            m_Timer = 0;
            m_IsExecuting = true;

            foreach (var clipComponent in m_ExecutionClipComponents)
            {
                clipComponent.Enable = true;
            }

            ExecuteClip();
        }

        private void ExecuteClip()
        {
            foreach (var clipComponent in m_ExecutionClipComponents)
            {
                if (clipComponent.Executing || !clipComponent.Enable) continue;
                if (m_Timer < clipComponent.ExecuteClipData.StartTime) continue;
                Debug.Log("Execute:" + clipComponent.ExecuteClipData.Name);
                clipComponent.Execute();
            }
        }

        public void EndExecute()
        {
            m_IsExecuting = false;
            m_Timer = 0;
            foreach (var clipComponent in m_ExecutionClipComponents)
            {
                clipComponent.OnEndExecute();
            }
        }

        public override void PreUpdate(float delta)
        {
            if (!m_IsExecuting) return;
            m_Timer += delta;

            if (m_Timer >= ExecutionObject.TotalTime)
            {
                EndExecute();
            }
            else
            {
                ExecuteClip();
            }
        }
    }
}
