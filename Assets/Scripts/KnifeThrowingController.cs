using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowingController : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;
    private Rigidbody2D rb;
    private BoxCollider2D knifeCollider;
    private bool isKnifeActive = true;
    
  
    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();  
        knifeCollider = GetComponent<BoxCollider2D>(); 
        
    }

    private void Update() 
    {
        ThrowKnife();
    }

    private void ThrowKnife() 
    {
        if (Input.GetMouseButtonDown(0) && isKnifeActive) 
        {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if(!isKnifeActive) 
        {
            return;
        }
        isKnifeActive = false;
        if (collision.collider.tag == "Target") 
        {
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);
            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.2562374f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 1.500711f);
        }
    }

}