using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 7f;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        playerController = FindObjectOfType<PlayerController>();

        if(playerController != null)
        {
            if (playerController.isLeft)
            {
                transform.Rotate(0, 180, 0);
                rb.velocity = transform.right * speed;
            }
            else
            {
                rb.velocity = transform.right * speed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));

        if (transform.position.x > max.x || transform.position.x < max.x * -1)
        {
            Destroy(gameObject);
        }
    }
}
