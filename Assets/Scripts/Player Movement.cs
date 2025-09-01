using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Movement values
    [Header ("Movement values")]
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpPower = 10.0f;

    // variables
    Vector3 movementVector;

    // references
    Rigidbody rb;
    Ray ray;
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", movementVector.magnitude > 0);
        transform.forward = movementVector.normalized;
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        animator.SetBool("isJump", movementVector.magnitude > 0);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 inputVector = ctx.ReadValue<Vector2>();
        movementVector = new Vector3(inputVector.x, 0, inputVector.y);
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(movementVector * moveSpeed, ForceMode.Acceleration);
    }

}
