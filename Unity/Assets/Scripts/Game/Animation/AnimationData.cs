using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public struct AnimationClipData
    {
        public AnimationStateType Type;
        public AnimationClip Clip;
    }

    public class AnimationData : MonoBehaviour
    {
        public List<AnimationClipData> AnimationClips = new List<AnimationClipData>();
    }
}
