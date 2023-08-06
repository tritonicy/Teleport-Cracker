using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] GameObject portalPrefab;
    
    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Circle").Length < 1) {
            createPortal();
        }
    }

    void createPortal() {
        float randomX = Random.Range(0.5f,1f);
        float randomY = Random.Range(0f,1f);
        Vector3 randNum = new Vector3 (randomX,randomY,1f);
        GameObject portal = Instantiate(portalPrefab,Camera.main.ViewportToWorldPoint(randNum),Quaternion.identity);
    }
}
