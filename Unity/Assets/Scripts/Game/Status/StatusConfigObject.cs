using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{

    public enum StatusType
    {
        Buff,
        Debuff,
        Other,
    }

    public class StatusConfigObject : ScriptableObject
    {
        public string StatusName;
        public StatusType StatusType;
        //能否堆叠
        public bool CanStack;
        public uint StackingTimes;

        // 效果列表
        public List<Effect> Effects = new List<Effect>();
    }
}
