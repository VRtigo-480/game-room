using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Dart : MonoBehaviour {
  
  [SerializeField] private bool gestureActive = false;
  public Transform handAttach;
  public Transform dartAttach;

  public void GrabDart() {
    transform.position = handAttach.position - (dartAttach.position - transform.position);
    transform.rotation = handAttach.rotation * Quaternion.Inverse(dartAttach.localRotation);
    transform.SetParent(handAttach);
  }

  public void LetGo() {
    Debug.Log("Let go");
  }
  void Start() {
    if (dartAttach == null) {
      dartAttach = transform.Find("AttachPoint");
    }
  }

  public void ActivateGesture() {
    gestureActive = true;
  }

  public void DeactivateGesture() {
    gestureActive = false;
  }
}