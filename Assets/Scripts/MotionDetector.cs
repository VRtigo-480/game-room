using UnityEngine;

public class MotionDetector : MonoBehaviour
{
    public Rigidbody targetRigidbody;
    public float velocityThreshold = 0.01f; // Minimum velocity to be considered moving
    public AudioSource motionStartSound;

    private bool wasMovingLastFrame = false;

    void Update()
    {
        if (targetRigidbody == null || motionStartSound == null)
        {
            Debug.LogWarning("MotionDetector: Missing Rigidbody or AudioSource reference.");
            return;
        }

        bool isMovingNow = targetRigidbody.linearVelocity.magnitude > velocityThreshold;

        // Detect when motion begins
        if (!wasMovingLastFrame && isMovingNow)
        {
            motionStartSound.Play();
            Debug.Log($"{targetRigidbody.name} started moving.");
        }

        wasMovingLastFrame = isMovingNow;
    }
}
