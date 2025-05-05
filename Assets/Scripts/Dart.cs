using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;



public class Dart : MonoBehaviour {
  
  [SerializeField] private bool _gestureActive = false;
  private Rigidbody _rb;
  public float Thrust = 10.0f;
  public UnityEvent OnThrow;

  void Start() {
    _rb = GetComponent<Rigidbody>();
    LaunchDart();
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("DartZone")) {
      _rb.isKinematic = true;
      
      _rb.useGravity = false;
      transform.parent = collision.transform;
      collision.transform.GetComponent<DartZone>().IncrementScore();
    }
  }

  public void LaunchDart() {
    _rb.useGravity = true;
    _rb.isKinematic = false;
    _rb.AddForce(-transform.up * Thrust, ForceMode.Impulse);
    OnThrow?.Invoke();
  }
}