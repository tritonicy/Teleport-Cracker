using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEntryColllider : MonoBehaviour
{   
    PortalBehaviour portalBehaviour;
    BulletBehaviour bulletBehaviour;
    CircleCollider2D circleCollider2D;

    void Start()
    {
        portalBehaviour = FindObjectOfType<PortalBehaviour>();
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
        circleCollider2D = portalBehaviour.portalentry.GetComponent<CircleCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet") {
            bulletBehaviour.instantiatedBullet.transform.position = portalBehaviour.portalout.transform.position;
        }
    }
}
