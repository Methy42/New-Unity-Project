using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemEntity
{
    public int id;
    public string name;
    public EffectEnity effect;
    public string detail;
    public GameObject itemGameObject;
    public Sprite itemPreviewImage;

    public ItemEntity(int id, string name, EffectEnity effect, string detail, GameObject itemGameObject, Sprite itemPreviewImage)
    {
        this.id = id;
        this.name = name;
        this.effect = effect;
        this.detail = detail;
        this.itemGameObject = itemGameObject;
        this.itemPreviewImage = itemPreviewImage;
    }
}