using UnityEngine;

public class DoorAnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] private bool openTrigger = false;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                myDoor.Play("Door_animation", 0, 0.0f);
                gameObject.SetActive(false);
            }
        }
    }
}
