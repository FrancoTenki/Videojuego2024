using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private float player_x;
    private float player_y;

    private float camx;
    private float camy;

    public float derechaMax;
    public float IzquierdaMax;
    public float AlturaMax;
    public float AlturaMin;
    public float speed;
    public bool encendida=true;


    // Start is called before the first frame update
        void Awake() {
        camx=player_x+derechaMax;
        camy=player_y+AlturaMin;
        transform.position=Vector3.Lerp(transform.position, new Vector3(camx,camy,-1),1);
    }  
    void MovimCam(){
        if(encendida){
            if(player){
                player_x=player.transform.position.x;
                player_y=player.transform.position.y;

                if(player_x>derechaMax && player_x<IzquierdaMax){
                    camx=player_x;
                }

                if(player_y < AlturaMax && player_y >AlturaMin){
                    camy=player_y;
                }
            }
            transform.position=Vector3.Lerp(transform.position,new Vector3(camx,camy,-1),speed*Time.deltaTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        MovimCam();
    }
}
