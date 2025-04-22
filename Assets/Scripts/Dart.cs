using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;



public class Dart : MonoBehaviour {
  
  [SerializeField] private bool gestureActive = false;
  private Rigidbody rb;
  public float thrust = 10.0f;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("DartZone")) {
      rb.isKinematic = true;
      
      rb.useGravity = false;
      transform.parent = collision.transform;
      collision.transform.GetComponent<DartZone>().IncrementScore();
    }
  }

  public void LaunchDart() {
    // rb.useGravity = true;
    rb.isKinematic = false;
    rb.AddForce(-transform.up * thrust);
  }
}