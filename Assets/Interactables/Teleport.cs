using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour, IInteractable
{
    public string sceneName;
    public CanvasGroup fadeOverlay;
    private bool isTransitioning = false;
    private float transitionTime = 3f;
    private float fadeTimer = 0f;

    void Start()
    {
        if (fadeOverlay != null)
        {
            fadeOverlay.alpha = 0;
            fadeOverlay.blocksRaycasts = false;
        }
    }

    void Update()
    {
        if (isTransitioning)
        {
            fadeTimer += Time.deltaTime;
            fadeOverlay.alpha = Mathf.Clamp01(fadeTimer / transitionTime);
            
            if (fadeTimer >= transitionTime)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void Interact()
    {
        if (!isTransitioning)
        {
            StartTransition();
        }
    }

    private void StartTransition()
    {
        isTransitioning = true;
        fadeTimer = 0f;
        fadeOverlay.alpha = 0f;
        fadeOverlay.blocksRaycasts = true;
    }
}