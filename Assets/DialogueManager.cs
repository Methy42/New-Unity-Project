using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dialogueOptionsPanel;
    public GameObject dialogueOptionTemplate;

    void Start()
    {
        dialogueOptionTemplate.SetActive(false);
        HideDialogueOptionsPanel();
    }

    public void ShowDialogueOptionsPanel(List<DialogueOption> dialogueOptions)
    {
        dialogueOptionsPanel.SetActive(true);
        Transform dialogueOptionsContentTransform = dialogueOptionsPanel.transform
        .Find("Scroll View")
        .Find("Viewport")
        .Find("DialogueOptionsContent");

        foreach (DialogueOption option in dialogueOptions)
        {
            // 调用 createDialogueOptionObject 生成 dialogueOptionObject
            // GameObject dialogueOptionObject = createDialogueOptionObject(option);
            
            // 将 dialogueOptionObject 放入 dialogueOptionsContent 中
            // dialogueOptionObject.transform.SetParent(dialogueOptionsContentTransform);

            generateDialogueOptionObject(option, dialogueOptionsContentTransform);
        }
    }

    public void HideDialogueOptionsPanel()
    {
        dialogueOptionsPanel.SetActive(false);
    }

    private void generateDialogueOptionObject(DialogueOption dialogueOption, Transform parent)
    {
        string objectName = "DialogueOption-" + dialogueOption.id;
        GameObject newDialogueOptionObject = GameObject.Find(objectName);

        if (newDialogueOptionObject == null)
        {
            newDialogueOptionObject = (GameObject)Instantiate(dialogueOptionTemplate, parent);
            newDialogueOptionObject.name = objectName;
        }

        Transform iconTransform = newDialogueOptionObject.transform.Find("Icon");
        Image iconImage = iconTransform.GetComponent<Image>();
        iconImage.sprite = dialogueOption.iconImage;

        Transform labelTransform = newDialogueOptionObject.transform.Find("Label");
        Text labelText = labelTransform.GetComponent<Text>();
        labelText.text = dialogueOption.content;

        Transform shortcutTransform = newDialogueOptionObject.transform.Find("Shortcut");
        Text shortcutText = shortcutTransform.GetComponent<Text>();
        shortcutText.text = "[ " + dialogueOption.shortcut + " ]";

        newDialogueOptionObject.SetActive(true);
    }
}