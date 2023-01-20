using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class Ability
    {
        public Dictionary<Type, Component> Components { get; set; } = new Dictionary<Type, Component>();


        #region 创建实例
        public static Ability NewEntity(Type entityType, long id = 0)
        {
            var ability = Activator.CreateInstance(entityType) as Ability;
            //entity.InstanceId = IdFactory.NewInstanceId();
            //if (id == 0) entity.Id = entity.InstanceId;
            return ability;
        }

        private static void InitAbility(Ability entity, Ability parent)
        {
            //var preParent = entity.Parent;
            //parent.SetChild(entity);
            ////if (preParent == null)
            //{
            //    entity.Awake();
            //}
            //entity.Start();
        }

        #endregion

        #region Component
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

        public void RemoveComponent<T>() where T : Component
        {
            var component = Components[typeof(T)];
            if (component.Enable) component.Enable = false;
            //Component.Destroy(component);
            Components.Remove(typeof(T));
        }

        public T GetComponent<T>() where T : Component
        {
            if (Components.TryGetValue(typeof(T), out var component))
            {
                return component as T;
            }
            return null;
        }

        public bool HasComponent<T>() where T : Component
        {
            return Components.TryGetValue(typeof(T), out var component);
        }
        #endregion
    }
}
