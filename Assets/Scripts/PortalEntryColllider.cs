using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntryColllider : MonoBehaviour
{   
    BulletBehaviour bulletBehaviour;

    [SerializeField] GameObject portalOut;

    void Start()
    {
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet") {
            bulletBehaviour.instantiatedBullet.transform.position = portalOut.transform.position;
        }
    }
}
