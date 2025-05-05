using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class DartRespawnHandler : MonoBehaviour
{
    [SerializeField] GameObject _dart;
    [SerializeField] GameObject[] _pool;
    int _index = 1;
    void Start()
    {
        FillPool();
    }

    void FillPool() {
        for (int i = 0; i < _pool.Length; i++) {
            _pool[i] = Instantiate(_dart, transform);
            if (i > 0) {
                _pool[i].SetActive(false);
            }

        }
    }

    public void ActivateNextDart() {
        if (_index < _pool.Length) _pool[_index++].SetActive(true);
    }

    public void RespawnDarts() {
        FillPool();
    }

    public void ResetDarts() {
        Debug.Log("Resetting");

        for (int i = 0; i < _pool.Length; i++) {
            _pool[i].transform.position = transform.position;
            Rigidbody rb = _pool[i].GetComponentInChildren<Rigidbody>();
            rb.gameObject.transform.position = transform.position;
            if (i > 0) {

                _pool[i].SetActive(false);
            }
            rb.useGravity = false;
            rb.isKinematic = true;
        }
    }

}
