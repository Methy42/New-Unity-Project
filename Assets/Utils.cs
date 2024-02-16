using System;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static KeyCode GetKeyCodeFromString(string shortcut)
    {
        return (KeyCode)System.Enum.Parse(typeof(KeyCode), shortcut);
    }
}