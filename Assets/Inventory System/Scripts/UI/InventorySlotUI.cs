using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] Image itemIcon;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemCount;

    public void UpdateSlot(ItemData item, int count)
    {
        if (item == null || count <= 0)
        {
            ClearSlot();
            return;
        }

        itemIcon.sprite = item.ItemIcon;
        itemName.text = item.ItemName;
        itemCount.text = $"x{count}";
        itemIcon.enabled = true;
    }

    public void ClearSlot()
    {
        itemIcon.sprite = null;
        itemName.text = "";
        itemCount.text = "";
        itemIcon.enabled = false;
    }
}
