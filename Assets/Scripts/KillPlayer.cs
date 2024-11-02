using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float volume = 1.0f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().isWalking = false;
            player.GetComponent<Player>().isJumping = false;
            player.GetComponent<Animator>().SetBool("isWalking", player.GetComponent<Player>().isWalking);
            player.GetComponent<Animator>().SetBool("isJumping", player.GetComponent<Player>().isJumping);
            player.GetComponent<Animator>().SetTrigger("Die");
            player.GetComponent<Player>().isDead = true;
            source.PlayOneShot(clip, volume);
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(player.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        player.GetComponent<Player>().isDead = false;
        player.transform.position = new Vector3(player.GetComponent<Player>().startX, player.GetComponent<Player>().startY, 0);
        SceneManager.LoadScene("Scene1");
        if (player.GetComponent<Player>().isInverted)
        {
            player.GetComponent<Player>().transform.Rotate(180, 0, 0);
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -Physics2D.gravity.y);
            player.GetComponent<Player>().isInverted = false;
        }
    }
}
