using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public GameObject mobileUi;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        
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
}
