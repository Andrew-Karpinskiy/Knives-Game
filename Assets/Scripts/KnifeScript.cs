using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
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
        if(collision.collider.tag == "Target") 
        {
            SoundController.Instance.PlayHitSound();
            GameController.Instance.OnSuccessfulHit();
            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);
            knifeCollider.offset = new Vector2(knifeCollider.offset.x, -0.5476606f);
            knifeCollider.size = new Vector2(knifeCollider.size.x, 0.9180121f);
        }
        if(collision.collider.tag == "Knife") 
        {
             SoundController.Instance.PlayVibration();
            gameObject.tag = "Trash";
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0,-1), ForceMode2D.Impulse);
            knifeCollider.isTrigger = true;
            GameController.Instance.StopTheGame();
        }
    }    
}