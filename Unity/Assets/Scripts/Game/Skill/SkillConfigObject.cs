using System;
using System.Collections.Generic;
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

    public class SkillConfigObject : ScriptableObject
    {
        // 技能ID: 英雄编号 + 技能ID 如: 0101
        public uint SkillID;
        // 技能名称
        public string SkillName;
        // 技能类型
        public SkillType SkillType;
        // 技能可作用对象
        public SkillTargetType SkillTargetType;
        // 冷却时间
        public float CoolDown;

        //效果列表
        public List<Effect> Effects = new List<Effect>();
    }
}
