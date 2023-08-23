using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadePersist : MonoBehaviour
{
    private static FadePersist Instance;

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
