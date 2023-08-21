using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance; 
    public static int currentLevelbyIndex;
    private void Awake() {
        Instance = this;
        currentLevelbyIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Start() {
        if(FindObjectsOfType<SceneManagement>().Length > 0) {
            DontDestroyOnLoad(FindObjectOfType<SceneManagement>().gameObject);
        }
    }
    public enum Scene{
        MainMenu,
        Level1
    };

    public void LoadNextLevel() {
        SceneManager.LoadScene(++currentLevelbyIndex);
    }

    public void LoadNextScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
        currentLevelbyIndex++;
    }
} 
