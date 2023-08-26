using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI attemptTXT;

    public static PlayerStats Instance;

    public static int playerScore = 0;
    public static int playerAttempsLeft = 5;
    
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
        scoreTXT.text = playerScore.ToString();
        attemptTXT.text = playerAttempsLeft.ToString();
  
        if(Input.GetKeyDown("x") && playerAttempsLeft > 0) {
            if(GameObject.FindGameObjectsWithTag("bullet").Length > 0) {
                    Destroy(FindObjectOfType<BulletBehaviour>().instantiatedBullet.gameObject);
                    playerAttempsLeft -= 1;
            }
            else if(FindObjectOfType<PlayerController>().isAimingArrow) {
                    FindObjectOfType<PlayerController>().isAimingArrow = false;
                    Destroy(FindObjectOfType<PlayerController>().instantiatedPowerBar.gameObject);
                    FindObjectOfType<ArrowMovement>().DestroyArrow();
                    playerAttempsLeft -= 1;
            }
        }
    }  

}
