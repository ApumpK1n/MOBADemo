using Animancer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class AnimationComponent : MonoBehaviour
    {
        [SerializeField]
        private AnimancerComponent m_Animancer;

        private AnimationData m_AnimationData;

        private Dictionary<AnimationStateType, AnimationClip> m_Clips = new Dictionary<AnimationStateType, AnimationClip>();

        private void Awake()
        {
            m_Animancer = GetComponent<AnimancerComponent>();

            m_AnimationData = GetComponent<AnimationData>();

            ParseAnimationData();
        }


        public bool PlayAnimation(AnimationStateType type)
        {
            if (m_Clips.TryGetValue(type, out AnimationClip animationClip))
            {
                m_Animancer.Play(animationClip);
                return true;
            }
            return false;
        }


        private void ParseAnimationData()
        {
            foreach (var clipData in m_AnimationData.AnimationClips)
            {
                m_Clips.Add(clipData.Type, clipData.Clip);
            }

        }

        
    }
}
