using UnityEngine;

public class UseItemOnObject : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject itemToUse;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }
    public void Interact()
    {
        if (inventory.checkInventory(itemToUse))
        {
            Destroy(gameObject);
            inventory.removeItem(itemToUse);
        }
        else
        {
            Debug.Log("You dont have the " + itemToUse.name);
        }
    }
}
