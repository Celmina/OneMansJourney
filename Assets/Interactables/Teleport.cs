using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour, IInteractable
{
    public string sceneName;
    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
