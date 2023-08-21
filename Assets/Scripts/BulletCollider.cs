using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    bool isFirstUpdate = true;
    BulletBehaviour bulletBehaviour;
    PowerBar powerBar;
    ParticleSystem m_particleSystem;

    Vector2 firstDir;
    void Start()
    {
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
        powerBar = FindObjectOfType<PowerBar>();
        m_particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    private void Update() {
        firstDir = bulletBehaviour.instantiatedBullet.GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        m_particleSystem.Play();

        Vector2 wallNormal = other.contacts[0].normal;

        Vector2 newDir = Vector2.Reflect(firstDir,wallNormal);

        bulletBehaviour.instantiatedBullet.GetComponent<Rigidbody2D>().velocity = newDir;
    }   

}
