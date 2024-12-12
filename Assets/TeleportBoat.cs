using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TeleportBoat : MonoBehaviour, IInteractable
{
    public string sceneName;
    public GameObject FuelTank;
    public GameObject Battery1;
    public GameObject Battery2;
    public GameObject Battery3;
    public GameObject Battery4;
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 10f;
    private float messageTimer = 0f;
    private Inventory inventory;
    
    public CanvasGroup fadeOverlay;
    private bool isTransitioning = false;
    private float transitionTime = 3f;
    private float fadeTimer = 0f;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        if (messageText != null)
            messageText.gameObject.SetActive(false);
            
        if (fadeOverlay != null)
        {
            fadeOverlay.alpha = 0;
            fadeOverlay.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                messageText.gameObject.SetActive(false);
            }
        }

        if (isTransitioning)
        {
            fadeTimer += Time.deltaTime;
            fadeOverlay.alpha = fadeTimer / transitionTime;
            
            if (fadeTimer >= transitionTime)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    private bool HasAllBatteries()
    {
        return inventory.checkInventory(Battery1) &&
               inventory.checkInventory(Battery2) &&
               inventory.checkInventory(Battery3) &&
               inventory.checkInventory(Battery4);
    }

    public void Interact()
    {
        bool hasFuel = inventory.checkInventory(FuelTank);
        bool hasBatteries = HasAllBatteries();

        if (hasFuel && hasBatteries)
        {
            StartTransition();
        }
        else
        {
            if (messageText != null)
            {
                if (!hasFuel && !hasBatteries)
                {
                    messageText.text = "You are missing batteries for the radio and fuel for the boat. Go back over the river and find the missing pieces";
                }
                else if (!hasFuel)
                {
                    messageText.text = "The boat is not starting you need fuel! You will have to go back over the log and find the big tree. The fuel is there";
                }
                else if (!hasBatteries)
                {
                    messageText.text = "You don't have batteries for the radio! You need to goi back to the village to get all the batteries.";
                }
                
                messageText.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }

    private void StartTransition()
    {
        isTransitioning = true;
        fadeTimer = 0f;
        fadeOverlay.blocksRaycasts = true;
    }
}