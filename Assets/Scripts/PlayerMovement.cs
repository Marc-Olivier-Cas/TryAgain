using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement

    private Animator animator; // Référence à l'Animator du personnage
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Récupérer le Rigidbody
        animator = GetComponent<Animator>(); // Récupérer l'Animator
    }

    void Update()
    {
        Move();
        UpdateAnimator();
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;
        Vector3 newPosition = rb.position + movement * speed * Time.deltaTime;
        rb.MovePosition(newPosition);
    }

    void UpdateAnimator()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        bool isMovingForward = moveVertical > 0 && moveHorizontal == 0;
        bool isMovingBackward = moveVertical < 0 && moveHorizontal == 0;
        bool isMovingRight = moveHorizontal > 0 && moveVertical == 0;
        bool isMovingLeft = moveHorizontal < 0 && moveVertical == 0;
        bool isMovingForwardRight = moveVertical > 0 && moveHorizontal > 0;
        bool isMovingForwardLeft = moveVertical > 0 && moveHorizontal < 0;
        bool isMovingBackwardRight = moveVertical < 0 && moveHorizontal > 0;
        bool isMovingBackwardLeft = moveVertical < 0 && moveHorizontal < 0;

        animator.SetBool("IsMovingForward", isMovingForward);
        animator.SetBool("IsMovingBackward", isMovingBackward);
        animator.SetBool("IsMovingRight", isMovingRight);
        animator.SetBool("IsMovingLeft", isMovingLeft);
        animator.SetBool("IsMovingForwardRight", isMovingForwardRight);
        animator.SetBool("IsMovingForwardLeft", isMovingForwardLeft);
        animator.SetBool("IsMovingBackwardRight", isMovingBackwardRight);
        animator.SetBool("IsMovingBackwardLeft", isMovingBackwardLeft);
    }
}
