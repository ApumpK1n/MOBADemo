using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pumpkin
{
    public class UIDialog : MonoBehaviour
    {
        public enum UIState
        {
            NotLoad,
            Load,

        }

        protected UIState CurrentState = UIState.NotLoad;

        /// <summary>
        /// 资源首次加载完成后回调
        /// </summary>
        public virtual void OnLoad()
        {
            CurrentState = UIState.Load;
        }

        /// <summary>
        /// 显示界面
        /// </summary>
        public virtual void OnShow()
        {

        }

        /// <summary>
        /// 隐藏界面
        /// </summary>
        public virtual void OnHide()
        {

        }
    }
}
