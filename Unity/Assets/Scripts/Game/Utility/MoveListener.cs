using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin.Utility
{
    public class MoveListener : SingletonBehaviour<MoveListener>
    {

        private CommandQueueModule m_CommandQueueModule;

        protected override void Awake()
        {
            base.Awake();
            m_CommandQueueModule = GameInit.Instance.PluginManager.FindModule<CommandQueueModule>();
        }

        private void Update()
        {
            // 右键移动
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Actor")))
                {
                }
                else if (Physics.Raycast(ray, out hit, 100, 1 << LayerMask.NameToLayer("Map")))
                {
                    Vector3 targetPos = hit.point;
                    Hero hero = GameSceneManager.Instance.DefaultActor;

                    MoveCommand moveCommand = new MoveCommand();
                    moveCommand.PlayerId = "233";
                    moveCommand.SyncCmdType = NFMsg.AllCmdType.Move;

                    moveCommand.TargetPos = targetPos;//NavMeshHelper.SamplePosition(targetPos);
                    moveCommand.Pos = hero.FootNode.position; NavMeshHelper.SamplePosition(hero.FootNode.position);
                    moveCommand.SceneId = 1001;

                    m_CommandQueueModule.AddCmdToSendQueue(moveCommand);
                }
            }
        }
#if UNITY_EDITOR
        private Vector3[] m_DebugPoints;

        public void SetDebugPoints(Vector3[] points)
        {
            m_DebugPoints = points;
        }

        private void OnDrawGizmos()
        {
            if (m_DebugPoints == null) return;
            Gizmos.color = Color.red;

            for(int i=0; i< m_DebugPoints.Length; i++)
            {
                Gizmos.DrawSphere(m_DebugPoints[i], 1f);
            }
        }
#endif
    }
}
