using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class Hero : Actor
    {
        private ActorTransformData m_ActorTransform;

        private Vector3 m_Offset;

        protected override void AddActorData()
        {
            AddActorData(new ActorBaseData() { ActorType = ActorType.Hero });
            m_ActorTransform = new ActorTransformData();
            AddActorData(m_ActorTransform);
        }

        protected override void AddActorComponent()
        {
            gameObject.AddComponent<MoveComponent>();
        }

        protected override void AddActorAbility()
        {
            base.AddActorAbility();

            Ability.Create<DamageAbility>();
        }

        protected override void OnAwake()
        {
            m_Offset = transform.position - FootNode.position;

            m_ActorTransform.ViewPosition = FootNode.position;
        }

        protected override void Update()
        {
            base.Update();
            transform.position = m_ActorTransform.ViewPosition + m_Offset;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;

            Gizmos.DrawSphere(m_ActorTransform.ViewPosition, 1f);
        }
#endif
    }
}
