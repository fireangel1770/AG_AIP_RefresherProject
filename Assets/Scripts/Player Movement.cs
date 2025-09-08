using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // Movement values
    [Header ("Movement values")]
    [SerializeField] float moveSpeed = 1.0f;
    [SerializeField] float jumpPower = 10.0f;

    // variables
    Vector3 movementVector;
    bool grounded = true;

    [SerializeField] UnityEvent OnJumped;
    [SerializeField] UnityEvent DoorEnter;
    [SerializeField] UnityEvent DoorExit;
    // references
    Rigidbody rb;
    [SerializeField] HealthSO Health;
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
        //OnGround();
        animator.SetBool("isRunning", movementVector.magnitude > 0);
        transform.forward = movementVector.normalized;
        animator.SetBool("onGround", IsOnGround());
    }
    public void OnGround()
    {
        //if (rb.linearVelocity.y > 0)
        //    return;

        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position + (Vector3.down), Vector3.down, out hit, 1))
        {
            if (hit.transform.gameObject.tag == "Ground")
            {
                Debug.DrawRay(playerTransform.position + (Vector3.down), Vector3.down, Color.green, 1);
                grounded = true;
                animator.SetBool("onGround", grounded);
            }
            else if (hit.transform.gameObject.tag != "Ground")
            {
                Debug.DrawRay(playerTransform.position + (Vector3.down), Vector3.down, Color.red, 1);
                grounded = false;
                animator.SetBool("onGround", grounded);
            }

        }
    }

    public bool IsOnGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerTransform.position + (Vector3.down), Vector3.down, out hit, 1))
        {
            if (hit.transform.gameObject.tag == "Ground")
            {
                return true;
            }
        }


            return false;
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
    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            int Layer = LayerMask.NameToLayer("Door");
            if (other.gameObject.layer == Layer)
            {
                DoorEnter?.Invoke();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            int Layer = LayerMask.NameToLayer("Door");
            if (other.gameObject.layer == Layer)
            {
                DoorExit?.Invoke();
            }
        }
    }
}
