using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OnCollisionBounce : MonoBehaviour
{
    public GameObject targetArea;
    public float launchForce = 10f;
    public GameObject resetPosition;
    public TextMeshPro ptext;
    public TextMeshPro otext;

    private Rigidbody rb;
    private bool isPlayer = true;
    private bool isAI = false;
    private bool pTable = false;
    private bool oTable = false;
    private int pScore;
    private int oScore;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AI"))
        {
            ResetBools();
            isAI = true;
            Vector3 randomPoint = GetRandomPointInArea();
            Vector3 direction = (randomPoint - transform.position).normalized;
            rb.linearVelocity = direction * launchForce;
        }
        if (collision.gameObject.CompareTag("floor"))
        {
            if(isAI) 
            {
                if (pTable)
                {
                    oScore += 1;
                    otext.text = oScore.ToString();
                }
                else
                {
                    pScore += 1;
                    ptext.text = pScore.ToString();

                }
            }
            if(isPlayer)
            {
                if (oTable)
                {
                    pScore += 1;
                    ptext.text = pScore.ToString();
                }
                else
                {
                    oScore += 1;
                    otext.text = oScore.ToString();
                }
            }
            rb.position = resetPosition.transform.position;
            rb.linearVelocity = Vector3.zero;
            ResetBools();
        }
        if (collision.gameObject.CompareTag("ptable"))
        {
            if (isPlayer) 
            {
                oScore += 1;
                otext.text = oScore.ToString();
                ResetBools();
                rb.position = resetPosition.transform.position;
                rb.linearVelocity = Vector3.zero;
            } 
            else 
            {
                if (pTable)
                {
                    oScore += 1;
                    otext.text = oScore.ToString();
                    ResetBools();
                    rb.position = resetPosition.transform.position;
                    rb.linearVelocity = Vector3.zero;
                }
                else
                {
                    pTable = true;
                }
            }
        }
        if (collision.gameObject.CompareTag("otable"))
        {
            if (isAI) 
            {
                pScore += 1;
                ptext.text = pScore.ToString();
                ResetBools();
                rb.position = resetPosition.transform.position;
                rb.linearVelocity = Vector3.zero;
            } 
            else 
            {
                if (oTable)
                {
                    pScore += 1;
                    ptext.text = pScore.ToString();
                    ResetBools();
                    rb.position = resetPosition.transform.position;
                    rb.linearVelocity = Vector3.zero;
                }
                else
                {
                    oTable = true;
                }
            }
        }
        if (collision.gameObject.CompareTag("player"))
        {
            ResetBools();
            isPlayer = true;
        }
    }

    void ResetBools()
    {
        isAI = false;
        isPlayer = false;
        pTable = false;
        oTable = false;
    }

    Vector3 GetRandomPointInArea()
    {
        Collider areaCollider = targetArea.GetComponent<Collider>();

        Vector3 min = areaCollider.bounds.min;
        Vector3 max = areaCollider.bounds.max;

        return new Vector3(
            Random.Range(min.x, max.x),
            Random.Range(min.y, max.y),
            Random.Range(min.z, max.z)
        );
    }
}