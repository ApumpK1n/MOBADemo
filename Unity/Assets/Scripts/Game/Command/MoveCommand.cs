using System;
using System.Collections.Generic;
using System.Linq;
using NFSDK;
using UnityEngine;

namespace Pumpkin
{

    public class MoveCommand : Cmd
    {

        public const NFMsg.AllCmdType CmdType = NFMsg.AllCmdType.Move;

        public int SceneId;

        // Pos
        public Vector3 Pos;

        // TargetPos
        public Vector3 TargetPos;

        // Rotation
        public float RotX;
        public float RotY;
        public float RotZ;
        public float RotW;

        public List<Vector3> MovePoints;
    }
}
