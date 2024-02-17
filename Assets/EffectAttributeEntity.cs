using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class EffectAttributeEntity
{
    /**  效果属性 ID  */ public int id;
    /**    效果 ID   */ public int effectId;
    /**  效果属性名称 */ public string attributeName;
    /**    效果等级   */ public int effectLevel;
    /**   效果属性值  */ public string attributeValue;
}