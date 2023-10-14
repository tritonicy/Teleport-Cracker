using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pickups : MonoBehaviour
{
    [SerializeField] GameObject coin;
    public static event Action OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D other) {
        CameraShake.Instance.startShake();
        OnCoinCollected();
        if(other.gameObject.CompareTag("bullet")) {
            Destroy(coin.gameObject);
        }
    }
}
