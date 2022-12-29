
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

   public void PlayGame()
    {
       ActiveStone.isNewGame = true; 
       Time.timeScale = 1f;
       PauseMenu.gameIsPaused = false;
       SceneManager.LoadSceneAsync(1);


    }

}
