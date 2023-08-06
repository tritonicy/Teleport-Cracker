using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] PlayerController playerController;


    private void Update() {
        updateBarPower();
    }
    private void Awake() {

        slider = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void updateBarPower() {
        float fillAmount = Mathf.Clamp(Mathf.Sqrt(Mathf.Pow(playerController.crosshairposition.x-playerController.firstPos.x,2f)
         + Mathf.Pow(playerController.crosshairposition.y-playerController.firstPos.y,2)) * 0.1f,0f,1f);

        slider.value = fillAmount;
        
    }
}
