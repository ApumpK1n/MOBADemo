using System;
using System.Collections.Generic;

namespace Pumpkin
{
    public abstract class Component
    {
        public Dictionary<string, Component> Components { get; set; } = new Dictionary<string, Component>();
        public bool Enable;
        public virtual bool DefaultEnable { get; set; } = true;

        public virtual void Awake()
        {

        }

        public virtual void Awake(object initData)
        {

        }

        public virtual void Execute()
        {

        }

        public virtual void Execute(object initData)
        {

        }

        public virtual void OnEndExecute()
        {

        }

        public virtual void OnSetParent(Component preParent, Component nowParent)
        {

        }

        public void Update(float delta)
        {
            PreUpdate(delta);

            foreach (var keyValue in Components)
            {
                keyValue.Value.Update(delta);
            }

            OnUpdate(delta);
        }

        public virtual void PreUpdate(float delta)
        {

        }

        public virtual void OnUpdate(float delta)
        {

        }

        public virtual void OnDestroy()
        {

        }

        public T AddComponent<T>() where T : Component
        {
            var component = Activator.CreateInstance<T>();
            Components.Add(typeof(T).ToString(), component);

            component.Awake();

            component.Enable = component.DefaultEnable;
            return component;
        }

        public T AddComponent<T>(object initData) where T : Component
        {
            var component = Activator.CreateInstance<T>();
            Components.Add(typeof(T).ToString(), component);
          
            component.Awake(initData);
            component.Enable = component.DefaultEnable;
            return component;
        }

        public T AddComponent<T>(string name, object initData) where T : Component
        {
            var component = Activator.CreateInstance<T>();
            Components.Add(name, component);

            component.Awake(initData);

            component.Enable = component.DefaultEnable;
            return component;
        }
    }
}
