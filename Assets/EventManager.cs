using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManager : Singleton<EventManager>
{
    private Dictionary<string, Action<object>> eventDictionary = new Dictionary<string, Action<object>>();

    public void RegisterEvent(string eventName, Action<object> action)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null;
        }
        eventDictionary[eventName] += action;
    }

    public void TriggerEvent(string eventName, object eventData)
    {
        Action<object> thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke(eventData);
        }
    }

    public void UnregisterEvent(string eventName, Action<object> action)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= action;

            // 如果事件没有任何注册的处理函数，则从字典中删除该事件
            if (eventDictionary[eventName] == null)
            {
                eventDictionary.Remove(eventName);
            }
        }
    }
}