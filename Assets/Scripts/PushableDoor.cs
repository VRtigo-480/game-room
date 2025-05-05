using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HingeJoint))]
public class PushableDoor : MonoBehaviour
{
    [Header("Door Hinge Settings")]
    public float swingLimit = 90f;
    public float swingSpring = 5f;
    public float swingDamper = 1f;

    private HingeJoint hinge;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.mass = 5f;

        hinge = GetComponent<HingeJoint>();
        hinge.useLimits = true;
        hinge.useSpring = true;

        // Configure hinge to swing around Y-axis like a normal door
        hinge.axis = Vector3.up;

        // Setup swing limits
        JointLimits limits = hinge.limits;
        limits.min = 0;
        limits.max = swingLimit;
        hinge.limits = limits;

        // Setup spring
        JointSpring spring = hinge.spring;
        spring.spring = swingSpring;
        spring.damper = swingDamper;
        spring.targetPosition = 0;
        hinge.spring = spring;
    }
}