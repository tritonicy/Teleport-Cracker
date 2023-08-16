using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BulletBehaviour : MonoBehaviour
{
    [HideInInspector] public GameObject instantiatedBullet;
    [SerializeField] GameObject bulletPrefab;

    PlayerController playerController;
    ArrowMovement arrowMovement;
    PowerBar powerBar;

  
    Rigidbody2D myRigidbody;


    float bulletRotz;
    Vector2 bulletVelocity;
    float beforeShootFirstposx;
    float beforeShootFirstposy;


    void Start()
    {

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


    public void InstantiateBullet() {
        bulletVelocity = new Vector2 (playerController.crosshairposition.x-beforeShootFirstposx,playerController.crosshairposition.y-beforeShootFirstposy);
        instantiatedBullet = Instantiate(bulletPrefab,playerController.firstPos,Quaternion.identity);
        myRigidbody = instantiatedBullet.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = bulletVelocity * 1.5f;
        instantiatedBullet.transform.rotation = Quaternion.Euler(0,0,bulletRotz -90);
    }

}


