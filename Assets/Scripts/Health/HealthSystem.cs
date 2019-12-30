using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth;
    protected int currentHealth;

    [SerializeField]
    protected const float invulnerabilityTime = 0.5f;
    protected float lastDamageTakenTime;

    void Start()
    {
        Initialize();
    }

    protected void Initialize()
    {
        currentHealth = maxHealth;
        lastDamageTakenTime = Time.time;
    }

    protected bool TakeDamageAndCheckIfShouldDie(int amount, float invuTime = invulnerabilityTime)
    {
        if (Time.time <= lastDamageTakenTime + invuTime)
            return false;

        currentHealth -= amount;
        lastDamageTakenTime = Time.time;

        Debug.Log($"{gameObject.name} takes {amount} points of damage. Current hp is {currentHealth}.");

        return currentHealth <= 0;
    }

    public virtual void TakeDamage(int amount, float invuTime = invulnerabilityTime)
    {
        bool shouldDie = TakeDamageAndCheckIfShouldDie(amount, invuTime);
        if (shouldDie)
            Die();
    }
    protected void Die()
    {
        Destroy(gameObject);
    }
}
