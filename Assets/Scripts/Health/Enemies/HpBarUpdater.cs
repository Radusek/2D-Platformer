using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HealthSystem))]
public class HpBarUpdater : MonoBehaviour
{
    [SerializeField]
    private Slider hpBar;
    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        healthSystem.OnHpChanged += UpdateHpBar;
    }

    private void UpdateHpBar()
    {
        float hpFraction = healthSystem.GetHpFraction();
        hpBar.gameObject.SetActive(hpFraction < 1f);
        hpBar.value = hpFraction;
    }

    private void OnDisable()
    {
        healthSystem.OnHpChanged -= UpdateHpBar;
    }
}
