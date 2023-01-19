using System;
using System.Collections.Generic;

namespace Pumpkin
{
    public abstract class Component
    {
        public Dictionary<Type, Component> Components { get; set; } = new Dictionary<Type, Component>();
        public bool Enable;
        public virtual bool DefaultEnable { get; set; } = true;

        public virtual void Awake()
        {

        }

        public virtual void Awake(object initData)
        {

        }

        public virtual void Start()
        {

        }

        public virtual void Start(object initData)
        {

        }

        public virtual void OnSetParent(Component preParent, Component nowParent)
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnDestroy()
        {

        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance<T>();
            Components.Add(typeof(T), component);

            component.Awake();

            component.Enable = component.DefaultEnable;
            return component;
        }

        public T AddComponent<T>(object initData) where T : Component
        {
            var component = Activator.CreateInstance<T>();
            Components.Add(typeof(T), component);
          
            component.Awake(initData);
            component.Enable = component.DefaultEnable;
            return component;
        }
    }
}
