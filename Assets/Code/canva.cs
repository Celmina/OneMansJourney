using UnityEngine;
using UnityEngine.SceneManagement;

public class canva : MonoBehaviour
{
 


    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void ResumeGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
