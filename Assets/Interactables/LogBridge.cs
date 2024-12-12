using UnityEngine;
public class LogBridge : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject itemToUse;
    public GameObject wall;
    public GameObject walking_log;
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }
    public void Interact()
    {
        if (inventory.checkInventory(itemToUse))
        {
            walking_log.GetComponent<MeshRenderer>().enabled = true;
            Destroy(gameObject);
            Destroy(wall);
        }
    }
}