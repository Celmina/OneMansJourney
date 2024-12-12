using UnityEngine;

public class InitialInventorySetup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject Radio;    // Reference to Radio prefab
    public GameObject Hatchet;  // Reference to Hatchet/Axe prefab
    
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        
        if (inventory != null)
        {
            // Add items to inventory
            if (Radio != null)
            {
                inventory.addItem(Radio);
                Debug.Log("Radio added to inventory");
            }
            
            if (Hatchet != null)
            {
                inventory.addItem(Hatchet);
                Debug.Log("Hatchet added to inventory");
            }
        }
        else
        {
            Debug.LogError("No inventory found in scene!");
        }
    }
}