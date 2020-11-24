using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaratorManager : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
    public GameObject ob5;
    public GameObject ob6;
    public GameObject ob7;
    public GameObject ob8;

    bool isplayed = true;
    bool isplayed2 = true;
    bool isplayed3 = true;
    bool isplayed4 = true;
    bool isplayed5 = true;
    bool isdone = false;
    AudioSource EndN;
    AudioSource HevN;
    AudioSource SpaceN;
    AudioSource skyN;
    AudioSource grndN;
    CircleCollider2D col1;
    public Rigidbody2D rb;
    Vector2 pos;
    
   
        
  
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        grndN = ob1.GetComponent<AudioSource>();
        skyN = ob2.GetComponent<AudioSource>();
        SpaceN = ob3.GetComponent<AudioSource>();
        HevN = ob4.GetComponent<AudioSource>();
        EndN = ob5.GetComponent<AudioSource>();
        col1 = GetComponent<CircleCollider2D>();
        
    
    }

    // Update is called once per frame
    void Update()
    {
      
        if (isdone)
        {
            transform.position = new Vector2(pos.x, pos.y);
            rb.velocity = new Vector2(0f, 0f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
     
        if (col1.IsTouchingLayers(LayerMask.GetMask("GroundN")) && isplayed == true)
        {
            grndN.Play();
            Debug.Log("Yes");
            isplayed = false;
        }

        if (col1.IsTouchingLayers(LayerMask.GetMask("SkyN")) && isplayed2 == true)
        {
            skyN.Play();
            Destroy(ob1);
            Debug.Log("Yes");
            isplayed2 = false;
        }

        if (col1.IsTouchingLayers(LayerMask.GetMask("SpaceN")) && isplayed3 == true)
        {
            SpaceN.Play();
            Destroy(ob2);
            Debug.Log("Yes");

            isplayed3 = false;
        }

        if (col1.IsTouchingLayers(LayerMask.GetMask("HeavenN")) && isplayed4 == true)
        {
            HevN.Play();
            Destroy(ob3);
            Debug.Log("Yes");
            isplayed4 = false;
        }

        if (col1.IsTouchingLayers(LayerMask.GetMask("EndingN")) && isplayed5 == true)
        {
            EndN.Play();
            Destroy(ob4);
            Debug.Log("Yes");
            isplayed5 = false;
            StartCoroutine(YoHoHo());
            Destroy(ob7);
            isdone = true;
            pos = new Vector2(transform.position.x, transform.position.y);
        }
    }

    IEnumerator YoHoHo()
    {
        yield return new WaitForSeconds(80);
        GameObject obs = Instantiate(ob6) as GameObject;
        obs.transform.parent = ob8.transform;
    }
       
    
}
