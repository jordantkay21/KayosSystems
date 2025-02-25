using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;

public class InventoryMenuUI : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanel;
    [SerializeField] Transform itemContainer;
    [SerializeField] InventorySlotUI itemSlotPrefab;
    [SerializeField] InventoryData inventoryData;

    private List<InventorySlotUI> activeSlots = new List<InventorySlotUI>();

    private void Start()
    {
        inventoryPanel.SetActive(false); //Start closed
    }

    private void OnEnable()
    {
        InventoryData.OnInventoryChange += UpdateInventoryUI;
    }

    private void OnDisable()
    {
        InventoryData.OnInventoryChange -= UpdateInventoryUI;
    }

    [Button("Toggle Panel State")]
    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if (inventoryPanel.activeSelf)
            UpdateInventoryUI(null, 0); //Refresh UI
    }

    private void UpdateInventoryUI(ItemData _, int __)
    {
        // Clear existing slots
        foreach (var slot in activeSlots)
        {
            Destroy(slot.gameObject);
        }
        activeSlots.Clear();

        //Populate with new data
        foreach (var entry in inventoryData.items)
        {
            InventorySlotUI newSlot = Instantiate(itemSlotPrefab, itemContainer);
            newSlot.UpdateSlot(entry.item, entry.count);
            activeSlots.Add(newSlot);
        }
    }
}
