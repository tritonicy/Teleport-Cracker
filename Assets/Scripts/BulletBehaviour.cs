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


    Rigidbody2D myRigidbody;

    float bulletRotz;
    float bulletVelocity;

    void Start()
    {
        portalBehaviour = FindObjectOfType<PortalBehaviour>();
        playerController = FindObjectOfType<PlayerController>();
        arrowMovement = FindObjectOfType<ArrowMovement>();
        powerBar = FindObjectOfType<PowerBar>();

        myRigidbody = bullet.GetComponent<Rigidbody2D>();
        
        bulletRotz = arrowMovement.initialRotz;
        bulletVelocity = powerBar.fillAmount;
    }

    void instantiateBullet() {

    }
}
