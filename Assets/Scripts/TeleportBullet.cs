using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBullet : MonoBehaviour
{
    BulletBehaviour bulletBehaviour;
    PortalBehaviour portalBehaviour;

    PolygonCollider2D polygonCollider2D;
    
    private void Start() {

        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
        portalBehaviour = FindObjectOfType<PortalBehaviour>();

        polygonCollider2D = bulletBehaviour.instantiatedBullet.GetComponent<PolygonCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "portalentry") {
            bulletBehaviour.instantiatedBullet.transform.position = portalBehaviour.portalout.transform.position;
        }
    }
}
  