using UnityEngine;
using TMPro;

public class StartText : MonoBehaviour
{
    public TextMeshProUGUI objectiveText;
    public float displayTime = 5f;
    private float timer;

    void Awake()
    {
        Debug.Log("StartText script is awake");
        
        if (objectiveText == null)
        {
            Debug.LogError("ObjectiveText reference is missing!");
            return;
        }
    }

    void Start()
    {
        Debug.Log("StartText Start method called");
        
        if (objectiveText != null)
        {
            objectiveText.gameObject.SetActive(true);
            objectiveText.text = "You need to get signal! Get to the top of the tower!";
            timer = displayTime;
            Debug.Log("Text should be visible now: " + objectiveText.text);
        }
    }

    void Update()
    {
        if (objectiveText == null) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                objectiveText.gameObject.SetActive(false);
                Debug.Log("Text hidden after timer");
            }
        }
    }
}