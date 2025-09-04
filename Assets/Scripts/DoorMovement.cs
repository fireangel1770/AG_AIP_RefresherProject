using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void DoorOpen()
    {
        animator.SetTrigger("Open");
    }
    public void DoorClosed()
    {
        animator.SetTrigger("Close");
    }
}
