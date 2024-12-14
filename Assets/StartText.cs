using UnityEngine;
using TMPro;

public class StartMessage : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public float displayTime = 5f;
    private float timer;
    public GameObject backgroundPanel;

    void Start()
    {
        // Make sure text is visible at start
        objectiveText.gameObject.SetActive(true);
        backgroundPanel.SetActive(true);
        objectiveText.text = "You need to find a Radio to see if anyone is out there!";
        timer = displayTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                // Explicitly disable the text object
                objectiveText.gameObject.SetActive(false);
                backgroundPanel.SetActive(false);
            }
        }
    }
}