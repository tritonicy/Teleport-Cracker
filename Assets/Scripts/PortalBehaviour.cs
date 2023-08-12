using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    PlayerController playerController;
    BulletBehaviour bulletBehaviour;

    [SerializeField] GameObject portalEntryPrefab;
    [SerializeField] GameObject portalOutPrefab;


    public GameObject portalentry;
    public GameObject portalout;
    
    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
        bulletBehaviour = FindObjectOfType<BulletBehaviour>();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("portalentry").Length < 1) {
            createEntryPortal();
        }
        if (GameObject.FindGameObjectsWithTag("portalout").Length < 1) {
            createOutPortal();
        }
    }

    void createEntryPortal() {
        float randomX1 = Random.Range(0.05f,0.45f);
        float randomY = Random.Range(0.05f,0.95f);
        Vector3 randNum = new Vector3 (randomX1,randomY,1f);
        portalentry = Instantiate(portalEntryPrefab,Camera.main.ViewportToWorldPoint(randNum),Quaternion.identity);

    }
    void createOutPortal() {
        float randomX2 = Random.Range(0.55f,0.95f);
        float randomY = Random.Range(0.05f,0.95f);
        Vector3 randNum = new Vector3 (randomX2,randomY,1f);
        portalout = Instantiate(portalOutPrefab,Camera.main.ViewportToWorldPoint(randNum),Quaternion.identity);
    }


}
