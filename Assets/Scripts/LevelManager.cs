using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager
{
    private static LevelManager instance;
    private string currentLevel;

    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LevelManager();
            }
            return instance;
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LevelCompleted()
    {
        AudioManager.Instance.Play("OpenChest");
        UIManager.Instance.ShowLevelCompletedMenu();
        Debug.Log("Gewonnen!");
    }
}
