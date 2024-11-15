using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    float defaultVelocityX = 10;
    // float currentVelocityX = 0;
    Vector2 direction = Vector2.zero; 
    Rigidbody2D rb;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");

        Destroy(gameObject, 5);

    }

    // Update is called once per frame
    void Update()
    {
        // rb.velocity = new Vector2(currentVelocityX, rb.velocity.y);
        rb.velocity = direction * defaultVelocityX;
    }

    // public void SetDirection(string direction) {
    //     if (direction == "left")
    //     {
    //         currentVelocityX = -defaultVelocityX;
    //         transform.rotation = Quaternion.Euler(0, 0, 90);
    //     } else {
    //         currentVelocityX = defaultVelocityX;
    //         transform.rotation = Quaternion.Euler(0, 0, -90);
    //     }
    // }
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;

        // Ajusta la rotación de la fireball según la dirección
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            // gameManager.GetComponent<Gamemanager>().AddScore(10);
        }
    }
}
