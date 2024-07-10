using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // Récupérer les entrées horizontales et verticales pour permettre les déplacements diagonaux
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            // Déterminer la direction de déplacement en tenant compte des mouvements horizontaux et verticaux
            moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // Appliquer le saut
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Appliquer la gravité
        moveDirection.y -= gravity * Time.deltaTime;

        // Déplacer le personnage
        characterController.Move(moveDirection * Time.deltaTime);

        // Tourner le personnage uniquement sur l'axe Y
        float turn = Input.GetAxis("Horizontal");
        if (turn != 0)
        {
            transform.Rotate(0, turn * Time.deltaTime * speed * 10, 0);
        }
    }
}