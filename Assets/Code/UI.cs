using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    
        public void PlayGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void QuitGame() {
            Debug.Log("QUIT!");
            Application.Quit();
        }

        private void ResumeGame(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
}
