using Animancer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    [RequireComponent(typeof(AnimancerComponent), typeof(AnimationData))]
    public class AnimationComponent : MonoBehaviour
    {
        private AnimancerComponent m_Animancer;

        private AnimationData m_AnimationData;

        private Dictionary<AnimationStateType, List<AnimationClip>> m_Clips = new Dictionary<AnimationStateType, List<AnimationClip>>();

        private void Awake()
        {
            m_Animancer = GetComponent<AnimancerComponent>();

            m_AnimationData = GetComponent<AnimationData>();

            ParseAnimationData();
        }


        public bool PlayAnimation(AnimationStateType type, int aniIndex=0)
        {
            if (m_Clips.TryGetValue(type, out List<AnimationClip> animationClips))
            {
                if (animationClips.Count <= aniIndex) return false;
                m_Animancer.Play(animationClips[aniIndex]);
                return true;
            }
            return false;
        }


        private void ParseAnimationData()
        {
            foreach (var clipData in m_AnimationData.AnimationClips)
            {
                m_Clips.Add(clipData.Type, clipData.Clips);
            }

        }

        
    }
}
