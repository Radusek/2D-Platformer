using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : HealthSystem
{
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();

        HUDManager.Instance.SetPlayerHpBarActive(true);
        HUDManager.Instance.SetPlayerHpBarValue(GetHpFraction());
    }
    public override void TakeDamage(int amount, float invuTime = invulnerabilityTime)
    {
        bool shouldDie = base.TakeDamageAndCheckIfShouldDie(amount, invuTime);
        HUDManager.Instance.SetPlayerHpBarValue(GetHpFraction());

        if (shouldDie)
        {
            HUDManager.Instance.SetPlayerHpBarActive(false);
            base.Die();
        }
    }

    private float GetHpFraction()
    {
        return (float)currentHealth / maxHealth;
    }

}
