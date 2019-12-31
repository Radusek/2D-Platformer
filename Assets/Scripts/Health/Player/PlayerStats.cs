using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : HealthSystem
{
    // Start is called before the first frame update
    void Start()
    {
        base.Initialize();
    }

    public override void TakeDamage(int amount, float invuTime = invulnerabilityTime)
    {
        bool shouldDie = base.SubtractHpAndCheckIfShouldDie(amount, invuTime);

        if (shouldDie)
        {
            base.Die();
        }
    }
}
