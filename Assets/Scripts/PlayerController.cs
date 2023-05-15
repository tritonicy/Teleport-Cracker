using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
  
    public Vector3 crosshairposition;
    Vector3 firstPos;
    public bool isAimingArrow = false;
    float factor = 10.0f;
    [SerializeField] GameObject arrowHead;
    [SerializeField] GameObject arrow;
    void Update()
    {
        crosshairposition = moveCrosshair();
        if(isAimingArrow) {
        Vector3 rotation = crosshairposition - firstPos;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        arrowHead.transform.rotation = Quaternion.Euler(0,0,rotZ);
        scaleArrow(firstPos,crosshairposition);
        }
    }

    Vector3 moveCrosshair() {
        Vector3 crosshairPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshairPosition.z = 0f;
        transform.position = crosshairPosition;
        return crosshairPosition;
    }


    void OnFire() {
        firstPos = transform.position;

        if(isAimingArrow) {
            isAimingArrow = false;
        }
        else{
            isAimingArrow = true;
        }

    }
    void scaleArrow(Vector3 start, Vector3 end) {
         var dir = end - start;
         var mid = (dir) / 2.0f + start;
         arrow.transform.position = mid;
         arrow.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir);
         Vector3 scale = arrow.transform.localScale;
         scale.y = dir.magnitude * factor;
         arrow.transform.localScale = scale;
    }
        
}
