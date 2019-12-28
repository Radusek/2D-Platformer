using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "My Assets/Projectile")]
[System.Serializable]
public class Projectile : ScriptableObject
{
    public float fireRate;

    public bool gravityAffected;

    public float projectleSpeed;

    public GameObject prefab;
}
