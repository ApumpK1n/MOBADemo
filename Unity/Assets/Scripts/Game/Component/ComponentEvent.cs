using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    public enum ComponentEvent
    {
        AnimationEvent = 100,

    }

    public class ComponentAnimationTriggerEventArgs : EventArgs
    {
        public AnimationClip AnimationClip;
    }
}
