using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, string> nextlevels = new Dictionary<string, string>()
    {
        { "Home", "Level1" },
        { "Level1", "Level2" },
        { "Level2", "Level3" },
        { "Level3", "Home" },
    };

    private void Start()
    {
        PropsAltar.altarEvent += NextLevel;
    }


    public void NextLevel()
    {
        var activeScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nextlevels[activeScene]);
    }
}
