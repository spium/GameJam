using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : UnitySingleton<GameManager>
{
    private int _totalBraziers, _litBraziers;

    public override void Awake()
    {
        base.Awake();
        _totalBraziers = 0;
        _litBraziers = 0;
    }

    public void RegisterBrazier()
    {
        ++_totalBraziers;
    }

    public void BrazierChanged(bool lit)
    {
        if (lit) ++_litBraziers;
        else --_litBraziers;

        if (_litBraziers == _totalBraziers)
            End();
    }

    void End()
    {
        int curr = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("curr: " + curr + ", scenes: " + SceneManager.sceneCountInBuildSettings);
        if (curr < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(curr + 1);
        else
            Application.Quit();
    }

    void OnLevelWasLoaded(int level)
    {
        _totalBraziers = 0;
        _litBraziers = 0;
    }
}
