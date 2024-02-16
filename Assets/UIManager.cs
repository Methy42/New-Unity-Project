using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    public GameObject backpackPanel;
    public Button closeButton;

    // Start is called before the first frame update
    void Start()
    {
        // 获取BackpackPanel和CloseButton的引用
        backpackPanel = GameObject.Find("BackpackPanel");

        closeButton = backpackPanel.transform.Find("FooterContainer").Find("CloseButton").GetComponent<Button>();
        // Debug.Log(closeButton);

        backpackPanel.SetActive(false);
        // 添加CloseButton的点击事件监听
        closeButton.onClick.AddListener(HideBackpackPanel);
    }

    // Update is called once per frame
    void Update()
    {
        // 检测B键是否按下
        if (Input.GetKeyDown(KeyCode.B))
        {
            // 切换BackpackPanel的显示状态
            backpackPanel.SetActive(!backpackPanel.activeSelf);
        }
        if (backpackPanel.activeSelf == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void HideBackpackPanel()
    {
        // 隐藏BackpackPanel
        backpackPanel.SetActive(false);
    }
}
