using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnEnemyTouch : Attack
{
    [SerializeField]
    private float explosionRadius = 1.4f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }

    private void Explode()
    {
        Collider2D[] targetsToDamage = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        
        foreach (var target in targetsToDamage)
        {
            if (target.gameObject.layer.IsInLayerMask(targetLayers))
                target.GetComponent<HealthSystem>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
