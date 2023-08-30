using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] MovingObjectsSO movingObjectsSO;
    float estimatedTime;

    private void Update() {
            estimatedTime += Time.deltaTime;
            transform.position += movingObjectsSO.velocity;

            if(estimatedTime >= movingObjectsSO.moveTime) {
                MakeNegative(movingObjectsSO.velocity);
                estimatedTime = 0f;
            }
    }
    public void MakeNegative(Vector3 vel) {
        movingObjectsSO.velocity = new Vector3(-vel.x,-vel.y);
    }
}
