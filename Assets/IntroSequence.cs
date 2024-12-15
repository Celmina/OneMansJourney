using UnityEngine;
using TMPro;

public class IntroSequence : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI otherText; 
    private float timer = 10f;
    private int currentMessage = 0;
    private bool waitingForButton = false;

    private string[] messages = new string[]
    {
        "The year is 2100. You wake up in a dark, quiet bunker, confused and disoriented. Your last memories are from the year 2000—an entire century ago. The world as you know it no longer exists.",
        "The bunker is quiet. Too quiet. No conversations, no footsteps, no mechanical humming can be heard. Only your breath and the distant dripping of water break this oppressive silence.",
        "Something terrible has happened to civilization while you were sleeping. The only hope is to find other survivors, but first you have to get out of this bunker.",
        "Somewhere in this underground labyrinth is an exit. And possibly, answers about what exactly has happened over the past 100 years. FIND EXIT",
        ""
    };

    void Start()
    {
        // Start with cursor locked and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (messageText != null)
        {
            ShowNextMessage();
        }
    }

    void Update()
    {
        if (currentMessage < messages.Length)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    ShowNextMessage();
                }
            }
        }
        else
        {
            // All messages have been shown; hide the message text
            messageText.gameObject.SetActive(false);
            otherText.gameObject.SetActive(true);
            // Optionally, you can perform other actions here, such as loading a new scene
        }
    }

    void ShowNextMessage()
    {
        if (currentMessage < messages.Length)
        {
            messageText.text = messages[currentMessage];
            messageText.gameObject.SetActive(true);
            otherText.gameObject.SetActive(false);

            timer = 10f; // Reset timer for the next message

            currentMessage++;
        }
    }
}
