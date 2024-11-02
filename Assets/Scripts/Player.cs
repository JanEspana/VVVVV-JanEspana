using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public static Player instance;
    Collider2D collider;
    Animator anim;
    public bool isJumping = false;
    public bool isWalking = false;
    public bool isDead = false;
    public bool isInverted = false;
    public float startX;
    public float startY;
    public AudioSource source;
    public AudioClip sound;
    public float volume = 1.0f;
    //Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        startX = transform.position.x;
        startY = transform.position.y;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Walk();
            Jump();
        }
    }
    public void Walk()
    {
        //MOVEMENT SCRIPT
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            isWalking = true;

        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(0.01f, 0, 0);
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        anim.SetBool("isWalking", isWalking);
    }
    public void Jump()
    {
        //JUMPING SCRIPT
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 0.65f);
        Debug.DrawLine(transform.position, transform.position - transform.up * 0.65f, Color.red);
        if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
        anim.SetBool("isJumping", isJumping);
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Physics2D.gravity = new Vector2(Physics2D.gravity.x, -Physics2D.gravity.y);
            transform.Rotate(180, 0, 0);
            isInverted = !isInverted;
            source.PlayOneShot(sound, volume);
        }
    }
}
