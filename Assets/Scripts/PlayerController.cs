using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{   
    public Vector3 firstPos;
    public Vector3 crosshairposition;
    public bool isAimingArrow = false;

    [SerializeField] GameObject crosshair;
    [SerializeField] ArrowMovement arrowMovement;
    [SerializeField] BulletBehaviour bulletBehaviour;
    [SerializeField] Canvas prefabPowerBar;

    Canvas instantiatedPowerBar;
    RectTransform instantiatedObjRect;

    private void Awake() {
        arrowMovement = FindObjectOfType<ArrowMovement>();
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
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
        if(GameObject.FindGameObjectsWithTag("powerbar").Length > 0 ) {
            
            Vector2 crosshairScreenPos = new Vector2(crosshairPosition.x + 3, crosshairPosition.y + 2);
            
            instantiatedObjRect.anchoredPosition = crosshairScreenPos;
            
        }
        return crosshairPosition;
    }

    void OnFire() {

        if(isAimingArrow) {
            isAimingArrow = false;
            Destroy(instantiatedPowerBar.gameObject);
            if(GameObject.FindGameObjectsWithTag("bullet").Length < 1) {
                bulletBehaviour.InstantiateBullet();
            }
            
        }
        else{
            if(Camera.main.WorldToViewportPoint(crosshairposition).x < 0.5f) {
                firstPos = crosshairposition;
                isAimingArrow = true;
                instantiatedPowerBar = Instantiate(prefabPowerBar,crosshairposition,Quaternion.identity);
                instantiatedObjRect = instantiatedPowerBar.GetComponent<RectTransform>();
            }
        }
    }
    void OnDeleteBullet() {
        Destroy(bulletBehaviour.instantiatedBullet.gameObject);
    }
}
