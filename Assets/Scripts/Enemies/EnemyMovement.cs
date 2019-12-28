using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float movementSpeed = 2f;

    private Transform target = null;

    [SerializeField]
    private LayerMask layersToChase;

    [SerializeField]
    private float chasingRange = 2f;

    private float minimalDistance = 0.2f;

    [SerializeField]
    private Vector2[] waypoints;
    private int currentWaypoint = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(LookForTargets());
    }

    private IEnumerator LookForTargets()
    {
        float targetCheckInterval = 0.4f;
        while(true)
        {
            CheckForTarget();
            yield return new WaitForSeconds(targetCheckInterval);
        }
    }

    private void CheckForTarget()
    {
        if (target != null)
        {
            if (!target.gameObject.activeSelf || (target.position - transform.position).magnitude > chasingRange)
                target = null;
        }

        if (target == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, chasingRange, layersToChase);
            if (colliders.Length > 0)
                target = colliders[0].transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (target != null)
        {
            MoveTo(target.position);
        }
        else
        {
            MoveTo(waypoints[currentWaypoint]);

            if (Mathf.Abs(transform.position.x - waypoints[currentWaypoint].x) < minimalDistance)
            {
                HeadToNextWaypoint();
            }
        }
    }

    private void MoveTo(Vector2 currentDestination)
    {
        float movementDirection = Mathf.Sign(currentDestination.x - transform.position.x);
        Vector2 vel = rb.velocity;

        if (Mathf.Abs(currentDestination.x - transform.position.x) > minimalDistance)
            vel.x = movementDirection * movementSpeed;
        else
            vel.x = 0f;

        rb.velocity = vel;
    }

    private void HeadToNextWaypoint()
    {
        currentWaypoint++;
        currentWaypoint %= waypoints.Length;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chasingRange);

        Gizmos.color = Color.red;
        foreach (var point in waypoints)
            Gizmos.DrawSphere(point, 0.1f);
    }
}
