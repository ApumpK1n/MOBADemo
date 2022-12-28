using System;
using System.Collections.Generic;
using System.Linq;
using NFSDK;
using UnityEngine;

namespace Pumpkin
{

    public class MoveCommand : Cmd
    {

        public const AllCmdType CmdType = AllCmdType.Move;

        // Pos
        public float PosX;
        public float PosY;
        public float PosZ;

        // TargetPos
        public float TargetPosX;
        public float TargetPosY;
        public float TargetPosZ;

        // Rotation
        public float RotX;
        public float RotY;
        public float RotZ;
        public float RotW;
    }
}
