using UnityEngine;
using TMPro;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject Key;      
    public GameObject closedDoor;    
    public GameObject openedDoor;    
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 5f;  // Changed to 5 seconds for the longer message
    private float messageTimer = 0f;
    private bool hasShownMessage = false;
    public Animator Animator;
    public GameObject backgroundPanel;
    
    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        openedDoor.GetComponent<MeshRenderer>().enabled = false;
        if (messageText != null)
            messageText.gameObject.SetActive(false);
            backgroundPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                messageText.gameObject.SetActive(false);
                backgroundPanel.gameObject.SetActive(false);
            }
        }
    }

    public void Interact()
    {
        if (inventory.checkInventory(Key))
        {
            Animator.Play("DoorOpen");
            
            // Show success message
            if (!hasShownMessage && messageText != null)
            {
                messageText.text = "You reached other survivors on the radio! Get to your boat to get to them.";
                messageText.gameObject.SetActive(true);
                backgroundPanel.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
                hasShownMessage = true;
            }
        }
        else
        {
            if (messageText != null)
            {
                messageText.text = "You need a key to open this door";
                messageText.gameObject.SetActive(true);
                backgroundPanel.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }
}