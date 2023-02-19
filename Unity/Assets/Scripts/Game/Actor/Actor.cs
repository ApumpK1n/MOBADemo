using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    [RequireComponent(typeof(ActorStateMachine), typeof(ActorDataComponet))]
    public class Actor : MonoBehaviour
    {

        public Transform FootNode;

        protected ActorStateMachine m_ActorStateMachine;
        protected ActorDataComponet m_ActorDataComponet;

        protected FightAbility m_FightAbility;


        private void Awake()
        {
            m_ActorStateMachine = GetComponent<ActorStateMachine>();
            m_ActorDataComponet = GetComponent<ActorDataComponet>();

            AddActorData();
            AddActorAbility();
            AddActorComponent();
        }

        protected virtual void AddActorData()
        {

        }

        protected virtual void AddActorComponent()
        {

        }

        protected virtual void AddActorAbility()
        {
            m_FightAbility = Ability.Create<FightAbility>();

            LoadSkillWithCodeBind("SkillConfigs/Skill_1001_Q", KeyCode.Q);
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

        private SkillAbility LoadSkillWithCodeBind(string path, KeyCode bindCode)
        {
            var config = AssetLoad.Load<SkillConfigObject>(path);
            var ability = m_FightAbility.AttachSkill(config);
            m_FightAbility.BindSkillInput(ability, bindCode);
            return ability;
        }

        public void Preform(int skillId)
        {
            m_FightAbility.PerformSkill(skillId);

        }

        private void Update()
        {
            m_FightAbility.Update(Time.deltaTime);
        }
    }
}
