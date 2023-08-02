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
        DontDestroyOnLoad(this.transform);
    }


    public void NextLevel()
    {
        var activeScene = SceneManager.GetActiveScene().name;
        if (activeScene == "Home")
        {
            SceneManager.LoadScene(nextlevels[activeScene]);
        }
        else
        {
            StartCoroutine(WaitToNextLevel(activeScene));
        }
    }

    public IEnumerator WaitToNextLevel(string actualScene)
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(nextlevels[actualScene]);
    }
}
