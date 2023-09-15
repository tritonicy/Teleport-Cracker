using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI attemptTXT;

    public static PlayerStats Instance;

    private void Awake() {
        if(Instance == null) {
            Instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        scoreTXT.text = GameManager.playerScore.ToString();
        attemptTXT.text = GameManager.playerAttempsLeft.ToString();
  
        if(Input.GetKeyDown("x") && GameManager.playerAttempsLeft > 0) {
            if(GameObject.FindGameObjectsWithTag("bullet").Length > 0) {
                    Destroy(FindObjectOfType<BulletBehaviour>().instantiatedBullet.gameObject);
                    GameManager.playerAttempsLeft -= 1;
            }
            else if(FindObjectOfType<PlayerController>().isAimingArrow) {
                    FindObjectOfType<PlayerController>().isAimingArrow = false;
                    Destroy(FindObjectOfType<PlayerController>().instantiatedPowerBar.gameObject);
                    FindObjectOfType<ArrowMovement>().DestroyArrow();
                    GameManager.playerAttempsLeft -= 1;
            }
        }
    }  

}
