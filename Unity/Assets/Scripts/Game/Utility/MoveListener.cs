using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin.Utility
{
    public class MoveListener : MonoBehaviour
    {

        private CommandQueueModule m_CommandQueueModule;


        private void Awake()
        {
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

                    moveCommand.TargetPos = NavMeshHelper.SamplePosition(targetPos);
                    moveCommand.Pos = NavMeshHelper.SamplePosition(hero.FootNode.position);
                    moveCommand.SceneId = 1001;

                    m_CommandQueueModule.AddCmdToSendQueue(moveCommand);
                }
            }
        }
    }
}
