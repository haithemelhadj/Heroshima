using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    [SerializeField][Range(0f,10f)] private float Speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime* Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

        }
    }
}
