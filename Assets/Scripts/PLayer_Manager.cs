using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PLayer_Manager : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField][Range(0f, 10f)] private float MoveSpeed;
    [SerializeField][Range (0f,10f)] private float Vspeed;
    private float DirectX;
    private float DirectY;
    public Camera Camera;

    public GameObject Button;
    public GameObject WinText;
    public GameObject LoseText;

    public Text FuelText;
    public Text NuclearPowerText;
    public Text HealthText;


    private float inittimer = 1f;
    private float timer;
    
    [SerializeField] private int Health = 3;
    [SerializeField] private float Fuel = 100f;
    [SerializeField] private int NuclearPower = 0;
    [SerializeField] private int Score;

    private bool GameOver = false;
    private bool Win = false;
    
    

    private void Awake()
    {
        Time.timeScale = 1;
        Button.SetActive(false);
        WinText.SetActive(false);
        LoseText.SetActive(false);
    }

    void Update()
    {
        Move();
        gameOver();
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = inittimer;
            Fuel -= 1;
        }
        
        if(GameOver)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            Button.SetActive(true);
            LoseText.SetActive(true);
        }
        if (Win)
        {
            Debug.Log("You Win");
            Time.timeScale = 0f;
            Button.SetActive(true);
            WinText.SetActive(true);
        }

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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fuel"))
        {
            //do something
            Fuel += 5f;
        }
        if (collision.CompareTag("NuclearPower"))
        {
            //do something
            NuclearPower += 10;
        }
        if (collision.CompareTag("obstacle"))
        {
            //do something
            Health -= 1;
        }
    }

    void gameOver()
    {
        if (Health <= 0)
        {
            //do something
            GameOver = true;
        }
        if (Fuel <= 0)
        {
            //do something
            GameOver = true;
        }
        if (NuclearPower >= 100)
        {
            //do something
            Win = true;
        }


    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FixedUpdate()
    {
        FuelText.text = Fuel.ToString();
        NuclearPowerText.text =  NuclearPower.ToString();
        HealthText.text = Health.ToString();
    }

}
