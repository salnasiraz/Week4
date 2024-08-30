using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveLR : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pindah")
        {
            SceneManager.LoadScene("game");
        }

        if (collision.tag == "Balik")
        {
            SceneManager.LoadScene("Scene2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,0);
        if (Input.GetKey(KeyCode.D)){
            rb.velocity = new Vector2(speed,0);
        }
        if(Input.GetKey(KeyCode.A)){
            rb.velocity = new Vector2(-speed,0);
        }
    }
}
