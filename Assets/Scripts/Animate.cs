using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator playerAnimator;

    void Awake() {
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Récupérer les entrées horizontales et verticales pour mettre à jour les animations
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Mettre à jour les animations de marche
        playerAnimator.SetFloat("walk", Mathf.Abs(moveVertical));
        playerAnimator.SetFloat("walkSideLeft", moveHorizontal < 0 ? Mathf.Abs(moveHorizontal) : 0);
        playerAnimator.SetFloat("walkSideRight", moveHorizontal > 0 ? Mathf.Abs(moveHorizontal) : 0);
    }
}
