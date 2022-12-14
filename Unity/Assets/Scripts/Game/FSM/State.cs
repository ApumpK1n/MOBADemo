using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin.FSM
{
    public class State<T> where T : struct, IConvertible, IComparable, IFormattable
    {
        public T ID { get; private set; }
        protected readonly MonoBehaviour m_StateMachine;

        public State(T ID, MonoBehaviour stateMachine)
        {
            this.ID = ID;
            m_StateMachine = stateMachine;
        }

        /// <summary>
        /// 进入状态
        /// </summary>
        public virtual void Enter()
        {

        }

        /// <summary>
        /// 退出状态
        /// </summary>
        public virtual void Exit()
        {

        }

        /// <summary>
        /// 更新状态
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void Update(float deltaTime)
        {

        }
    }
}
