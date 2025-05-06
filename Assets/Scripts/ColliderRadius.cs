using UnityEngine;

public class ColliderRadius : MonoBehaviour
{
    public GameObject myObject;
    public Transform punchingBag;
    public Transform punchingBag2;
    private SphereCollider sphereCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sphereCollider=myObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, punchingBag.position);
        float distance2 = Vector3.Distance(transform.position, punchingBag2.position);
        sphereCollider.enabled = distance < 2 || distance2 < 2;
    }
}
