using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TeleportBoat : MonoBehaviour, IInteractable
{
    public string sceneName;
    public GameObject FuelTank;  // Reference to fuel tank prefab
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 2f;
    private float messageTimer = 0f;
    private Inventory inventory;

    void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        if (messageText != null)
            messageText.gameObject.SetActive(false);
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
    }

    public void Interact()
    {
        if (inventory.checkInventory(FuelTank))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (messageText != null)
            {
                messageText.text = "The boat is not starting you need fuel";
                messageText.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }
}