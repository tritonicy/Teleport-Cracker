using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalObject : MonoBehaviour
{
    CircleCollider2D circleCollider2D;
    private void Awake() {
        circleCollider2D = this.GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        SceneManagement.Instance.LoadNextLevel();
        Debug.Log(SceneManagement.currentLevelbyIndex);
    }
}
