using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer_Manager : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField][Range(0f, 10f)] private float MoveSpeed;
    [SerializeField][Range (0f,10f)] private float Vspeed;
    private float DirectX;
    private float DirectY;
    public Camera Camera;
    

    
    void Update()
    {
        Move();
        
    }
    //move right and left
    private void Move()
    {
        //get input
        DirectX = Input.GetAxis("Horizontal");
        DirectY = Input.GetAxis("Vertical");

        //move
        rb.velocity = new Vector2(DirectX * MoveSpeed, DirectY * MoveSpeed);

        //movement with tilting the phone
        DirectX = Input.acceleration.x * MoveSpeed * Time.deltaTime;
        DirectY = Input.acceleration.y * MoveSpeed * Time.deltaTime;

        transform.Translate(DirectX, DirectY, 0f);



        /*
        //move Player with finger
        if (Input.touchCount > 0 || Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = (Camera.ScreenToWorldPoint(touch.position));


            if (touchPosition.x > transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(touchPosition.x, transform.position.y), MoveSpeed * Time.deltaTime);
            }
            else if (touchPosition.x < transform.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(touchPosition.x, transform.position.y), MoveSpeed * Time.deltaTime);
            }
        }
        */
    }
}
