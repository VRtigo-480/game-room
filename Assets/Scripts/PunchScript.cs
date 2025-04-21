using UnityEngine;

public class PunchDetector : MonoBehaviour
{
    public float minPunchSpeed = 1.5f; // Minimum velocity to count as punch
    public float forceMultiplier = 100f;
    public Transform handVisual;
    public AudioSource source;

    private Vector3 lastPosition;
    private Vector3 velocity;

    void Start()
    {
        if (handVisual == null)
        {
            Debug.LogError("Hand visual is not assigned.");
        }

        lastPosition = handVisual.position;
        if (source == null)
        {
            source = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        velocity = (handVisual.position - lastPosition) / Time.deltaTime;
        lastPosition = handVisual.position;
    }

    private void OnCollisionEnter(Collider other)
    {
        if (other.CompareTag("PunchingBag"))
        {
            Rigidbody bagRb = other.attachedRigidbody;
            if (bagRb == null) return;

            float punchSpeed = velocity.magnitude;

            if (punchSpeed > minPunchSpeed)
            {
                Vector3 punchDir = velocity.normalized;
                Vector3 hitPoint = other.ClosestPoint(handVisual.position);

                bagRb.AddForceAtPosition(punchDir * punchSpeed * forceMultiplier, hitPoint, ForceMode.Impulse);

                if (source != null)
                {
                    source.Play();
                }
            }
        }
    }
}