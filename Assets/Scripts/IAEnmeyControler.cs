using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnmeyControler : MonoBehaviour
{
    private GameObject player;
    private float speed=2;

    void Start(){
        player=GameObject.Find("Player");
    }

    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position)<5){

            transform.position=Vector2.MoveTowards(transform.position,player.transform.position,speed* Time.deltaTime);
        }
    }
}
