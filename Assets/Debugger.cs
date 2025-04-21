using UnityEngine;

public class Debugger : MonoBehaviour
{

    public object obj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Log(string str) {
        Debug.Log(str);
    }
}
