using UnityEngine;
using TMPro;  // Add this for TextMeshPro support

public class LogCutter : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject Hatchet;
    public GameObject largeLog;
    public GameObject movedLog;
    
    // Add reference for the UI text
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 2f;  // How long to show the message
    private float messageTimer = 0f;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        movedLog.SetActive(false);
        
        // Hide message at start
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        // Handle message timer
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }

    public void Interact()
    {
        if (inventory.checkInventory(Hatchet))
        {
            movedLog.SetActive(true);
            Destroy(largeLog);
        }
        else
        {
            // Show the message
            if (messageText != null)
            {
                messageText.text = "You need an Axe to move it";
                messageText.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }
}