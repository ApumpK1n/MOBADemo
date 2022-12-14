using System;
using System.Collections.Generic;
using Pumpkin.FSM;
using UnityEngine;

namespace Pumpkin
{
    public enum HeroStateType
    {
        Idle = 0,
        Death = 1,
        Run = 2,
        Crit = 3, // 暴击
        Dance = 4,
        Laugh = 5,
        Recall = 6, // 回城

        Attack = 10, // 普攻
        Perform = 11, // 施法
    }

    public partial class HeroStateMachine : MonoBehaviour
    {
        public HeroStateType CurrentStateID => m_StateMachine.CurrentStateID;

        private StateMachine<HeroStateType> m_StateMachine;

        private void Awake()
        {
            var stateList = new List<State<HeroStateType>>
            {
                new HeroIdleState<HeroStateType>(HeroStateType.Idle, this),
            };
            m_StateMachine = new StateMachine<HeroStateType>(stateList.ToArray(), HeroStateType.Idle);
        }

        public void ChangeState(HeroStateType heroStateType)
        {
            m_StateMachine.ChangeState(heroStateType);
        }

        private void Update()
        {
            m_StateMachine.Update(Time.deltaTime);
        }
    }
}
