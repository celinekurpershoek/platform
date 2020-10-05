using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
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
