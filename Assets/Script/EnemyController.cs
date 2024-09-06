using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public Animator animasi;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //transform.Rotate(0, 180, 0);
        //rb.velocity = transform.right * speed;

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        //if (transform.position.x < max.x * -1)
        //{
        //    transform.position = new Vector2(max.x, transform.position.y);
        //}
    }

    private void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                animasi.SetBool("isHurting", true);
                rb.velocity = Vector3.zero;
                StartCoroutine(DelaytoWalk());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fire")
        {
            if (Input.GetMouseButtonDown(0))
            {
                animasi.SetBool("isHurting", true);
                rb.velocity = Vector3.zero;
                StartCoroutine(DelaytoWalk());
            }
        }
    }

    IEnumerator DelaytoWalk()
    {
        yield return new WaitForSeconds(0.2f);
        animasi.SetBool("isHurting", false);

    }
}
