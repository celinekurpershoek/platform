﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteChest : MonoBehaviour
{
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
            LevelManager.Instance.LevelCompleted();
        }
    }
}
