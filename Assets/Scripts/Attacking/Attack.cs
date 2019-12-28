using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected int damage = 5;

    [SerializeField]
    protected LayerMask targetLayers;
}

public static class MyExtensions
{
    public static bool IsInLayerMask(this int layer, LayerMask layerMask)
    {
        return layerMask == (layerMask | (1 << layer));
    }
}

    public enum Layer
{
    Player = 8,
    Enemy = 9
}
