using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    [SerializeField] GameObject coin;
    
    void pickupCoin() {
        PlayerStats.playerScore += 100;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        CameraShake.Instance.startShake();
        pickupCoin();
        if(other.gameObject.CompareTag("bullet")) {
            Destroy(coin.gameObject);
        }
    }
}
