using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmungusMovement : MonoBehaviour
{
    /*
    [SerializeField] float speed = 1;
    [SerializeField] float jumpForce = 1;
    [SerializeField] float gravity = 1;
    [SerializeField] float Damage = 1;

    [SerializeField] Transform myCamera;

    CharacterController controller;

    [SerializeField] Animator myAnimator;

    Vector3 movement;
    bool grounded;
    public bool isAlive = true;
    [SerializeField] PlayerStats myStats;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        speed = myStats.moveSpeed;
        jumpForce = myStats.jumpForce;
        gravity = myStats.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        bool stopAnimation = true;
        if (myStats.health <= 0 && stopAnimation == true)
        {
            isAlive = false;
            myAnimator.SetTrigger("isDead");
            stopAnimation = false;
        }
        if (isAlive == true)
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            Vector3 camForward = myCamera.forward;
            Vector3 camRight = myCamera.right;

            camForward.y = 0;
            camRight.Normalize();

            camRight.y = 0;
            camRight.Normalize();

            Vector3 forwardRelativeMovementVector = yInput * camForward;
            Vector3 rightRelativeMovementVector = xInput * camRight;

            var relativeMovement = (forwardRelativeMovementVector + rightRelativeMovementVector) * speed;

            if (xInput != 0 && yInput != 0)
                transform.forward = relativeMovement;
            relativeMovement.y = movement.y;
            movement = relativeMovement;

            movement.y += gravity * Time.deltaTime;

            if (xInput != 0 || yInput != 0)
            {
                myAnimator.SetBool("isRuning", true);
            }
            else
            {
                myAnimator.SetBool("isRuning", false);
            }

            if (controller.isGrounded)
            {
                movement.y = 0;
            }
            grounded = Physics.Raycast(transform.position + Vector3.down, Vector3.down, 1);

            myAnimator.SetBool("onGround", grounded);

            if (Input.GetButtonDown("Jump") && grounded)
            {
                movement.y = jumpForce;
                myAnimator.SetTrigger("jump");
            }

            controller.Move(movement * Time.deltaTime);
        } 
    }
    public void OnControllerColliderHit(ControllerColliderHit other)
    {
        if(other != null)
        {
            if (other.gameObject.GetComponent<SpikeLogic>())
            {
                doDamage();
            }
            if (other.gameObject.GetComponent<WinPole>())
            {
                SceneManager.LoadScene("WinScren");
            }
        }
    }
    private void doDamage()
    {
        myStats.health -= Damage * Time.deltaTime;
    }
*/
}
