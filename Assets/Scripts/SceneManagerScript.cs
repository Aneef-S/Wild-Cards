using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{

    public enum SCENES
    {
        MENU_SCENE = 0,GAME_SCENE = 1
    };
    public void ChangeScene(SCENES scene)
    {
        SceneManager.LoadScene((int)scene);
    }
    

    public void LoadGameScene()
    {
        ChangeScene(SCENES.GAME_SCENE);
    }

   public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadMenuScene()
    {
        ChangeScene((SCENES.MENU_SCENE));
    }
}
