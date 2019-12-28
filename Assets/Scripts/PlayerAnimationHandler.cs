using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationHandler : MonoBehaviour
{
    public GameObject playerGraphicsObject;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        SetProperDirection();
    }

    private void SetProperDirection()
    {
        Vector2 newScale = playerGraphicsObject.transform.localScale;

        if (rb.velocity.x > 0)
            newScale.x = 1f;
        else if (rb.velocity.x < 0)
            newScale.x = -1f;

        playerGraphicsObject.transform.localScale = newScale;
    }

    public float GetCurrentDirection()
    {
        return playerGraphicsObject.transform.localScale.x;
    }
}
