using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float speed = 0.01f;
    public float jumpspeed = 1;
    public float jumpspeedtwo = -5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public AudioClip clip;
    public AudioClip clip2;
    bool jumpy = true;
    public GameObject BrickHt;
    public GameObject Jmpy;


    // Use this for initialization

    private void Awake()
    {
        
           
  
        
    }
    void Start()
    {
       
       
        
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
       
    


        if (rb.IsTouchingLayers(LayerMask.GetMask("EndingN"))){
            rb = null;
            Destroy(rb);
        }
        
        if (rb.IsTouchingLayers(LayerMask.GetMask("Move")) || rb.IsTouchingLayers(LayerMask.GetMask("Ground")) || rb.IsTouchingLayers(LayerMask.GetMask("Default")))
            {
            if (jumpy == true)
            {
                GameObject ooo = Instantiate(BrickHt) as GameObject;
                Destroy(ooo, 2);
                jumpy = false;
            }

           
        }
     
        movement = new Vector2(Input.GetAxis("Horizontal"),0f);

      

        if (Input.GetButtonDown("Jump"))
        {
            if(rb.IsTouchingLayers(LayerMask.GetMask("Move")) || rb.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                StartCoroutine(Jumpy());
                transform.localScale = new Vector2(0.2820486f, 0.2919536f);
                Vector2 jump = new Vector2(0f, jumpspeed);
                GameObject oooo = Instantiate(Jmpy) as GameObject;
                Destroy(oooo, 2);
                rb.velocity += jump;
            }
        }
 
        
        if(rb.velocity.x > 30)
        {
            rb.velocity = new Vector2(30f, rb.velocity.y);
        }

        if (rb.velocity.x < -30)
        {
            rb.velocity = new Vector2(-30f, rb.velocity.y);
        }

    }
    void FixedUpdate()
    {
     

        moveCharacter(movement);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(Jumpy());
    }

    IEnumerator Jumpy()
    {
        yield return new WaitForSeconds(0.3f);
        jumpy = true;
    }
    void moveCharacter(Vector2 direction)
    {

        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")) || rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            rb.AddForce(direction * speed);
        }
        
    }

    

    

}