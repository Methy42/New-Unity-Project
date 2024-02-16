using System;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public Transform player;
    public float triggerDistance = 3f;
    public List<DialogueOption> dialogueOptions = new List<DialogueOption>();

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= triggerDistance)
        {
            DialogueManager.Instance.ShowDialogueOptionsPanel(dialogueOptions);
            foreach (DialogueOption option in dialogueOptions)
            {
                if (Input.GetKeyDown(Utils.GetKeyCodeFromString(option.shortcut)))
                {
                    // 触发事件
                    EventManager.Instance.TriggerEvent(option.eventName, null);
                }
            }
        }
        else
        {
            DialogueManager.Instance.HideDialogueOptionsPanel();
        }
    }

    public void OnMenuItemClick()
    {
        // 处理菜单项点击操作
        Debug.Log("Menu item clicked!");
    }
}
