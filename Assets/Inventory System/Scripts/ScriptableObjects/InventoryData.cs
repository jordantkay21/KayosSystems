using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "KayosStudios/Inventory/InventoryData")]
public class InventoryData : ScriptableObject
{
    public List<ItemEntry> items;

    [Serializable]
    public class ItemEntry
    {
        public ItemData item;
        public int count;
    }

    public static event Action<ItemData, int> OnInventoryChange;

    private void OnEnable()
    {
        DebugLogger.Log("Inventory System", $"{this.name} has been enabled!", DebugLevel.Verbose);
        ItemComponent.OnCollection += ModifyItemCount;
    }

    private void OnDisable()
    {
        ItemComponent.OnCollection -= ModifyItemCount;
    }

    public void ModifyItemCount(ItemData item, int amount)
    {
        ItemEntry entry = items.Find(i => i.item == item);

        if(entry == null)
        {
            entry = new ItemEntry { item = item, count = 0 };
            items.Add(entry);
        }

        entry.count += amount;

        if (entry.count < 0)
            entry.count = 0;

        OnInventoryChange?.Invoke(item, entry.count);

        DebugLogger.Log("InventorySystem", $"Inventory Updated: {item.ItemName} = {entry.count}");
    }
}
