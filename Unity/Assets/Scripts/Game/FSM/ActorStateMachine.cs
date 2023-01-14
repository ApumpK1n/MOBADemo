using System;
using System.Collections.Generic;
using Pumpkin.FSM;
using UnityEngine;

namespace Pumpkin
{
    public enum ActorStateType
    {
        Idle = 0,
        Death = 1,
        Run = 2, // 导航
        Crit = 3, // 暴击
        Dance = 4,
        Laugh = 5,
        Recall = 6, // 回城

        Attack = 10, // 普攻
        Perform = 11, // 施法
    }

    public partial class ActorStateMachine : MonoBehaviour
    {
        public ActorStateType CurrentStateID => m_StateMachine.CurrentStateID;

        private StateMachine<ActorStateType> m_StateMachine;

        private void Awake()
        {
            var stateList = new List<State<ActorStateType>>
            {
                new HeroIdleState<ActorStateType>(ActorStateType.Idle, this),
                new HeroAttackState<ActorStateType>(ActorStateType.Attack, this),
            };
            m_StateMachine = new StateMachine<ActorStateType>(stateList.ToArray(), ActorStateType.Idle);
        }

        public void ChangeState(ActorStateType heroStateType)
        {
            m_StateMachine.ChangeState(heroStateType);
        }

        private void Update()
        {
            m_StateMachine.Update(Time.deltaTime);
        }
    }
}
