using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class AgentMove : Agent
{
    public float speed = 0.01f;
    public float jumpspeed = 1;
    public float jumpspeedtwo = -5f;
    public Rigidbody2D rb;
    private Vector2 start;
    public Vector2 movement;
    public float ag = 7;
    public event Action OnReset;
    int score = 0;

   

    // Use this for initialization
    void Start()
    {
        start = new Vector2(transform.position.x, transform.position.y);
    }


   

    public override void Initialize()
    {
   
        rb = this.GetComponent<Rigidbody2D>();
        movement = new Vector2(transform.position.x, transform.position.y);

        
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if(Mathf.FloorToInt(vectorAction[0]) == 1)
        {
            Jump();
        }


        if (Mathf.FloorToInt(vectorAction[0]) == 2)
        {
            movement = new Vector2(-7, 0f);
        }


        if (Mathf.FloorToInt(vectorAction[0]) == 3)
        {
           
            movement = new Vector2(7, 0f);
        }


    }

    public override void OnEpisodeBegin()
    {
            }


    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(rb.velocity);
        sensor.AddObservation(transform.rotation.z);
        sensor.AddObservation(transform.position.x);
    }

 
    // Update is called once per frame
    void Update()
    {


       

    }
    private void Reset()
    {
        score = 0;
        transform.position = start;
        rb.velocity = Vector2.zero;
        OnReset?.Invoke();
    }
    void FixedUpdate()
    {


        moveCharacter(movement);
        if (rb.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            AddReward(1f);
        }

  

        if (rb.IsTouchingLayers(LayerMask.GetMask("Default")))
        {
            AddReward(-0.1f);
        }
    }



    void Jump()
    {

        if ( rb.IsTouchingLayers(LayerMask.GetMask("Ground")) && !rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            
           
            Vector2 jump = new Vector2(0f, jumpspeed);
            rb.velocity += jump;
        }

        if ( rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            Vector2 jump = new Vector2(0f, jumpspeed);
            rb.velocity += jump;
            
        }
    }
    void moveCharacter(Vector2 direction)
    {

        if (rb.IsTouchingLayers(LayerMask.GetMask("Ground")) || rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            rb.AddForce(direction * speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            this.transform.parent = collision.transform;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!rb.IsTouchingLayers(LayerMask.GetMask("Move")))
        {
            this.transform.parent = null;

        }
    }

}