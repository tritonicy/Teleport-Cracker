using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wind : MonoBehaviour
{  
    [SerializeField] [Range(-1f,1f)] float wind;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private float estimatedTime = 0f;

    private void FixedUpdate() {

        textMeshProUGUI.text = wind.ToString();
        if(estimatedTime < 3f) {
            estimatedTime += Time.deltaTime;
            if(estimatedTime > 3) {
                estimatedTime = 0f;
                wind = -wind;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.GetComponent<Rigidbody2D>() != null) {
            other.gameObject.GetComponent<Rigidbody2D>().velocity +=  new Vector2(wind,0f);
        }
    }
}