using System;
using System.Collections.Generic;
using System.Linq;

namespace Pumpkin
{
    public class Ability
    {
        public Dictionary<Type, Component> Components { get; set; } = new Dictionary<Type, Component>();
        public List<Ability> Children { get; private set; } = new List<Ability>();

        #region 生命周期
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

        public virtual void OnSetParent(Ability preParent, Ability nowParent)
        {

        }

        public void Update(float delta)
        {
            // 先更自身组件
            foreach(var keyValue in Components)
            {
                keyValue.Value.Update(delta);
            }
            
            //再遍历子节点
            foreach(var ability in Children)
            {
                ability.Update(delta);
            }

        }

        public virtual void OnDestroy()
        {

        }
        #endregion

        #region 创建实例
        public static Ability Create(Type type)
        {
            var ability = NewAbility(type);
            InitAbility(ability);
            return ability;
        }

        public static T Create<T>() where T : Ability
        {
            Type type = typeof(T);
            Ability ability = Create(type);
            return ability as T;
        }

        private static Ability NewAbility(Type type, long id = 0)
        {
            var ability = Activator.CreateInstance(type) as Ability;
            //ability.InstanceId = IdFactory.NewInstanceId();
            //if (id == 0) entity.Id = entity.InstanceId;
            return ability;
        }

        private static void InitAbility(Ability ability)
        {
            // TODO 其他生命周期
            ability.Awake();
        }

        private static void InitAbility(Ability ability, object initData)
        {
            // TODO 其他生命周期
            ability.Awake(initData);
        }

        public Ability AddChild(Type type)
        {
            var ability = NewAbility(type);

            Children.Add(ability);

            InitAbility(ability);
            return ability;
        }

        public Ability AddChild<T>()
        {
            Type type = typeof(T);
            var ability = NewAbility(type);

            Children.Add(ability);

            InitAbility(ability);
            return ability;
        }

        public Ability AddChild<T>(object initData)
        {
            Type type = typeof(T);
            var ability = NewAbility(type);

            Children.Add(ability);

            InitAbility(ability, initData);
            return ability;
        }

        public Ability AddChild(Type type, object initData)
        {
            var ability = NewAbility(type);

            Children.Add(ability);

            InitAbility(ability, initData);
            return ability;
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
            component.OnDestroy();
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
