using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;
    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    public void TakeDamage(float amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        _currentHealth = MathF.Min(_currentHealth + amount, _maxHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
