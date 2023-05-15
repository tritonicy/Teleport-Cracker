using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject arrowIndicator;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject arrowHead;

    void Awake() {
        playerController = GetComponent<PlayerController>();    
    }
    void Update()
    {
        
    }

    public void aim() {
        
        Vector3 rotation = playerController.crosshairposition - playerController.transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        arrowHead.transform.rotation = Quaternion.Euler(0,0,rotZ);
        arrow.transform.rotation = Quaternion.Euler(0,0,rotZ);

    }
}
