using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]
public class PauseMenu : MonoBehaviour
{
    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Cancel"))
        {
            if (!_canvas.enabled)
            {
                Time.timeScale = 0f;
                _canvas.enabled = true;
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        _canvas.enabled = false;
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
