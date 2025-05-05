using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public Transform handTransform; // Assign the XR hand transform
    public float triggerDistance = 0.1f;
    private bool hasTriggered = false;

    void Update()
    {
        if (!hasTriggered && Vector3.Distance(transform.position, handTransform.position) < triggerDistance)
        {
            animator.SetTrigger("Activate");
            hasTriggered = true;
        }
    }
}









