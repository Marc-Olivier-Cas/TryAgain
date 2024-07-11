using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator; // Référence à l'Animator du personnage

    void Start()
    {
        animator = GetComponent<Animator>(); // Récupérer l'Animator
    }

    void Update()
    {
        // Gérer les animations en fonction des entrées clavier
        UpdateAnimator();
    }

    void UpdateAnimator()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Déterminer les paramètres booléens de l'Animator en fonction des entrées de mouvement
        bool isMovingForward = moveVertical > 0 && moveHorizontal == 0;
        bool isMovingRight = moveVertical > 0 && moveHorizontal > 0;
        bool isMovingLeft = moveVertical > 0 && moveHorizontal < 0;
        bool isMovingBackward = moveVertical < 0 && (moveHorizontal > 0 || moveHorizontal < 0);

        // Mettre à jour les paramètres de l'Animator
        animator.SetBool("IsMovingForward", isMovingForward);
        animator.SetBool("IsMovingRight", isMovingRight);
        animator.SetBool("IsMovingLeft", isMovingLeft);
        animator.SetBool("IsMovingBackward", isMovingBackward);
    }
}
