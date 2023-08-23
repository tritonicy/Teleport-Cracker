using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] GameObject playableZone;

    public Canvas instantiatedPowerBar;
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
            Destroy(arrowMovement.arrowHead.gameObject);
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
            
        if(instantiatedObjRect != null) {
            instantiatedObjRect.anchoredPosition = crosshairScreenPos;
        }
        else{
            ;
        }
            
        }
        return crosshairPosition;
    }

    void OnFire() {
        AudioManager.Instance.Play("click");
        
        if(isAimingArrow) {
            isAimingArrow = false;
            Destroy(instantiatedPowerBar.gameObject);
            if(GameObject.FindGameObjectsWithTag("bullet").Length < 1) {
                bulletBehaviour.InstantiateBullet();
            }
            
        }
        else{
            if(PlayerStats.playerAttempsLeft > 0) {
                if(playableZone.GetComponent<EdgeCollider2D>().bounds.Contains(crosshairposition)) {
                    firstPos = crosshairposition;
                    isAimingArrow = true;
                    arrowMovement.InstantiateArrow();
                    instantiatedPowerBar = Instantiate(prefabPowerBar,crosshairposition,Quaternion.identity);
                if(instantiatedPowerBar.GetComponent<RectTransform>() != null) {
                    instantiatedObjRect = instantiatedPowerBar.GetComponent<RectTransform>();
                }
                else
                    return;
            }
            
            }
        }
    }
}
