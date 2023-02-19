using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Pumpkin.Utility
{
    public class NavMeshHelper
    {

        public static Vector3 SamplePosition(Vector3 sourcePosition)
        {
            NavMesh.SamplePosition(sourcePosition, out NavMeshHit hit, 1.0f, NavMesh.AllAreas);
            return hit.position;
        }
    }
}
