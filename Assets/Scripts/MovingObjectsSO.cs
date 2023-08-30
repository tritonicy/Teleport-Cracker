using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MovingObject", menuName = "MovingObjects/MovingObject")]
public class MovingObjectsSO : ScriptableObject
{
    public Vector3 velocity;
    public float moveTime;

}
