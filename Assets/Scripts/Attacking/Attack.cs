using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected int damage = 5;
}

public enum Layer
{
    Player = 8,
    Enemy = 9
}
