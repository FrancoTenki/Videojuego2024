using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Animator playerAnimator;
    private Rigidbody2D rbplayer;
    [SerializeField] private float speed;
    private Vector2 moveInput;

    private GameObject gamemanager;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
        rbplayer=GetComponent<Rigidbody2D>();
        playerAnimator=GetComponent<Animator>();

        gamemanager=GameObject.Find("GameManager");

        player=GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
        float moveX=Input.GetAxisRaw("Horizontal");
        float moveY=Input.GetAxisRaw("Vertical");
        moveInput=new Vector2(moveX,moveY).normalized;

        playerAnimator.SetFloat("Horizontal",moveX);
        playerAnimator.SetFloat("Vertical",moveY);
        if(moveX!=0 || moveY!=0){
            playerAnimator.SetFloat("UltimoX",moveX);
            playerAnimator.SetFloat("UltimoY",moveY);
        }
        playerAnimator.SetFloat("speed",moveInput.sqrMagnitude);
    }
    private void FixedUpdate() {
        //mas para las fisicas
        rbplayer.MovePosition(rbplayer.position + moveInput* speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
         if (collision.gameObject.tag== "Enemy") {
            Debug.Log("Colision con Enemigo");
            gamemanager.GetComponent<Gamemanager>().RemoveLife(player);
            
            Invoke("HideMessage", 1);
        }
    }
    
}
