using UnityEngine;

public class InventoryHUDMenuUI : MonoBehaviour
{
    [SerializeField] InventoryData inventoryData;
    [SerializeField] InventorySlotUI[] hudSlots; //Assign 3 slots in inspector

    private void Start()
    {
        UpdateHUD(null, 0);
    }

    private void OnEnable()
    {
        InventoryData.OnInventoryChange += UpdateHUD;
    }

    private void OnDisable()
    {
        InventoryData.OnInventoryChange -= UpdateHUD;
    }
 
    private void UpdateHUD(ItemData _, int __)
    {
        for (int i=0; i<hudSlots.Length; i++)
        {
            if (i < inventoryData.items.Count)
            {
                var itemEntry = inventoryData.items[i];
                hudSlots[i].UpdateSlot(itemEntry.item, itemEntry.count);
            }
            else
            {
                hudSlots[i].ClearSlot();
            }
        }
    }
}
