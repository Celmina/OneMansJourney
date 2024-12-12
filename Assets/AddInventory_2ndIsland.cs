using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIController2 : MonoBehaviour
{

    public Image key;
    
    public GameObject Key;
    
    
    public TextMeshProUGUI messageText;
    private bool hasShownRadioMessage = false;
    
    private Inventory inventory;

    void Start()
{
    inventory = FindFirstObjectByType<Inventory>();
    
    if (key != null)
        key.gameObject.SetActive(false);
    else
        Debug.LogError("Key UI Image not assigned!");
        
    if (messageText != null)
        messageText.gameObject.SetActive(false);
    else
        Debug.LogError("Message Text not assigned!");
}

    void Update()
    {
        if (inventory.checkInventory(Key))
        {
            key.gameObject.SetActive(true);
            
            if (!hasShownRadioMessage)
            {
                ShowRadioMessage();
                hasShownRadioMessage = true;
            }
        }
       
    }

    void ShowRadioMessage()
    {
        messageText.text = "Unlock the doors with this key";
        messageText.gameObject.SetActive(true);
        Invoke("HideMessage", 5f);
    }


    void HideMessage()
    {
        messageText.gameObject.SetActive(false);
    }
}