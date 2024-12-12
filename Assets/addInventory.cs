using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIController : MonoBehaviour
{
    public Image radio;
    public Image hatchet;
    public Image fuelTank;

    
    public GameObject Radio;
    public GameObject Hatchet;
    public GameObject FuelTank;
  
    
    // Battery tracking
    public GameObject Battery1;
    public GameObject Battery2;
    public GameObject Battery3;
    public GameObject Battery4;
    
    public TextMeshProUGUI messageText;
    private bool hasShownRadioMessage = false;
    private bool hasShownSurvivorsMessage = false;
    
    private Inventory inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        radio.gameObject.SetActive(false);
        hatchet.gameObject.SetActive(false);
        fuelTank.gameObject.SetActive(false);
        messageText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (inventory.checkInventory(Radio))
        {
            radio.gameObject.SetActive(true);
            
            if (!hasShownRadioMessage)
            {
                ShowRadioMessage();
                hasShownRadioMessage = true;
            }
        }
        
        if (inventory.checkInventory(Hatchet))
        {
            hatchet.gameObject.SetActive(true);
        }
        
        if (inventory.checkInventory(FuelTank))
        {
            fuelTank.gameObject.SetActive(true);
        }

        // Check if all 4 batteries are found
        if (inventory.checkInventory(Battery1) && 
            inventory.checkInventory(Battery2) && 
            inventory.checkInventory(Battery3) && 
            inventory.checkInventory(Battery4) && 
            !hasShownSurvivorsMessage)
        {
            ShowSurvivorsMessage();
            hasShownSurvivorsMessage = true;
        }
    }

    void ShowRadioMessage()
    {
        messageText.text = "Oh no the radio has no batteries you need to find batteries to reach others";
        messageText.gameObject.SetActive(true);
        Invoke("HideMessage", 5f);
    }

    void ShowSurvivorsMessage()
    {
        messageText.text = "The radio turned on but there is no signal! Find your way to an island with a communication tower!";
        messageText.gameObject.SetActive(true);
        Invoke("HideMessage", 7f);
    }

    void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}