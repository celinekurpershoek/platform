using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIManager : MonoBehaviour
{
    public static LevelUIManager Instance;
    public GameObject levelCompletedMenu;
    private PlayerMovement playerMovement;
    public GameObject mobileUi;


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        playerMovement = FindObjectOfType<PlayerMovement>();
        levelCompletedMenu.SetActive(false);

        #if UNITY_ANDROID
        mobileUi.SetActive(true);
        #else
        mobileUi.SetActive(false);
        #endif
    }

    public void PlayerMovesRight()
    {
        playerMovement.HorizontalMovementValue = 1;
    }
    
    public void PlayerMovesLeft()
    {
        playerMovement.HorizontalMovementValue = -1;
    }
    
    public void PlayerJump()
    {
        playerMovement.Jump();
    }

    public void ShowLevelCompletedMenu()
    {
        levelCompletedMenu.SetActive(true);
    }
}
