using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreTXT;
    [SerializeField] TextMeshProUGUI attemptTXT;

    public static int playerScore = 000;
    public static int playerAttemps = 1;
    
    private void Update() {
        scoreTXT.text = playerScore.ToString();
        attemptTXT.text = playerAttemps.ToString();
        if(Input.GetKeyDown("x") || Input.GetKeyDown("X")) {
            playerAttemps += 1;
        }
    }
}
