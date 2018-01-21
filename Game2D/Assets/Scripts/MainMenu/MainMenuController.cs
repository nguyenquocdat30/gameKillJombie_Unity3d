using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public void PlayGame()
    {
        Application.LoadLevel("MainLevel");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BackMenu()
    {
        Application.LoadLevel("Mainmenu");
    }
    public void level1()
    {
        Application.LoadLevel("Level1");
    }
    public void level2()
    {
        Application.LoadLevel("Level2");
    }
    public void level3()
    {
        Application.LoadLevel("Level3");
    }
    public void level4()
    {
        Application.LoadLevel("Level4");
    }
}
