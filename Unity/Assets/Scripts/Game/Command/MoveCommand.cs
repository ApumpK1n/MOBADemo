using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pumpkin
{

    public class MoveCommand : Cmd
    {

        public const uint CmdType = AllCmdType.Move;
        
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
