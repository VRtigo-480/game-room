using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;

public class Walking : MonoBehaviour
{
    public XROrigin xrOrigin;
    public float moveSpeed = 2.0f;
    public bool gestureactive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gestureactive) {
            Transform cameraTransform = xrOrigin.Camera.transform;

            Vector3 forward = cameraTransform.forward;
            forward.y = 0f; // Prevent upward/downward movement
            forward.Normalize();

            // Move the XR Origin in the forward direction
            xrOrigin.transform.position += forward * moveSpeed * Time.deltaTime;
        }
    }
    public void activateGesture() {
        gestureactive = true;
    }

    public void deactivateGesture() {
        gestureactive = false;
    }
}
