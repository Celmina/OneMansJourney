using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroSequence : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button continueButton;
    private float timer = 8f;
    private int currentMessage = 0;
    private bool waitingForButton = false;
    
    private string[] messages = new string[]
    {
        "The year is 2100. You wake up in a dark, quiet bunker, confused and disoriented. Your last memories are from the year 2000—an entire century ago. The world as you know it no longer exists.",
        "The bunker is quiet. Too quiet. No conversations, no footsteps, no mechanical humming can be heard. Only your breath and the distant dripping of water break this oppressive silence.",
        "Something terrible has happened to civilization while you were sleeping. The only hope is to find other survivors, but first you have to get out of this bunker.",
        "Somewhere in this underground labyrinth is an exit. And possibly, answers about what exactly has happened over the past 100 years."
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
        
        if (continueButton != null)
        {
            continueButton.gameObject.SetActive(false);
            continueButton.onClick.AddListener(OnButtonClick);
        }
    }

    void Update()
    {
        if (!waitingForButton)
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
    }

    void ShowNextMessage()
    {
        if (currentMessage < messages.Length)
        {
            messageText.text = messages[currentMessage];
            messageText.gameObject.SetActive(true);
            
            if (currentMessage == messages.Length - 1)
            {
                waitingForButton = true;
                continueButton.gameObject.SetActive(true);
                // Enable cursor for the button
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                timer = 5f;
            }
            
            currentMessage++;
        }
        else
        {
            messageText.gameObject.SetActive(false);
        }
    }

    void OnButtonClick()
    {
        messageText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        // Lock cursor again after button press
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}