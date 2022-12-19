using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    [RequireComponent(typeof(ActorStateMachine), typeof(ActorDataComponet))]
    public class Actor : MonoBehaviour
    {

        protected ActorStateMachine m_ActorStateMachine;
        protected ActorDataComponet m_ActorDataComponet;

        private void Awake()
        {
            m_ActorStateMachine = GetComponent<ActorStateMachine>();
            m_ActorDataComponet = GetComponent<ActorDataComponet>();

            AddActorData();
            AddActorComponet();
        }

        protected virtual void AddActorData()
        {

        }

        protected virtual void AddActorComponet()
        {

        }

        protected void AddActorData<T>(T data) where T : ActorData
        {
            m_ActorDataComponet.AddActorData(data);
        }

        public void ChangeState(ActorStateType actorStateType)
        {
            if (m_ActorStateMachine != null)
            {
                m_ActorStateMachine.ChangeState(actorStateType);
            }

        }

        public T GetActorData<T>() where T : ActorData
        {
            return m_ActorDataComponet.GetActorData<T>();
        }

    }
}
