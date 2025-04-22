using UnityEngine;

public class FloatingObjects : MonoBehaviour
{
    private bool isHover = false; // Flag to check if the object is selected
    public float speed = 10.0f; // Speed of the floating object
    public Transform teleportTarget;    // Drag a destination GameObject here
    public GameObject xrRigObject;      // Drag your XR Origin here (e.g. "XR Origin (XR)")

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isHover) // If the object is not selected, make it rotate
        {
            transform.Rotate(0, speed * Time.deltaTime, 0); // Rotate the object around the Y-axis
        }
        else // If the object is selected, stop the rotation
        {
            transform.Rotate(0, 90, 0);
        }
    }

    public void OnHover() // Method to be called when the object is selected
    {
        isHover = true; // Set the flag to true to stop rotation
    }

    public void OffHover() // Method to be called when the object is deselected
    {
        isHover = false; // Set the flag to false to resume rotation
    }

    public void Teleport()
    {
        Debug.Log("Teleport method called!");

        if (xrRigObject != null && teleportTarget != null)
        {
            xrRigObject.transform.position = teleportTarget.position;
            Debug.Log("Teleported to: " + teleportTarget.position);
        }
        else
        {
            Debug.LogWarning("Teleport target or XR Rig not assigned.");
        }
    }
}
