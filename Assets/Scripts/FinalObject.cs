using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(FindObjectOfType<BulletBehaviour>().instantiatedBullet.gameObject);
        SceneManagement.Instance.LoadNextLevel();
    }
}
