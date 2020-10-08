using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Packages.ServiceLocator;
using UnityEngine;

public class LevelCompleteChest : MonoBehaviour
{
    private LevelManager levelManager => ServiceLocatorManager.Instance.Resolve<LevelManager>();

    private Animator animator;
    
    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            animator.Play("Chest Open");
            levelManager.LevelCompleted();
        }
    }
}
