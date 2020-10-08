using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Packages.ServiceLocator;
using UnityEngine;

public class Player : MonoBehaviour
{
    private LevelManager levelManager => ServiceLocatorManager.Instance.Resolve<LevelManager>();
    
    private Health health;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        health = GetComponent<Health>();
        health.OnDeath += Death;
    }

    private void Death()
    {
        Destroy(gameObject);
        levelManager.ReloadCurrentLevel();
    }
}
