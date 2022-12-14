using System;
using System.Collections.Generic;
using System.Linq;
using Pumpkin.FSM;
using UnityEngine;

namespace Pumpkin
{
    public class HeroRecallState<T> : State<T> where T : struct, IConvertible, IComparable, IFormattable
    {

        private AnimationComponent m_AnimationComponent;

        public HeroRecallState(T ID, MonoBehaviour behaviour) : base(ID, behaviour)
        {
            m_AnimationComponent = behaviour.GetComponentInChildren<AnimationComponent>();
        }

        public override void Enter()
        {
            m_AnimationComponent.PlayAnimation(AnimationStateType.Recall);
        }

        public override void Exit()
        {

        }
        public override void Update(float deltaTime)
        {

        }
    }
}
