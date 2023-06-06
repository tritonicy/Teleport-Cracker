using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] public SpriteRenderer arrowHead;

    void Awake() {
        playerController = FindObjectOfType<PlayerController>();   
        arrowHead = GetComponent<SpriteRenderer>();
    }

    public void aim() {
        
        if(playerController.isAimingArrow) {
            
            arrowHead.enabled = true;
            transform.position = playerController.crosshairposition;

            Vector3 rotation = playerController.crosshairposition - playerController.firstPos;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            arrowHead.transform.rotation = Quaternion.Euler(0,0,rotZ -90);
        }
    }
}
