using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtacckController : MonoBehaviour
{
    public GameObject fireballprefab ;
    private Gamemanager gameManagerController;

    SpriteRenderer sr;
    // Dirección del personaje: izquierda, derecha, arriba, abajo
    private Vector2 facingDirection = Vector2.right;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gameManagerController = GameObject.Find("GameManager").GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.W)) facingDirection = Vector2.up;
            else if (Input.GetKey(KeyCode.S)) facingDirection = Vector2.down;
            else if (Input.GetKey(KeyCode.A)) facingDirection = Vector2.left;
            else if (Input.GetKey(KeyCode.D)) facingDirection = Vector2.right;

        if (Input.GetKeyDown(KeyCode.X) && gameManagerController.getMana() > 0)
        {
            
            GameObject fireball = Instantiate(fireballprefab, transform.position, Quaternion.identity);
            // fireball.GetComponent<FireBallController>().SetDirection(sr.flipX ? "left" : "right");
            fireball.GetComponent<FireBallController>().SetDirection(facingDirection);
            gameManagerController.reduceMana();
            Debug.Log("Se instancio fireball");
        }

    }

}
