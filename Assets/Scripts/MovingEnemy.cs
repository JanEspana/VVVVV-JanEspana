using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    private float xSpeed;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = -0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(xSpeed, 0, 0);
    }
    //si choca con pointA o pointB, cambia de direccion
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Point" || collision.tag == "Player")
        {
            xSpeed = -xSpeed;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}
