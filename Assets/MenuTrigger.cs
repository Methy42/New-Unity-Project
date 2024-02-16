using UnityEngine;

public class MenuTrigger : MonoBehaviour
{
    public GameObject menu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menu.SetActive(false);
        }
    }

    public void OnMenuItemClick()
    {
        // 处理菜单项点击操作
        Debug.Log("Menu item clicked!");
    }
}
