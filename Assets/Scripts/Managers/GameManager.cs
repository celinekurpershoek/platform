using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Packages.ServiceLocator;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void AddServiceLocators()
    {
        ServiceLocatorManager.Instance.Register<LevelManager>(new LevelManager());
    }

    public void Awake()
    {
        ServiceLocatorManager.Instance.Resolve<LevelManager>().Init();
        AudioManager.Instance.Play("Theme");

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}
