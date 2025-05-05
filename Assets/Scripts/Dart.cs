using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Hands.Processing;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;



public class Dart : MonoBehaviour {

    public Transform WristJoint;

  
  [SerializeField] private bool _gestureActive = false;
  private Rigidbody _rb;
  public float Thrust = 15.0f;
  private float _velocityMagnitude = 0f;
  private Vector3 _lastPosition;
  public UnityEvent OnThrow;
  public Rigidbody RB { get { return _rb; } }

  public bool IsKinematic { set { _rb.isKinematic = value; }}
  public bool UseGravity { set { _rb.useGravity = value; }}


  void Start() {
    _rb = GetComponent<Rigidbody>();

    _lastPosition = WristJoint.position;
  }

   void Update()
    {
        Vector3 velocity = (WristJoint.position - _lastPosition) / Time.deltaTime;
        _velocityMagnitude = velocity.magnitude;
        _lastPosition = WristJoint.position;
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
    _rb.AddForce(-transform.up * Mathf.Max(_velocityMagnitude, Thrust), ForceMode.Impulse);
    OnThrow?.Invoke();
    // Wait();
  }

  IEnumerator Wait() {
    yield return new WaitForSeconds(2f); 
  }
}