using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    PortalBehaviour portalBehaviour;
    PlayerController playerController;
    ArrowMovement arrowMovement;
    PowerBar powerBar;
    Vector2 bulletpos;


    Rigidbody2D myRigidbody;

    float bulletRotz;
    Vector2 bulletVelocity;
    float beforeShootFirstposx;
    float beforeShootFirstposy;

    void Start()
    {
        portalBehaviour = FindObjectOfType<PortalBehaviour>();
        playerController = FindObjectOfType<PlayerController>();
        arrowMovement = FindObjectOfType<ArrowMovement>();
        powerBar = FindObjectOfType<PowerBar>();

    }
    void Update() {
        if(playerController.isAimingArrow) {
            beforeShootFirstposx = playerController.firstPos.x;
            beforeShootFirstposy = playerController.firstPos.y;
        }
        bulletRotz = arrowMovement.initialRotz;
    }


    public void instantiateBullet() {
        bulletVelocity = new Vector2 (playerController.crosshairposition.x-beforeShootFirstposx,playerController.crosshairposition.y-beforeShootFirstposy);
        GameObject instantiatedBullet = Instantiate(bullet,playerController.firstPos,Quaternion.identity);
        myRigidbody = instantiatedBullet.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = bulletVelocity * 1.5f;
        instantiatedBullet.transform.rotation = Quaternion.Euler(0,0,bulletRotz -90);
    }
}
