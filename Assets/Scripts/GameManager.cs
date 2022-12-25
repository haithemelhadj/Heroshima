using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int Health=3;
    [SerializeField] private float Fuel=100f;
    [SerializeField] private int NuclearPower=0;
    [SerializeField] private int Score;


    private float inittimer=1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = inittimer;
            Fuel -= 1;
        }

    }


    
    
}
