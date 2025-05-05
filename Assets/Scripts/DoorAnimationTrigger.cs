using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    private Animator animator;
    private bool hasOpened = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasOpened && other.CompareTag("Hand"))
        {
            animator.Play("Door_animation");
            hasOpened = true;
        }
    }
}

