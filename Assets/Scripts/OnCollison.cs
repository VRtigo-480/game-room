using UnityEngine;

public class OnCollisionBounce : MonoBehaviour
{
    public string collisionTag = "";
    public GameObject targetArea;
    public float launchForce = 10f;
    public GameObject resetPosition;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(collisionTag))
        {
            Vector3 randomPoint = GetRandomPointInArea();
            Vector3 direction = (randomPoint - transform.position).normalized;
            rb.linearVelocity = direction * launchForce;
        }
        if (collision.gameObject.CompareTag("floor"))
        {
            rb.position = resetPosition.transform.position;
            rb.linearVelocity = Vector3.zero;
        }
    }

    Vector3 GetRandomPointInArea()
    {
        Collider areaCollider = targetArea.GetComponent<Collider>();

        Vector3 min = areaCollider.bounds.min;
        Vector3 max = areaCollider.bounds.max;

        return new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );
    }
}