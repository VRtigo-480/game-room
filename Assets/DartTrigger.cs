using UnityEngine;
using UnityEngine.Events;

public class DartTrigger : MonoBehaviour
{

    public UnityEvent OnLeave;

    void OnTriggerEnter(Collider other) {
        Debug.Log("entered");
    }
    void OnTriggerExit(Collider other) {
        Debug.Log("exit");

        if (other.gameObject.CompareTag("Player")) {
            OnLeave?.Invoke();
        }
    }
}
