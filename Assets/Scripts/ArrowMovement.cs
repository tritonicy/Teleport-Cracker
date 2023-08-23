using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject arrowHeadPrefab;
    public GameObject arrowHead;
    public float initialRotz;

    private void Start() {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void aim() {
        
        if(playerController.isAimingArrow) {
            
            arrowHead.transform.position = playerController.crosshairposition;

            Vector3 rotation = playerController.crosshairposition - playerController.firstPos;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            initialRotz = rotZ;

            arrowHead.transform.rotation = Quaternion.Euler(0,0,rotZ);
        }
    }

    public void InstantiateArrow() {
        arrowHead = Instantiate(arrowHeadPrefab,playerController.crosshairposition,Quaternion.identity);
    }
    public void DestroyArrow() {
        Destroy(arrowHead.gameObject);
    }
}
