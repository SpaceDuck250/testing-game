using System;
using UnityEngine;

public class TopDownMove : MonoBehaviour
{
    public CharacterController2D controller;
    public ParticleSystem Electricity;
    public GameObject sp;
    public Animator animator;
    public Rigidbody2D rb;

    public float xmove;
    public float ymove;
    public float speed = 50;

    public enum direction
    {
        left,
        right,
        down,
        up,
    }

    public direction playerdirection;

    

    // Update is called once per frame
    void Update()
    {

        FindDirection();

        xmove = Input.GetAxisRaw("Horizontal");
        ymove = Input.GetAxisRaw("Vertical");

        
        //animator.SetFloat("Vertical", Mathf.Round(rb.linearVelocityY));
        //animator.SetFloat("Horizontal", Mathf.Round(rb.linearVelocityX));
        //animator.SetFloat("speed", Mathf.Abs(rb.linearVelocity.magnitude));

    }

    private void FixedUpdate()
    {
        controller.Move(xmove * speed * Time.fixedDeltaTime);
        controller.VerticalMove(ymove * speed * Time.fixedDeltaTime);
    }

    public void FindDirection()
    {
        if (xmove == 1)
        {
            playerdirection = direction.right;
        }
        else if (xmove == -1)
        {
            playerdirection = direction.left;
        }

        if (ymove == 1)
        {
            playerdirection = direction.up;
        }
        else if (ymove == -1)
        {
            playerdirection = direction.down;
        }

        Debug.Log(playerdirection);
    }
}
