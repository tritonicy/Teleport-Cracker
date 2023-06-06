using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] PlayerController playerController;

    private void Update() {
        updateBarPower();
    }
    private void Awake() {
        slider = GetComponent<Slider>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void updateBarPower() {
        float fillAmount = Mathf.Clamp(Mathf.Sqrt(Mathf.Pow(playerController.crosshairposition.x,2f) + Mathf.Pow(playerController.firstPos.y,2)),0f,1f);
        slider.value = fillAmount;
    }
}
