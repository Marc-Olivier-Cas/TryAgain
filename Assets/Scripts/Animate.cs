using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator PlayerAnimator;

    void Awake() {
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerAnimator.SetFloat("walk", Input.GetAxis("Vertical"));
    }
}
