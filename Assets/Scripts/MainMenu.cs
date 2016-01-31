using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //TODO fix this with actual level name
        SceneManager.LoadScene("level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
