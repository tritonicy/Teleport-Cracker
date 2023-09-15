using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RetryScript : MonoBehaviour
{
  public TextMeshProUGUI scoreText;
  public static RetryScript Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Update() {
        if(PlayerStats.Instance != null) {
            scoreText.text = GameManager.playerScore.ToString();
        }
    }
}
