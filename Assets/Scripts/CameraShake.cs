using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float durationTime = 1f;
    public AnimationCurve curve;
    public static CameraShake Instance;

    private void Start() {
        Instance = this;
    }
    private IEnumerator Shake() {
        Vector3 startPos = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < durationTime) {
            elapsedTime += Time.deltaTime;

            float strength = curve.Evaluate(elapsedTime/durationTime);
            transform.position = startPos + new Vector3(Random.insideUnitSphere.x,Random.insideUnitSphere.y,0f) * strength;
            yield return null;
        }
        transform.position = startPos;
        }
    
    public void startShake() {
        StartCoroutine(Shake());
    }
}
