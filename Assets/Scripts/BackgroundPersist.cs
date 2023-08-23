using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPersist : MonoBehaviour
{
    private static BackgroundPersist Instance;

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
}
