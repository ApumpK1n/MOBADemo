using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    [Serializable]
    public class AnimationClipData
    {
        public AnimationStateType Type;
        public List<AnimationClip> Clips;
    }

    public class AnimationData : MonoBehaviour
    {
        public List<AnimationClipData> AnimationClips = new List<AnimationClipData>();
    }
}
