using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move_Fotate : MonoBehaviour
{
    //1.Forever_Move
    public float speed = 1; 
    public float angle = 30; 
    
    void FixedUpdate() //일정시간마다 이동하는 함수 
    {
        this.transform.Translate(speed/50,0,0); //1초에 한 번 이동?
        this.transform.Rotate(0,0,angle/50);
    }



}
