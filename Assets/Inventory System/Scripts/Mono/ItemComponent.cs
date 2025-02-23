using System;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class ItemComponent : MonoBehaviour
{
    [SerializeField] ItemData itemData;
    [SerializeField] int collectAmount;

    private Collider col;
    private Rigidbody rb;

    public static event Action<ItemData, int> OnCollection;

    private void Start()
    {
        InitiateComponents();
    }

    public void Collect()
    {
        DebugLogger.Log("Inventory System",$"Collected: {collectAmount} {itemData.ItemName}");
        OnCollection?.Invoke(itemData, collectAmount);
        Destroy(this.gameObject);
    }

    private void InitiateComponents()
    {
        if (col == null)
        {
            col = GetComponent<Collider>();
        }

        col.isTrigger = true;
        DebugLogger.Log("Inventory System", $"{itemData.ItemName}'s collider has been configured.", DebugLevel.Verbose);

        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.useGravity = false;
        rb.isKinematic = true;
        DebugLogger.Log("Inventory System", $"{itemData.ItemName}'s rigidbody has been configured.", DebugLevel.Verbose);
    }
}
