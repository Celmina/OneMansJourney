using UnityEngine;
using TMPro;

public class LogCutter : MonoBehaviour, IInteractable
{
    private Inventory inventory;
    public GameObject Hatchet;
    public GameObject Radio;    // Add radio reference
    public GameObject largeLog;
    public GameObject movedLog;
    
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 2f;
    private float messageTimer = 0f;
    public GameObject backgroundPanel;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        movedLog.SetActive(false);
        
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
        bool hasHatchet = inventory.checkInventory(Hatchet);
        bool hasRadio = inventory.checkInventory(Radio);

        if (hasHatchet && hasRadio)
        {
            movedLog.SetActive(true);
            Destroy(largeLog);
        }
        else
        {
            if (messageText != null)
            {
                if (!hasHatchet && !hasRadio)
                {
                    messageText.text = "You need an Axe and a Radio to proceed";
                }
                else if (!hasHatchet)
                {
                    messageText.text = "You need an Axe to move it";
                }
                else if (!hasRadio)
                {
                    messageText.text = "You need to find the Radio before proceeding";
                }
                
                messageText.gameObject.SetActive(true);
                backgroundPanel.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }
}