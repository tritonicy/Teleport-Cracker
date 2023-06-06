using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    public  Vector3 firstPos;
    public Vector3 crosshairposition;
    public bool isAimingArrow = false;
    [SerializeField] GameObject crosshair;
    [SerializeField] ArrowMovement arrowMovement;
    [SerializeField] Canvas prefabPowerBar;
    Canvas instantiatedObj;


    private void Awake() {
        arrowMovement = FindObjectOfType<ArrowMovement>();
    }
    void Update()
    {
        crosshairposition = moveCrosshair();
        if(isAimingArrow) {
            arrowMovement.aim();
        }
        else{
            arrowMovement.arrowHead.enabled = false;
        }
    }

    Vector3 moveCrosshair() {
        Vector3 crosshairPosition;
        
        crosshairPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshairPosition.z = 0f;
        transform.position = crosshairPosition;
        if(isAimingArrow) {
            crosshair.transform.position = firstPos;
        }
        else{
            crosshair.transform.position = crosshairPosition;
        }
        if(FindObjectsOfType<Canvas>().Length > 0 ) {
            
            instantiatedObj.transform.position = Camera.main.WorldToViewportPoint(crosshairPosition);
            
        }

        return crosshairPosition;

    }

    void OnFire() {
        firstPos = crosshairposition;

        if(isAimingArrow) {
            isAimingArrow = false;
            Destroy(instantiatedObj);
        }
        else{
            isAimingArrow = true;
            instantiatedObj = Instantiate(prefabPowerBar,transform.position,Quaternion.identity);
            
            
        }
    }
    
}
