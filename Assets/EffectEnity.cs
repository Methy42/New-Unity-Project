using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EffectTypeEnum {
    /** 增益 */ BUFF,
    /** 减益 */ DEBUFF,
    /** 伤害 */ DAMAGE,
    /** 治疗 */ HEAL,
    /** 恢复 */ RECOVER,
    /** 抵抗 */ RESIST,
    /** 护盾 */ SHIELD,
    /** 召唤 */ SUMMON,
    /** 变身 */ TRANSFORM,
    /** 触发 */ TRIGGER
};

public enum EffectTargetEnum {
    /** 自己 */ SELF,
    /** 敌人 */ ENEMY,
    /** 盟友 */ ALLY,
    /** 所有 */ ALL,
    /** 随机 */ RANDOM,
    /** 其他 */ OTHER
}

[System.Serializable]
public class EffectEnity
{
    /**   效果 ID  */ public int id;
    /**   效果名称  */ public string name;
    /**   效果等级  */ public int level;
    /**   效果类型  */ public EffectTypeEnum type;
    /**   效果目标  */ public EffectTargetEnum target;
    /**   效果动画  */ public GameObject effectGameObject;
    /**   效果描述  */ public string description;
    /** 效果属性列表 */ public List<EffectAttributeEntity> effectAttributeList;

    /**
     * 输出effect的描述
     */
    public override string ToString()
    {
        string typeString = "";
        string targetString = "";
        string attributesString = "";

        switch(type)
        {
            case EffectTypeEnum.BUFF:
                typeString = "增益";
                break;
            case EffectTypeEnum.DEBUFF:
                typeString = "减益";
                break;
            case EffectTypeEnum.DAMAGE:
                typeString = "伤害";
                break;
            case EffectTypeEnum.HEAL:
                typeString = "治疗";
                break;
            case EffectTypeEnum.RECOVER:
                typeString = "恢复";
                break;
            case EffectTypeEnum.RESIST:
                typeString = "抵抗";
                break;
            case EffectTypeEnum.SHIELD:
                typeString = "护盾";
                break;
            case EffectTypeEnum.SUMMON:
                typeString = "召唤";
                break;
            case EffectTypeEnum.TRANSFORM:
                typeString = "变身";
                break;
            case EffectTypeEnum.TRIGGER:
                typeString = "触发";
                break;
        }

        switch(target)
        {
            case EffectTargetEnum.SELF:
                targetString = "自己";
                break;
            case EffectTargetEnum.ALL:
                targetString = "所有";
                break;
            case EffectTargetEnum.ALLY:
                targetString = "盟友";
                break;
            case EffectTargetEnum.ENEMY:
                targetString = "敌人";
                break;
            case EffectTargetEnum.RANDOM:
                targetString = "随机";
                break;
            case EffectTargetEnum.OTHER:
                targetString = "其他";
                break;
        }

        foreach (EffectAttributeEntity attribute in effectAttributeList)
        {
            attributesString += $"[{attribute.attributeName}: {attribute.attributeValue}]";
        }

        return $"{name}[{level}级][{typeString}][{targetString}]{attributesString}{description}";
    }
}
