using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScene : MonoBehaviour
{
    //create a canvas object
    public GameObject winCanvas; 
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        winCanvas = GameObject.Find("WinCanvas");
        player = GameObject.Find("Player");
        winCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            winCanvas.SetActive(true);
            player.SetActive(false);
        }
    }
}
