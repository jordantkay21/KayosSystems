using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InventoryComponent : MonoBehaviour
{
    [SerializeField] InventoryData inventoryData;

    [Header("Item Detection Settings")]
    [SerializeField] SphereCollider col;
    [SerializeField] float collisionRadius;

    private void Start()
    {
        InitiateSphere();
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemComponent item = other.GetComponent<ItemComponent>();
        
        if (item != null)
        {
            DebugLogger.Log("Inventory System", $"Player has collided with an item.", DebugLevel.Verbose);
            item.Collect();
        }
    }
    private void InitiateSphere()
    {
        if(col == null)
        {
            col = GetComponent<SphereCollider>();
        }

        col.isTrigger = true;
        col.radius = collisionRadius;
    }


}
