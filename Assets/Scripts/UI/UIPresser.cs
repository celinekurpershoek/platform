using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPresser : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler
{
    private PlayerMovement playerMovement;
    public int direction;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.HorizontalMovementValue = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.HorizontalMovementValue = 0;
    }
}
