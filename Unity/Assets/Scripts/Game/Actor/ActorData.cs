using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public enum ActorType
    {
        Hero,
        Soldier,
    }

    public class ActorData
    {

    }

    [Serializable]
    public class ActorTransformData : ActorData
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 ViewPosition;
    }

    [Serializable]
    public class ActorBaseData : ActorData
    {
        public ActorType ActorType;
    }

}
