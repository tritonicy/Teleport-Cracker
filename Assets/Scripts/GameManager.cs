using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas retryCanvas;
    public static GameManager Instance;

    public static int playerScore = 0;
    public static int playerAttempsLeft = 5;
    

    private void OnEnable() {
        Pickups.OnCoinCollected += pickupCoin;
    }

    private void OnDisable() {
        Pickups.OnCoinCollected -= pickupCoin;
    }
    private void Start() {
        if (Instance == null) {
            Instance = this;
        }
        else{
            Destroy(Instance.gameObject);
            return;
        }
        DontDestroyOnLoad(Instance);
    }
    private void Update() {
        if(playerAttempsLeft <= 0) {
            retryCanvas.gameObject.SetActive(true);
        }
        else {
            retryCanvas.gameObject.SetActive(false);
        }
    }

    public void TryAgainButton() {
        retryCanvas.gameObject.SetActive(false);
        playerAttempsLeft = 5;
        playerScore = 0;
        Destroy(FindObjectOfType<PlayerStats>().gameObject);
        SceneManagement.Instance.LoadNextScene(SceneManagement.Scene.MainMenu);
    }
    public static void pickupCoin() {
        GameManager.playerScore += 100;

        if(playerScore > PlayerPrefs.GetInt("HighScore",0)) {
            PlayerPrefs.SetInt("HighScore",playerScore);
        }
    }

    public void ExitButton() {
        Application.Quit();
    }
}
