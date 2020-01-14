using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 throwForce;

    private Rigidbody2D rb;

    private bool isActive = true;

    private int availableKnives;

    private void Awake()  {
        rb = GetComponent<Rigidbody2D>();
        availableKnives = SetAvailableKnives();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0) && isActive && availableKnives > 0 ) {
            rb.AddForce(throwForce, ForceMode2D.Impulse);
            rb.gravityScale = 1;
        }
    }

    private int SetAvailableKnives () {
        //Проверить нормальную работу рандома(диапазон)
        return Random.Range( 4, 8 );
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if(!isActive)
            return;
       
        isActive = false;
        availableKnives--;


        if (collision.collider.tag == "Target") {

            rb.velocity = new Vector2(0, 0);
            rb.bodyType = RigidbodyType2D.Kinematic;
            this.transform.SetParent(collision.collider.transform);

        }


    }

}
