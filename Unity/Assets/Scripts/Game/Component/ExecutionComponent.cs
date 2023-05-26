using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class ExecutionComponent : Component
    {
        public ExecutionObject ExecutionObject { get; private set; }

        private List<ExecutionClipComponent> m_ExecutionClipComponents;
        private List<ExecutionClipComponent> m_ReadyExecuteClips;
        private float m_Timer;
        private bool m_IsExecuting = false;

        public override void Awake(object initData)
        {
            ExecutionObject = initData as ExecutionObject;

            int length = ExecutionObject.ExecuteClips.Count;
            m_ExecutionClipComponents = new List<ExecutionClipComponent>(length);
            m_ReadyExecuteClips = new List<ExecutionClipComponent>(length);

            foreach (var clip in ExecutionObject.ExecuteClips)
            {
                ExecutionClipComponent clipComponent = AddComponent<ExecutionClipComponent>(clip.Name, clip);
                clipComponent.ExecutedAction += EndClipExecute;
                m_ExecutionClipComponents.Add(clipComponent);
            }
        }


        public void BeginExecute()
        {
            if (ExecutionObject == null) return;

            if (m_IsExecuting) return;

            m_Timer = 0;
            m_IsExecuting = true;

            m_ReadyExecuteClips.AddRange(m_ExecutionClipComponents);

            foreach (var clipComponent in m_ReadyExecuteClips)
            {
                clipComponent.Enable = true;
            }

            ExecuteClip();
        }

        private void ExecuteClip()
        {
            foreach (var clipComponent in m_ReadyExecuteClips)
            {
                if (clipComponent.Executing || !clipComponent.Enable) continue;
                if (m_Timer < clipComponent.ExecuteClipData.StartTime) continue;
                Debug.Log("Execute:" + clipComponent.ExecuteClipData.Name);
                clipComponent.Execute();
            }
        }

        public override void EndExecute()
        {
            m_IsExecuting = false;
            m_Timer = 0;
            foreach (var clipComponent in m_ExecutionClipComponents)
            {
                clipComponent.EndExecute();
            }
        }

        public override void PreUpdate(float delta)
        {
            if (!m_IsExecuting) return;
            m_Timer += delta;

            if (m_Timer >= ExecutionObject.TotalTime || m_ReadyExecuteClips.Count <= 0)
            {
                EndExecute();
            }
            else
            {
                ExecuteClip();
            }
        }

        public void EndClipExecute(ExecutionClipComponent clip)
        {
            m_ReadyExecuteClips.Remove(clip);
        }
    }
}
