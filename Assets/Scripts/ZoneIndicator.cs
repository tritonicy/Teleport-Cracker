using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneIndicator : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] Animator animator;

    private void Awake() {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update() {
        if(!playerController.isAimingArrow && FindObjectOfType<BulletBehaviour>().instantiatedBullet == null) {
            animator.SetBool("IsIndicatorOn",true);
        }
        else{
            animator.SetBool("IsIndicatorOn",false);
        }
    }
}
