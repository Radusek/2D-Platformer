using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationHandler))]
public class ProjectileLauncher : MonoBehaviour
{
    public Projectile projectile;

    private float fireRate;
    private bool gravityAffected;
    private float projectileSpeed;
    private GameObject projectilePrefab;

    private float lastLaunchedTime;

    private PlayerAnimationHandler animationHandler;

    private void Start()
    {
        lastLaunchedTime = Time.time;
        animationHandler = GetComponent<PlayerAnimationHandler>();
        UpdateProjectile();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Time.time >= lastLaunchedTime + 1 / fireRate)
            {
                LaunchProjectile();
            }
        }
    }

    private void LaunchProjectile()
    {
        GameObject go = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = go.GetComponent<Rigidbody2D>();

        projectileRb.gravityScale = gravityAffected ? 1f : 0f;
        projectileRb.AddForce(animationHandler.GetCurrentDirection() * projectileSpeed * Vector2.right, ForceMode2D.Impulse);
        lastLaunchedTime = Time.time;
    }

    private void UpdateProjectile()
    {
        fireRate = projectile.fireRate;
        gravityAffected = projectile.gravityAffected;
        projectileSpeed = projectile.projectleSpeed;
        projectilePrefab = projectile.prefab;
    }
}
