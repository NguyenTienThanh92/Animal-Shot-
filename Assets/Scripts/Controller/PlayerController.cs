using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    
    
    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (rb.velocity.magnitude >= 0.5f )
        // {
        //     isMoving = true;
        // }
        //
        // if (rb.velocity.magnitude == 0)
        // {
        //     isMoving = false;
        // }
    }

    public void Push (Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    //public void ActivateRb()
    //{
    //    rb.isKinematic = false;
  //  }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        //rb.isKinematic = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EndGame"))
        {
            DOVirtual.DelayedCall(2f, delegate
            {
                if (Vector3.Distance(transform.position, other.transform.position) <= 0.2f)
                {
                    GameManager.Instance.EndGame();
                }
            });
        }
    }
}
