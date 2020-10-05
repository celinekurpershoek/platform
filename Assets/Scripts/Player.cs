using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        health = GetComponent<Health>();
        health.OnDeath += Death;
    }

    private void Death()
    {
        Destroy(this.gameObject);
        LevelManager.Instance.ReloadLevel();
    }
}
