using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = true;
    [SerializeField] private bool closeTrigger = true;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player") && openTrigger)
        {
            myDoor.Play("Door_animation", 0, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && closeTrigger)
        {
            myDoor.Play("Door_close_animation", 0, 0.0f);
        }
    }
}

