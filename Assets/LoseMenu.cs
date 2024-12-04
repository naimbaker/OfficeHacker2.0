using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
   
   public void PlayAgain()
   {
    SceneManager.LoadScene("Scenes/Game");
    Debug.Log("Play Again");


   }
   public void QuitGame()
   {
    Debug.Log("Quit");
    Application.Quit();
   }
        
    
}
