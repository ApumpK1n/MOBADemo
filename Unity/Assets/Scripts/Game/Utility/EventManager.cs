using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pumpkin.Utility
{
    /// <summary>
    /// 事件管理器
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class EventManager : SingletonBehaviour<EventManager>
    {
        private Dictionary<int, List<EventHandler>> listeners = new Dictionary<int, List<EventHandler>>();

        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        /// <summary>
        /// 添加事件监听
        /// </summary>
        public void AddListener(int eventID, EventHandler listener)
        {
            List<EventHandler> events = null;
            if (listeners.TryGetValue(eventID, out events))
            {
                events.Add(listener);
                return;
            }

            events = new List<EventHandler>();
            events.Add(listener);
            listeners.Add(eventID, events);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddListener<T>(T eventID, EventHandler listener) where T : Enum
        {
            List<EventHandler> events = null;
            int id = Convert.ToInt32(eventID);
            if (listeners.TryGetValue(id, out events))
            {
                events.Add(listener);
                return;
            }

            events = new List<EventHandler>();
            events.Add(listener);
            listeners.Add(id, events);
        }

        /// <summary>
        /// 通知事件
        /// </summary>
        public void Notification(int eventID, object sender, EventArgs args)
        {
            List<EventHandler> events = null;

            if (!listeners.TryGetValue(eventID, out events))
            {
                Debug.Log($"[notification]: no event({eventID}) exist.");
                return;
            }

            foreach (var handler in listeners[eventID])
            {
                if (!handler.Equals(null))
                    handler(sender, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Notification<T>(T eventID, object sender, EventArgs args) where T : Enum
        {
            List<EventHandler> events = null;
            int id = Convert.ToInt32(eventID);
            if (!listeners.TryGetValue(id, out events))
            {
                Debug.Log($"[notification]: no event({eventID}) exist.");
                return;
            }

            foreach (var handler in listeners[id])
            {
                if (!handler.Equals(null))
                    handler(sender, args);
            }
        }

        /// <summary>
        /// 移除事件所有监听
        /// </summary>
        public void RemoveEvent(int eventID)
        {
            List<EventHandler> handlers = null;
            if (!listeners.TryGetValue(eventID, out handlers))
                Debug.Log($"[remove event]: no event({eventID}) exist.");

            listeners.Remove(eventID);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveEvent<T>(T eventID) where T : Enum
        {
            List<EventHandler> handlers = null;
            int id = Convert.ToInt32(eventID);
            if (!listeners.TryGetValue(id, out handlers))
                Debug.Log($"[remove event]: no event({eventID}) exist.");

            listeners.Remove(id);
        }

        /// <summary>
        /// 移除事件中某个监听
        /// </summary>
        public void RemoveEvent(int eventID, EventHandler handler)
        {
            List<EventHandler> handlers = null;
            if (!listeners.TryGetValue(eventID, out handlers))
            {
                Debug.Log($"[remove event]: no event({eventID}) exist.");
                return;
            }
            else
            {
                if (handlers.Contains(handler))
                    handlers.Remove(handler);
                else
                    Debug.Log($"[remove event]: no EventHandler({handler}) exists in event({eventID}).");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void RemoveEvent<T>(T eventID, EventHandler handler) where T : Enum
        {
            List<EventHandler> handlers = null;
            int id = Convert.ToInt32(eventID);
            if (!listeners.TryGetValue(id, out handlers))
            {
                Debug.Log($"[remove event]: no event({eventID}) exist.");
                return;
            }
            else
            {
                if (handlers.Contains(handler))
                    handlers.Remove(handler);
                else
                    Debug.Log($"[remove event]: no EventHandler({handler}) exists in event({eventID}).");
            }
        }

        /// <summary>
        /// 移除所有事件中无效的监听
        /// </summary>
        public void RemoveRedundancies()
        {
            Dictionary<int, List<EventHandler>> tmp = new Dictionary<int, List<EventHandler>>();

            foreach (var item in listeners)
            {
                for (int i = item.Value.Count; i <= 0; i--)
                {
                    if (item.Value[i].Equals(null))
                        item.Value.RemoveAt(i);
                }

                if (item.Value.Count > 0)
                    tmp.Add(item.Key, item.Value);
            }

            listeners.Clear();
            listeners = tmp;

        }

        private void OnSceneLoaded(Scene s, LoadSceneMode mode)
        {
            RemoveRedundancies();
        }
    }
}
