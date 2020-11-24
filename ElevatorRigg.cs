using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ElevatorRigg : MonoBehaviour
{
    bool moveRight = true;
    bool isOn = false;
    BoxCollider2D bx;
    [SerializeField] float speed = 2;
    [SerializeField] float MinusX = -4f;
    [SerializeField] float X = 4f;

    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (bx.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            isOn = true;
        }
        if (isOn)
        {
            if (transform.position.x > X)
            {
                moveRight = false;
            }

            if (transform.position.x < MinusX)
            {
                moveRight = true;
            }

            if (moveRight)
            {
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            }

            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            }
        }
    }
}