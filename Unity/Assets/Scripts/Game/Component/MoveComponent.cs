using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Pumpkin
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface m_NavMeshSurface;
        private NavMeshQueryFilter m_NavMeshQueryFilter;
        private NavMeshPath m_Path;

        private Coroutine m_NavigateCoroutine;

        public class NavigationData
        {
            public Vector3 Position;
            public Vector3 TargetPosition;
            public float StepTime;
        }

        private void Awake()
        {
            m_Path = new NavMeshPath();
            m_NavMeshQueryFilter = new NavMeshQueryFilter
            {
                agentTypeID = m_NavMeshSurface.agentTypeID,
                areaMask = m_NavMeshSurface.defaultArea
            };
        }

        private void StopCoroutine()
        {
            if (m_NavigateCoroutine != null)
            {
                StopCoroutine(m_NavigateCoroutine);
                m_NavigateCoroutine = null;
            }
        }

        private void StartCoroutine(NavigationData navigationData, ActorTransformData transformData)
        {
            m_NavigateCoroutine = StartCoroutine(NavigateCoroutine(navigationData, transformData));
        }

        public bool FindNavigatePath(NavigationData navigationData)
        {
            if (Vector3.Distance(navigationData.Position, navigationData.TargetPosition) <= 0.0001f)
            {
                return false;
            }
            NavMesh.CalculatePath(navigationData.Position, navigationData.TargetPosition, m_NavMeshQueryFilter, m_Path);
            if (m_Path.corners.Length < 1)
            {
                return false;
            }

            return true;
        }

        public void StartNavigate(NavigationData navigationData, ActorTransformData transformData)
        { 
            //先停止协程
            StopCoroutine();
            StartCoroutine(navigationData, transformData);
        }

        public void StopNavigate()
        {
            StopCoroutine();
        }

        private IEnumerator NavigateCoroutine(NavigationData navigationData, ActorTransformData transformData)
        {
            float timer = 0f;
            uint index = 0;
            while (true)
            {
                // 如果抵达了目标范围，强行让客户端停止
                if (Vector3.Distance(transformData.Position, navigationData.TargetPosition) <= 0.0001f)
                {
                    StopNavigate();
                    yield break;
                }
                if (index >= m_Path.corners.Length)
                {
                    yield break;
                }

                Vector3 target = m_Path.corners[index];


                timer += Time.deltaTime;
                Vector3 viewPosition = Vector3.Lerp(transformData.Position, target, timer / navigationData.StepTime);
                if (timer >= navigationData.StepTime)
                {
                    transformData.Position = target;
                    viewPosition = target;
                    timer = 0;
                    ++index;
                }
                
                transformData.ViewPosition = viewPosition;
                transform.position = viewPosition;
            }
        }
    }
}
