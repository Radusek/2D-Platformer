using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private Transform feetPoint;

    [SerializeField]
    private LayerMask jumpableLayers;

    [SerializeField]
    private float jumpForce = 150f;

    [SerializeField]
    private float movementSpeed = 1f;


    [SerializeField]
    private float jumpGravityMultiplier = 1.5f;
    [SerializeField]
    private float fallGravityMultiplier = 2.5f;

    private float horizontalMovement = 0f;
    private bool shouldJump = false;

    [SerializeField]
    private Vector2 jumpBox;

    public UnityEvent OnLandEvent;

    // Start is called before the first frame update
    void Start()
    {
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
            shouldJump = true;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        CheckAirborneState();
        HandleGravity();
    }

    private void Move()
    {
        if (horizontalMovement == 0f)
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(0f, rb.velocity.y);
            }
        }
        else
        {
            Vector2 newVelocity = new Vector2(movementSpeed * horizontalMovement, rb.velocity.y);
            rb.velocity = newVelocity;
        }
    }

    private void Jump()
    {
        if (shouldJump && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(jumpForce * Vector2.up);
        }

        shouldJump = false;
    }

    private bool wasGrounded = true;

    private void CheckAirborneState()
    {
        if (wasGrounded != IsGrounded())
        {
            wasGrounded = !wasGrounded;
            if (wasGrounded)
                OnLandEvent.Invoke();
        }
    }

    private void HandleGravity()
    {
        float currentGravityMultiplier;
        if (rb.velocity.y > 0f && Input.GetKey(KeyCode.Space))
            currentGravityMultiplier = jumpGravityMultiplier;
        else
            currentGravityMultiplier = fallGravityMultiplier;

        rb.velocity += Vector2.up * Physics2D.gravity.y * (currentGravityMultiplier - 1f) * Time.fixedDeltaTime;

    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(feetPoint.position, new Vector2(jumpBox.x, jumpBox.y), 0f, jumpableLayers);

        return colliders.Length > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.4f);
        Gizmos.DrawCube(feetPoint.position, new Vector3(jumpBox.x, jumpBox.y, 0f));
    }
}