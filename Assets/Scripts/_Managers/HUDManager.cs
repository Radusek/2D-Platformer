using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    [SerializeField]
    private Slider playerHpBar;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetPlayerHpBarValue(float fraction)
    {
        playerHpBar.value = fraction;
    }

    public void SetPlayerHpBarActive(bool isActive)
    {
        playerHpBar.gameObject.SetActive(isActive);
    }
}
