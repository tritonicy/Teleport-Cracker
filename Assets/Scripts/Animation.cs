using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] public Animator animator;
    public static Animation Instance;

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

    public void PlayFadein() {
        animator.Play("Fade_in");
    }

    public void PlayFadeout() {
        animator.Play("Fade_out");
    }
}
