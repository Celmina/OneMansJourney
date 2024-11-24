using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    // Reference to your canvas panel
    public GameObject canvasPanel;
    
    // Reference to the 4th button that should disable the cursor
    public Button fourthButton;

    void Start()
    {
        // Show cursor when the game starts (assuming canvas is active at start)
        if (canvasPanel.activeInHierarchy)
        {
            ShowCursor();
        }

        // Add listener to the fourth button
        if (fourthButton != null)
        {
            fourthButton.onClick.AddListener(HideCursor);
        }
    }

    void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Optional: Monitor canvas panel state changes
    void Update()
    {
        // If canvas becomes active, show cursor
        if (canvasPanel.activeInHierarchy && !Cursor.visible)
        {
            ShowCursor();
        }
    }

    // Optional: Clean up when script is disabled or destroyed
    void OnDisable()
    {
        if (fourthButton != null)
        {
            fourthButton.onClick.RemoveListener(HideCursor);
        }
    }
}