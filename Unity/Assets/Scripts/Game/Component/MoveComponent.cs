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

        private Action m_OnEndNavigate;

        public class NavigationData
        {
            public Vector3 Position;
            public Vector3 TargetPosition;
            public float StepTime;
        }

        private void Awake()
        {
            m_NavMeshSurface = FindObjectOfType<NavMeshSurface>();
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

        public void StopNavigate()
        {
            StopCoroutine();
        }

        public void StartNavigate(Vector3[] points, ActorTransformData transformData, Action onEnd)
        {
            //先停止协程
            StopCoroutine();
            m_OnEndNavigate = onEnd;
            StartCoroutine(points, transformData);
        }

        private void StartCoroutine(Vector3[] points, ActorTransformData transformData)
        {
            m_NavigateCoroutine = StartCoroutine(NavigateCoroutine(points, transformData));
        }

        private IEnumerator NavigateCoroutine(Vector3[] points, ActorTransformData transformData)
        {
            int index = 0;
            Vector3 start = transformData.ViewPosition;
            while (index < points.Length)
            {
                // 如果抵达了目标范围，强行让客户端停止
                if (Vector3.Distance(start, points[points.Length - 1]) <= 0.0001f)
                {
                    StopNavigate();
                    yield break;
                }

                float timer = 0f;
                Vector3 target = points[index];

                if (!(Vector3.Distance(start, target) <= 0.01f)) 
                {
                    while (timer <= 1.0f) // TODO: 根据移速来算
                    {
                        timer += Time.deltaTime;
                        Vector3 viewPosition = Vector3.Lerp(start, target, timer / 1.0f);

                        transformData.ViewPosition = viewPosition;
                        yield return null;
                    }
                }
               
                transformData.ViewPosition = target;
                index++;
                start = target;
            }
            m_OnEndNavigate?.Invoke();
            m_OnEndNavigate = null;
        }
    }
}
