using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchAttack : Attack
{
    private void Attack(Collision2D collision)
    {
        if (collision.gameObject.layer == (int)Layer.Player)
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Attack(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Attack(collision);
    }
}
