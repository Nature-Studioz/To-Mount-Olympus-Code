 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class Elevator: MonoBehaviour
 {
    bool moveUp = true;
    [SerializeField] float speed = 2;
    [SerializeField] float MinusY = -4f;
    [SerializeField] float Y = 4f;

     void Start()
     {
        
     }
     void Update()
     {
        
        if(transform.position.y > Y)
        {
            moveUp = false;
        }

        if (transform.position.y < MinusY)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }

        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
 }