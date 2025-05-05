using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    public Animator animator;
    public string animationTriggerName = "Door_animation"; // Set this in Animator

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Hand")) // XRHand joints are often named like "RightHand", "LeftHand"
        {
            animator.SetTrigger(animationTriggerName);
        }
    }
}








