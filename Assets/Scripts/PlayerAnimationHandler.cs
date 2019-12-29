using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerAnimationHandler : MonoBehaviour
{
    public GameObject playerGraphicsObject;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        SetProperDirection();

        animator.SetFloat("horizontalSpeed", Mathf.Abs(rb.velocity.x));
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
