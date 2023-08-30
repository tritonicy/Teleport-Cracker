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

        if(Instance == null) {
            Instance = this;
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        currentLevelbyIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public enum Scene{
        MainMenu,
        Level1
    };

    public void LoadNextLevel() {
        StartCoroutine(LoadNextSceneRoutine());
    }

    private IEnumerator LoadNextSceneRoutine(Scene scene) {
        Animation.Instance.PlayFadein();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene.ToString());
        Animation.Instance.PlayFadeout();

        currentLevelbyIndex++;

        AudioManager.Instance.StopPlayAll();
        AudioManager.Instance.Play("snow");
    }
    public void LoadNextScene(Scene scene) {
        StartCoroutine(LoadNextSceneRoutine(scene));
    }
    
    private IEnumerator LoadNextSceneRoutine() {
        Animation.Instance.PlayFadein();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(++currentLevelbyIndex);
        Animation.Instance.PlayFadeout();

        AudioManager.Instance.StopPlayAll();
        AudioManager.Instance.Play("snow");
    }
} 
