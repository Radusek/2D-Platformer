using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    private int currentHealth;

    [SerializeField]
    private const float invulnerabilityTime = 0.5f;
    private float lastDamageTakenTime;

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTakenTime = Time.time;
    }

    public void TakeDamage(int amount, float invuTime = invulnerabilityTime)
    {
        if (Time.time <= lastDamageTakenTime + invuTime)
            return;

        currentHealth -= amount;
        lastDamageTakenTime = Time.time;
        Debug.Log($"{gameObject.name} takes {amount} points of damage. Current hp is {currentHealth}.");

        if (currentHealth <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
