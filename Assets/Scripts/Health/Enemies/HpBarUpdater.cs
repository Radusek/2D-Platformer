using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthSystem))]
public class HpBarUpdater : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private bool showWhenFull = false;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    public void UpdateHpBar()
    {
        float hpFraction = healthSystem.GetHpFraction();
        hpBar.gameObject.SetActive(hpFraction > 0f && (showWhenFull || hpFraction < 1f));
        hpBar.value = hpFraction;
    }
}
