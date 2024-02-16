using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueOption
{
    public int id;
    public string content;
    public Sprite iconImage;
    public string shortcut;
    public string eventName;

    public DialogueOption(int id, string content, Sprite iconImage, string shortcut, string eventName)
    {
        this.id = id;
        this.content = content;
        this.iconImage = iconImage;
        this.shortcut = shortcut;
        this.eventName = eventName;
    }
}
