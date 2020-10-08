using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int startHealth = 3;

    private int currentHealth;

    public Action OnDeath;

    private void Awake()
    {
        currentHealth = startHealth;
    }
    public int CurrentHealth
    {
        get => currentHealth;
        private set
        {
            currentHealth = value;
            if (currentHealth <= 0)
            {
                //Dead
                OnDeath?.Invoke();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Take Damage:{damage} {CurrentHealth}");
        AudioManager.Instance.Play("PlayerHit"); 
        CurrentHealth -= damage;
    }
}
