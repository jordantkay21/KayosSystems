using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class InventoryComponent : MonoBehaviour
{
    [SerializeField] InventoryData inventoryData;

    
    SphereCollider col;
    float collisionRadius;

    private void Start()
    {
        InitiateComponents();
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
    private void InitiateComponents()
    {
        if(col == null)
        {
            col = GetComponent<SphereCollider>();
        }

        col.isTrigger = true;
        col.radius = collisionRadius;
    }


}
