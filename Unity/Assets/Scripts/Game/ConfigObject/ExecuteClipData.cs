using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Pumpkin
{
    [CreateAssetMenu(fileName = "ExecutionClip", menuName = "执行体/执行体片段")]
    public class ExecuteClipData : ScriptableObject
    {

        public float TotalTime { get; set; }
        public float StartTime;
        public float EndTime;

        public float Duration { get => (EndTime - StartTime); }

        [ShowInInspector]
        [DelayedProperty]
        [PropertyOrder(-1)]
        public string Name
        {
            get { return name; }
            set { name = value; /*AssetDatabase.ForceReserializeAssets(new string[] { AssetDatabase.GetAssetPath(this) }); AssetDatabase.SaveAssets(); AssetDatabase.Refresh();*/ }
        }

        public ExecuteClipType ExecuteClipType;


        [Space(10)]
        [ShowIf("ExecuteClipType", ExecuteClipType.Animation)]
        public ExecuteAnimationData AnimationData;
    }

    public enum ExecuteClipType
    {
        CollisionExecute = 0,
        ActionEvent = 1,
        Animation = 2,
        Audio = 3,
        ParticleEffect = 4,
    }

    [Serializable]
    public class ExecuteAnimationData
    {
        public AnimationClip AnimationClip;
    }
}
