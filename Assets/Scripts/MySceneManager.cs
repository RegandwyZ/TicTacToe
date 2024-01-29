using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{
   private const string GameScene = "Game";
   
   public void StartGame()
   {
      SceneManager.LoadScene(GameScene);
   }
}
