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
        if (!hasOpened)
        {
            animator.Play("Door_animation");
            hasOpened = true;
        }
    }
}

