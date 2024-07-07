using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Définit la vitesse de déplacement
    public float moveSpeed = 5f;

    // Gestion par frame de l'entrée du joueur
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection; // Oriente le personnage dans la direction du déplacement
            transform.position += moveDirection * moveSpeed * Time.deltaTime; // Déplace le personnage
        }
    }
}
