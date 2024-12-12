using UnityEngine;
using TMPro;

public class TriggerText : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float displayTime = 5f;
    private float timer;
    private bool hasTriggered = false;

    void Start()
    {
        messageText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = "The bridge is broken! You will have to knock down the tree, and get over the River.";
            timer = displayTime;
            hasTriggered = true;  // Only show once
        }
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                messageText.gameObject.SetActive(false);
            }
        }
    }
}