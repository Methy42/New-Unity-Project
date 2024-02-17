using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StoreManager : Singleton<StoreManager>
{
    public int Value { get; set; } = 0;
    public List<ItemEntity> itemList;
    public GameObject storePanel;
    public GameObject itemPreviewPanel;

    public GameObject itemTemplate;
    private ItemEntity currentPreviewItem;

    void Start()
    {
        itemTemplate.SetActive(false);
        HideStorePanel();
        HideItemPreviewPanel();

        // itemList = new ItemEntity[]
        // {
        //     new ItemEntity(1, "生命药剂", "恢复10点生命", "鲜红的药水像是血液一般", Resources.Load<GameObject>("bottlePotionHealth.fbx"), Resources.Load<Sprite>("bottlePotionHealth_000.png")),
        //     new ItemEntity(2, "魔法药剂", "恢复10点魔法", "散发着魔法的气息", Resources.Load<GameObject>("bottlePotionMana.fbx"), Resources.Load<Sprite>("bottlePotionMana0000.png"))
        // };

        EventManager.Instance.RegisterEvent("store.open", (object eventData) => { ShowStorePanel(); });
    }

    public void ShowStorePanel()
    {
        storePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

        Transform storeItemsContentTransform = storePanel.transform
        .Find("ItemsContainer")
        .Find("Viewport")
        .Find("StoreItemsContent");
        foreach (ItemEntity item in itemList)
        {
            generateStoreItemObject(item, storeItemsContentTransform);
        }
    }

    public void HideStorePanel()
    {
        storePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ShowItemPreviewPanel()
    {
        itemPreviewPanel.SetActive(true);
        // itemPreviewPanel.transform.Find("ItemPreview").GetComponent<RawImage>().sprite = currentPreviewItem.itemPreviewImage;
        itemPreviewPanel.transform.Find("ItemName").Find("Label").GetComponent<Text>().text = currentPreviewItem.name;
        itemPreviewPanel.transform.Find("ItemEffect").Find("Text").GetComponent<Text>().text = currentPreviewItem.effect.ToString();
        itemPreviewPanel.transform.Find("ItemDetail").Find("Text").GetComponent<Text>().text = currentPreviewItem.detail;
        itemPreviewPanel.transform.Find("Remarks").Find("Text").GetComponent<Text>().text = "点击右键购买";
    }

    public void HideItemPreviewPanel()
    {
        itemPreviewPanel.SetActive(false);
    }

    private void generateStoreItemObject(ItemEntity item, Transform parent)
    {
        string objectName = "StoreItem-" + item.id;
        GameObject newStoreItemObject = GameObject.Find(objectName);

        if (newStoreItemObject == null)
        {
            newStoreItemObject = (GameObject)Instantiate(itemTemplate, parent);
            newStoreItemObject.name = objectName;
        }

        Transform imageTransform = newStoreItemObject.transform.Find("Image");
        Image imageImage = imageTransform.GetComponent<Image>();
        imageImage.sprite = item.itemPreviewImage;

        EventTrigger imageEventTrigger = imageTransform.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => {
            currentPreviewItem = item;
            Debug.Log(currentPreviewItem);
            ShowItemPreviewPanel();
        });
        imageEventTrigger.triggers.Add(entry);

        EventTrigger.Entry entryExit = new EventTrigger.Entry();
        entryExit.eventID = EventTriggerType.PointerExit;
        entryExit.callback.AddListener((data) => {
            HideItemPreviewPanel();
        });
        imageEventTrigger.triggers.Add(entryExit);

        newStoreItemObject.SetActive(true);
    }
}
