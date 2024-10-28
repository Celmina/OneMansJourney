using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EndGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
}
