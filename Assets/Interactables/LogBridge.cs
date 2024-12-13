using UnityEngine;
using TMPro;

public class LogBridge : MonoBehaviour, IInteractable
{
    public Animator cameraAnimator;
    private Inventory inventory;
    public GameObject itemToUse;
    public GameObject wall;
    public GameObject walking_log;
    public TextMeshProUGUI messageText;
    public float messageDisplayTime = 5f;
    private float messageTimer = 0f;

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
        if (inventory.checkInventory(itemToUse))
        {
            cameraAnimator.Play("TreeFallingAnim");
            Destroy(wall);
        }
        else
        {
            if (messageText != null)
            {
                messageText.text = "You need an axe! Go back to the village to retrieve it";
                messageText.gameObject.SetActive(true);
                messageTimer = messageDisplayTime;
            }
        }
    }
}