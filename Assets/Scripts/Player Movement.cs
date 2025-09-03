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
    bool grounded = true;

    // references
    Rigidbody rb;
    Ray hit;
    [SerializeField] Animator animator;
    [SerializeField] Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        OnGround();
        animator.SetBool("isRunning", movementVector.magnitude > 0);
        transform.forward = movementVector.normalized;
    }
    public void OnGround()
    {
        if (Physics.Raycast(playerTransform.position + (Vector3.down / 2), Vector3.down, 1))
            if (tag == "Ground")
            {
                Debug.DrawRay(playerTransform.position + (Vector3.down/2), Vector3.down, Color.green, 1);
                grounded = true;
                animator.SetBool("onGround", grounded);
            }
            if(tag != "Ground")
            {
                Debug.DrawRay(playerTransform.position + (Vector3.down/2), Vector3.down, Color.red, 1);
                grounded = false;
                animator.SetBool("onGround", grounded);
            }
    }
    public void OnJump(InputAction.CallbackContext ctx)
    {
        animator.SetTrigger("isJump");
        if(ctx.performed)
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
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
