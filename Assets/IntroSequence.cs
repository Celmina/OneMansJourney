using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class IntroSequence : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button continueButton;
    private float timer = 5f;
    private int currentMessage = 0;
    private bool waitingForButton = false;
    
    private string[] messages = new string[]
    {
        "Gads ir 2100. Tu pamosties tumšā, klusā bunkurā, apjucis un dezorientēts. Tavas pēdējās atmiņas ir no 2000. gada - veselu gadsimtu atpakaļ. Pasaule, kādu tu to pazini, vairs neeksistē.",
        "Bunkurs ir kluss. Pārāk kluss. Nav dzirdamas ne sarunas, ne soļi, ne mehānismu dūkoņa. Tikai tava elpa un attāla ūdens pilēšana pārtrauc šo nomācošo klusumu.",
        "Kaut kas briesmīgs ir noticis ar civilizāciju, kamēr tu gulēji. Vienīgā cerība ir atrast citus izdzīvojušos, bet vispirms tev jātiek ārā no šī bunkura.",
        "Kaut kur šajā pazemes labirintā ir izeja. Un, iespējams, atbildes par to, kas īsti ir noticis šo 100 gadu laikā."
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