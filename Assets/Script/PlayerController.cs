using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float jumpForce = 20f;
    public Animator animasi;
    public bool isLeft;
    public bool isGrounded;
    public GameObject fireball;
    public GameObject firepos;
    public BoxCollider2D boxCollider2D;
    public AudioClip slashSound;
    public AudioClip footSound;
    private AudioSource audioSource;
    private AudioSource audioSource2;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        Attack();
    }

    void Attack()
    {
        //Slash
        if (Input.GetMouseButtonDown(0))
        {
            rb.gravityScale = 0f;
            boxCollider2D.isTrigger = true;
            animasi.SetBool("isSlashing", true);
            StartCoroutine(DelaySlash());
            audioSource2.clip = slashSound;
            audioSource2.Play();
        } 
        else if (Input.GetMouseButtonDown(1))
        {
            animasi.SetBool("isShooting", true);
            StartCoroutine(DelayShoot());
        }
           
    }

    IEnumerator DelaySlash()
    {
        yield return new WaitForSeconds(0.5f);
        animasi.SetBool("isSlashing", false);
        rb.gravityScale = 1f;
        boxCollider2D.isTrigger = false;
    }

     IEnumerator DelayShoot()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject spawnedFire = (GameObject) Instantiate(fireball);
        spawnedFire.transform.position = firepos.transform.position;
        animasi.SetBool("isShooting", false);
    }



    void Walk()
    {
        // Walk
        float moveInput = Input.GetAxis("Horizontal");
 

        float moveVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(moveInput * moveSpeed, moveVertical * moveSpeed);
        

        
        if(moveInput != 0){
            animasi.SetBool("isWalking", true);
            audioSource.clip = footSound;
            audioSource.loop = true;
            audioSource.Play();
        }else{
            animasi.SetBool("isWalking", false);
            audioSource.Stop();
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3 (1,1,1);
            isLeft = false;
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3 (-1,1,1);
            isLeft = true;
        }
    }


    void Jump()
    {
        //Jump
        if (isGrounded && Input.GetKeyDown (KeyCode.Space))
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            animasi.SetBool("isJumping", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            animasi.SetBool("isJumping", true);
        }
    }
//    else if (isGrounded && Input.GetMouseButtonDown(0))
//    {
//      animasi.SetBool ("isSlashing", true);
//    Debug.Log("jump slashing");
//     }
}
