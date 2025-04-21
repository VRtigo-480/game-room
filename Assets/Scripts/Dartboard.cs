using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dartboard : MonoBehaviour
{
    [System.Serializable]
    public class DartZone
    {
        public Collider collider;
        public float gravityValue;
    }

    public List<DartZone> dartZones;
    public float influenceRadius = 0.2f;

    public TextMeshProUGUI pointText;

    public void AttractDart(Rigidbody dartRb)
    {
        Vector3 dartPosition = dartRb.position;
        DartZone bestZone = null;
        float highestInfluence = 0f;

        foreach (var zone in dartZones)
        {
            Vector3 closestPoint = zone.collider.ClosestPoint(dartPosition);
            float distance = Vector3.Distance(closestPoint, dartPosition);

            if (distance < influenceRadius)
            {
                // Gravity effect falls off with distance
                float influence = zone.gravityValue / (distance + 0.01f); // +0.01 to avoid division by zero

                if (influence > highestInfluence)
                {
                    highestInfluence = influence;
                    bestZone = zone;
                }
            }
        }

        if (bestZone != null)
        {
            Vector3 targetPoint = bestZone.collider.ClosestPoint(dartPosition);
            Vector3 direction = (targetPoint - dartPosition).normalized;

            float pullStrength = highestInfluence * Time.fixedDeltaTime;
            dartRb.linearVelocity += direction * pullStrength;
        }
    }
}
