using System.Collections;
using System.Collections.Generic;
using Managers;
using Packages.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private LevelManager levelManager => ServiceLocatorManager.Instance.Resolve<LevelManager>();

    public void StartGame()
    {
        levelManager.LoadFirstLevel();
    }
}
