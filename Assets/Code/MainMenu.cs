using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

        public string sceneName;
        public void PlayGame()
        {
            SceneManager.LoadScene(sceneName);
        }

        public void QuitGame() {
            Debug.Log("QUIT!");
            Application.Quit();
        }

}
