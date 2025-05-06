using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FloatingObjects : XRGrabInteractable
{
    public float speed = 10.0f; // Speed of the floating object
    public Transform teleportTarget;    // Drag a destination GameObject here
    public GameObject xrRigObject;      // Drag your XR Origin here (e.g. "XR Origin (XR)")
    private Vector3 originalScale;
    public float hoverScaleMultiplier = 1.1f; // How much bigger when hovered
    private Renderer objectRenderer;
    public Color hoverColor = new Color(0f, 1f, 1f, 0.25f); // Semi-transparent cyan
    private Material[] objectMaterials;
    private Color[] originalColors;

    protected override void Awake()
    {
        base.Awake();
        originalScale = transform.localScale;

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            objectMaterials = objectRenderer.materials;

            // Save the original color for each material
            originalColors = new Color[objectMaterials.Length];
            for (int i = 0; i < objectMaterials.Length; i++)
            {
                if (objectMaterials[i].HasProperty("_Color"))
                {
                    originalColors[i] = objectMaterials[i].color;
                }
            }
        }
    }

    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0); // Rotate the object around the Y-axis
    }

    public void Teleport()
    {
        Debug.Log("Teleport method called!");

        // Force the interactor (controller) to drop this object BEFORE teleporting
        if (isSelected)
        {
            interactionManager.SelectExit(firstInteractorSelecting, this);
        }

        if (xrRigObject != null && teleportTarget != null)
        {
            // Get the main camera (user head in XR)
            Transform cameraTransform = xrRigObject.GetComponentInChildren<Camera>().transform;
            xrRigObject.transform.position = teleportTarget.position;
            xrRigObject.transform.rotation = teleportTarget.rotation;
            cameraTransform.position = teleportTarget.position;
            cameraTransform.rotation = teleportTarget.rotation;
            Debug.Log("Teleported to: " + teleportTarget.position);
        }
        else
        {
            Debug.LogWarning("Teleport target or XR Rig not assigned.");
        }
    }

    // ====== XR Grab Override to Lock Position ======
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Lock attach transform so it doesn’t move
        if (attachTransform != null)
        {
            attachTransform.position = transform.position;
            attachTransform.rotation = transform.rotation;
        }

        // Call teleport when grabbed!
        Teleport();

        base.OnSelectEntered(args);
    }

    // ====== Pulse / Highlight on Hover ======
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        // Scale up
        transform.localScale = originalScale * hoverScaleMultiplier;

        // Change all materials to hover color
        if (objectMaterials != null)
        {
            foreach (var mat in objectMaterials)
            {
                if (mat.HasProperty("_Color"))
                {
                    mat.color = hoverColor;
                }
            }
        }
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        // Reset scale
        transform.localScale = originalScale;

        // Reset each material to its saved original color
        if (objectMaterials != null && originalColors != null)
        {
            for (int i = 0; i < objectMaterials.Length; i++)
            {
                if (objectMaterials[i].HasProperty("_Color"))
                {
                    objectMaterials[i].color = originalColors[i];
                }
            }
        }
    }
}