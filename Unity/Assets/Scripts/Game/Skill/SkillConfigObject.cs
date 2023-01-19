using Sirenix.OdinInspector;
using Sirenix.Utilities.Editor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Pumpkin
{
    public enum SkillType 
    {
        Passive, // 被动
        Proactive, // 主动
    }

    public enum SkillTargetType
    {
        Enemy,
        Ally,
        Self,
        All,
    }

    public enum DamageType
    {
        Physic = 0,
        Magic = 1,
        Real = 2,
    }

    [CreateAssetMenu(fileName = "技能配置", menuName = "技能|状态/技能配置")]
    [LabelText("技能配置")]
    public class SkillConfigObject : SerializedScriptableObject
    {
        // 技能ID: 英雄编号 + 技能ID 如: 0101
        [LabelText("技能ID"), DelayedProperty]
        public uint Id;
        // 技能名称
        public string Name;
        // 技能类型
        public SkillType Type;
        // 技能可作用对象
        public SkillTargetType TargetType;
        // 冷却时间
        public float CoolDown;

        //效果列表
        [OnInspectorGUI("BeginBox", append: false)]
        [LabelText("效果列表"), Space(30)]
        [ListDrawerSettings(Expanded = true, DraggableItems = false, ShowItemCount = false, HideAddButton = true)]
        [HideReferenceObjectPicker]
        public List<Effect> Effects = new List<Effect>();

        //[ShowInInspector]
        //public static bool Draggable;

        //[OnInspectorGUI("DrawSpace", append: true)]
        [OnInspectorGUI("EndBox", append: true)]
        [HorizontalGroup(PaddingLeft = 40, PaddingRight = 40)]
        [HideLabel, OnValueChanged("AddEffect"), ValueDropdown("EffectTypeSelect")]
        public string EffectTypeName = "(添加效果)";

        public IEnumerable<string> EffectTypeSelect()
        {
            var types = typeof(Effect).Assembly.GetTypes()
                .Where(x => !x.IsAbstract)
                .Where(x => typeof(Effect).IsAssignableFrom(x))
                .Where(x => x.GetCustomAttribute<EffectAttribute>() != null)
                .OrderBy(x => x.GetCustomAttribute<EffectAttribute>().Order)
                .Select(x => x.GetCustomAttribute<EffectAttribute>().EffectType);
            var results = types.ToList();
            results.Insert(0, "(添加效果)");
            return results;
        }

        private void AddEffect()
        {
            if (EffectTypeName != "(添加效果)")
            {
                var effectType = typeof(Effect).Assembly.GetTypes()
                    .Where(x => !x.IsAbstract)
                    .Where(x => typeof(Effect).IsAssignableFrom(x))
                    .Where(x => x.GetCustomAttribute<EffectAttribute>() != null)
                    .Where(x => x.GetCustomAttribute<EffectAttribute>().EffectType == EffectTypeName)
                    .FirstOrDefault();

                var effect = Activator.CreateInstance(effectType) as Effect;
                //effect.Enabled = true;
                //effect.IsSkillEffect = true;
                Effects.Add(effect);

                EffectTypeName = "(添加效果)";
            }
        }
#if UNITY_EDITOR
        [OnInspectorGUI("BeginBox", append: false)]
        [SerializeField, LabelText("自动重命名")]
        public bool AutoRename { get { return SkillConfigObject.AutoRenameStatic; } set { SkillConfigObject.AutoRenameStatic = value; } }
        public static bool AutoRenameStatic = true;

        private void OnEnable()
        {
            SkillConfigObject.AutoRenameStatic = UnityEditor.EditorPrefs.GetBool("AutoRename", true);
        }

        private void OnDisable()
        {
            UnityEditor.EditorPrefs.SetBool("AutoRename", SkillConfigObject.AutoRenameStatic);
        }


        #region GUI
        private void DrawSpace()
        {
            GUILayout.Space(20);
        }

        private void BeginBox()
        {
            //GUILayout.Space(30);
            SirenixEditorGUI.DrawThickHorizontalSeparator();
            GUILayout.Space(10);
            //SirenixEditorGUI.BeginBox("技能表现");
        }

        private void EndBox()
        {
            //SirenixEditorGUI.EndBox();
            GUILayout.Space(30);
            //SirenixEditorGUI.DrawThickHorizontalSeparator();
            //GUILayout.Space(10);
        }

        [OnInspectorGUI]
        private void OnInspectorGUI()
        {
            if (!AutoRename)
            {
                return;
            }

            RenameFile();
        }

        [Button("重命名配置文件"), HideIf("AutoRename")]
        private void RenameFile()
        {
            string[] guids = UnityEditor.Selection.assetGUIDs;
            int i = guids.Length;
            if (i == 1)
            {
                string guid = guids[0];
                string assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var so = UnityEditor.AssetDatabase.LoadAssetAtPath<SkillConfigObject>(assetPath);
                if (so != this)
                {
                    return;
                }
                var fileName = Path.GetFileName(assetPath);
                var newName = $"Skill_{this.Id}_{this.Name}";
                if (!fileName.StartsWith(newName))
                {
                    //Debug.Log(assetPath);
                    UnityEditor.AssetDatabase.RenameAsset(assetPath, newName);
                }
            }
        }
        #endregion
    }
#endif
}
