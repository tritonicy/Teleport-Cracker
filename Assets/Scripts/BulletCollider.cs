using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    BulletBehaviour bulletBehaviour;
    PowerBar powerBar;

    Vector2 firstDir;
    void Start()
    {
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
        powerBar = FindObjectOfType<PowerBar>();
    }

    private void Update() {
        firstDir = bulletBehaviour.instantiatedBullet.GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Vector2 beforeHitDir = firstDir;
        Vector2 wallNormal = other.contacts[0].normal;

        Vector2 newDir = Vector2.Reflect(firstDir,wallNormal).normalized;
        
        bulletBehaviour.instantiatedBullet.GetComponent<Rigidbody2D>().velocity = newDir * 10f; 
    }

}
