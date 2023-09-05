using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] MovingObjectsSO movingObjectsSO;
    float estimatedTime;
    Vector3 vel;

    private void Start() {
        vel = movingObjectsSO.velocity;
    }
    private void FixedUpdate() {
        if(movingObjectsSO.moveType == 1) {
            estimatedTime += Time.deltaTime;
            Move();

            if(estimatedTime >= movingObjectsSO.moveTime) {
                MakeNegative(vel);
                estimatedTime = 0f;
        }
            Move();
        }
        else if (movingObjectsSO.moveType == 2) {
            Move();
        }
    }
    public void MakeNegative(Vector3 velocity) {
        vel = new Vector3(-velocity.x,-velocity.y);
    }

    private void Move() {
        transform.position += vel;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.gameObject.layer == LayerMask.NameToLayer("Box") || other.collider.gameObject.layer == LayerMask.NameToLayer("OutsideBoxes"))  {
            MakeNegative(vel);
        }
    }

}
