using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DartRespawnHandler : MonoBehaviour
{
    public GameObject prefab;
    private Transform attachPoint;
    private GameObject spawnedObject;
    public float degreesPerSecond = 2.0f;
    public int hoverPos = 0;
    void Start()
    {
        SpawnPrefab();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - attachPoint.position;
        spawnedObject.transform.position = Vector3.Lerp(
            spawnedObject.transform.position,
            spawnedObject.transform.position + offset,
            Time.deltaTime * degreesPerSecond
        );
        gameObject.transform.Rotate(0, degreesPerSecond * Time.deltaTime, 0);
    }

    public void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Dart")) SpawnPrefab();
    }

    public void SpawnPrefab() {
        spawnedObject = Instantiate(prefab, transform);
        attachPoint = spawnedObject.transform.Find("Attach Point");
        spawnedObject.transform.localPosition = new Vector3(0, hoverPos, 0);
    }

    public void OnGrab(SelectEnterEventArgs args) {
        spawnedObject.transform.parent = null;
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        if (rb) rb.isKinematic = false;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        return;
    }
}
