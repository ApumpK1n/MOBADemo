using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin.Utility
{
    public class VectorHelper
    {

        public static UnityEngine.Vector3 PB2Unity(NFMsg.Vector3 vector3)
        {
            return new UnityEngine.Vector3(vector3.X, vector3.Y, vector3.Z);
        }
    }
}
