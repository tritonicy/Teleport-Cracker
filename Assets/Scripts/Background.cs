using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    [SerializeField] RawImage rawImage;
    [SerializeField] Vector2 speed;

    private void Update() {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + speed*Time.deltaTime,rawImage.uvRect.size);
    }
}
