using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
   private const string GameScene = "Game";
   
   public void StartGame()
   {
      SceneManager.LoadScene(GameScene);
   }
}
