using UnityEngine;

public class PickUpItem : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    void Start()
    { 
        inventory = FindFirstObjectByType<Inventory>();
        if (inventory == null)
        {
            Debug.Log("No Inventory found");
        }
    }
    public void Interact()
    {
        inventory.addItem(gameObject);
        Destroy(gameObject);
    }
}
