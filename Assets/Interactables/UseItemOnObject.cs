using UnityEngine;

public class UseItemOnObject : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject itemToUse;
    public bool consumeItem;
    public bool destroyObject;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }

    public void Interact()
    {
        if (consumeItem)
        {
            FConsumeItem();
        }

        if (destroyObject)
        {
            Destroy(gameObject);
        }
    }

    private void FConsumeItem()
    {
        if (inventory.checkInventory(itemToUse))
        {
            inventory.removeItem(itemToUse);
        }
        else
        {
            Debug.Log("You dont have the " + itemToUse.name);
        }
    }
}

