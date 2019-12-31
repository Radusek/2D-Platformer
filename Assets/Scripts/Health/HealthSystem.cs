using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    protected int currentHealth;

    [SerializeField]
    protected const float invulnerabilityTime = 0.5f;
    protected float lastDamageTakenTime;

    public UnityEvent OnHpChanged;

    void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        currentHealth = maxHealth;
        lastDamageTakenTime = Time.time;
    }
    public float GetHpFraction()
    {
        return (float)currentHealth / maxHealth;
    }

    public virtual void TakeDamage(int amount, float invuTime = invulnerabilityTime)
    {
        bool shouldDie = SubtractHpAndCheckIfShouldDie(amount, invuTime);
        if (shouldDie)
            Die();
    }

    protected bool SubtractHpAndCheckIfShouldDie(int amount, float invuTime = invulnerabilityTime)
    {
        if (Time.time <= lastDamageTakenTime + invuTime)
            return false;

        currentHealth -= amount;
        lastDamageTakenTime = Time.time;
        OnHpChanged?.Invoke();

        return currentHealth <= 0;
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
