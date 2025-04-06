using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform teleportTarget;    // Drag a destination GameObject here
    public GameObject xrRigObject;      // Drag your XR Origin here (e.g. "XR Origin (XR)")

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == xrRigObject)
        {
            if (teleportTarget != null)
            {
                xrRigObject.transform.position = teleportTarget.position;
                Debug.Log("Teleported to: " + teleportTarget.position);
            }
            else
            {
                Debug.LogWarning("Teleport target not assigned.");
            }
        }
    }
}
