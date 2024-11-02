using System;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private float speed = -0.015f;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Spawner.spawner.Push(gameObject);
        }
        else
        {
            Spawner.spawner.Stop();
            speed = 0;
        }
    }
}
