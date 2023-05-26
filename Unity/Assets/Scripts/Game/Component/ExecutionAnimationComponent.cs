using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Pumpkin.Utility;

namespace Pumpkin
{
    public class ExecutionAnimationComponent : Component
    {
        public AnimationClip AnimationClip { get; set; }

        public override void Awake(object initData)
        {
            AnimationClip = initData as AnimationClip;

            
        }


        public override void Execute()
        {
            ComponentAnimationTriggerEventArgs args = new ComponentAnimationTriggerEventArgs()
            {
                AnimationClip = AnimationClip,
            };
            EventManager.Instance.Notification(ComponentEvent.AnimationEvent, this, args);
        }
    }
}
