using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    Slider slider;
    [SerializeField] PlayerController playerController;
    public float fillAmount;
    public Vector2 m_velocity;
    public float crosshairMoveAmountx;
    public float crosshairMoveAmounty;


    private void Update() {
        updateBarPower();
    }
    private void Awake() {

        slider = GetComponentInChildren<Slider>();
        playerController = FindObjectOfType<PlayerController>();
    }

    void updateBarPower() {
        crosshairMoveAmountx = playerController.crosshairposition.x-playerController.firstPos.x;
        crosshairMoveAmounty = playerController.crosshairposition.y-playerController.firstPos.y;
        m_velocity = new Vector2 (Math.Abs(crosshairMoveAmountx),Math.Abs(crosshairMoveAmounty));
        fillAmount = Mathf.Clamp(Mathf.Sqrt(Mathf.Pow(crosshairMoveAmountx,2f)
         + Mathf.Pow(crosshairMoveAmounty,2)) * 0.1f,0f,1f);

        slider.value = fillAmount;
        
    }
}
