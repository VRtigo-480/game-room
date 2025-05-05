using UnityEngine;

public class MotionDetector : MonoBehaviour
{
    public AudioSource sound;
    public float cooldownDuration = 0.7f;

    private float lastPlayTime = -Mathf.Infinity;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PunchingBag")) {
            sound.Play();
            lastPlayTime = Time.time;
        }
    }
}
