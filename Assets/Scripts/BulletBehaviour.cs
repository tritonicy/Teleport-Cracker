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

  
    Rigidbody2D myRigidbody;


    float bulletRotz;
    public Vector2 bulletVelocity;
    float beforeShootFirstposx;
    float beforeShootFirstposy;


    void Start()
    {

        playerController = FindObjectOfType<PlayerController>();
        arrowMovement = FindObjectOfType<ArrowMovement>();
        
    }
    void Update() {
        if(playerController.isAimingArrow) {
            beforeShootFirstposx = playerController.firstPos.x;
            beforeShootFirstposy = playerController.firstPos.y;
        }
        bulletRotz = arrowMovement.initialRotz;

    }


    public void InstantiateBullet() {
        bulletVelocity = new Vector2 (Mathf.Clamp(playerController.crosshairposition.x-beforeShootFirstposx,-15f,15f),Mathf.Clamp(playerController.crosshairposition.y-beforeShootFirstposy,-15f,15f));
        instantiatedBullet = Instantiate(bulletPrefab,playerController.firstPos,Quaternion.identity);
        myRigidbody = instantiatedBullet.GetComponent<Rigidbody2D>();
        myRigidbody.velocity = bulletVelocity * 2f;
        instantiatedBullet.transform.rotation = Quaternion.Euler(0,0,bulletRotz -90);
    }

}


