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
  [SerializeField] DartRespawnHandler _respawnHandler;
  [SerializeField] Transform _wristJoint;
  public Rigidbody RB { get { return _rb; } }

  public bool IsKinematic { set { _rb.isKinematic = value; }}
  public bool UseGravity { set { _rb.useGravity = value; }}


  void Awake() {
    // _respawnHandler = GameObject.Find("DartRespawn").GetComponent<DartRespawnHandler>();;
    // _wristJoint = GameObject.Find("R_wrist").transform;
    _rb = GetComponent<Rigidbody>();
  }
  void Start() {
    LaunchDart();


    _lastPosition = _wristJoint.position;
  }

   void Update()
    {
        Vector3 velocity = (_wristJoint.position - _lastPosition) / Time.deltaTime;
        _velocityMagnitude = velocity.magnitude;
        _lastPosition = _wristJoint.position;
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