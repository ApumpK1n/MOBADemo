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


        }

        protected abstract void Run(Actor actor, T cmd);
    }
}
