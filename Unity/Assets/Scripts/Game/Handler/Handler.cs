using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    public abstract class Handler<T> : IHandler where T : Cmd
    {

        public void Handle(Cmd cmd)
        {
            if (cmd == null)
            {
                Debug.LogError($"处理消息类型：{typeof(T)}, 内容为空");
                return;
            }

            // find Actor

            // now use Default Actor
            Hero hero  = GameSceneManager.Instance.DefaultActor;
            Run(hero, (T)cmd);
        }

        protected abstract void Run(Actor actor, T cmd);
    }
}
