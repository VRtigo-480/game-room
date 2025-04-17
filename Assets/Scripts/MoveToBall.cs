using System;
using UnityEngine;



public class MoveObject : MonoBehaviour
{
    public GameObject targetObject;
    public float speed = 10f;
    void Update()
    {
        
        Vector3 targetPosition = targetObject.transform.position;
        Vector3 currentPosition = transform.position;
        targetPosition.x = currentPosition.x;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
    }            
}
