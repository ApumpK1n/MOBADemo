using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class ActorDataComponet : MonoBehaviour
    {
        [SerializeField]
        private Dictionary<string, ActorData> m_ActorDataDict = new Dictionary<string, ActorData>();


        public T GetActorData<T>() where T : ActorData
        {
            string name = typeof(T).ToString();
            m_ActorDataDict.TryGetValue(name, out ActorData data);
            return (T)data;
        }

        public void AddActorData<T>(T data) where T: ActorData
        {
            string name = typeof(T).ToString();
            m_ActorDataDict.Add(name, data);
        }
    }
}
