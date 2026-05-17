using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Forever_MoveH : MonoBehaviour
{
    public float speed = 1; //속도: Inspector에 지정 


    void FixedUpdate() // 일정 시간마다 계속 시행. 매끄러운 이동 가능 
    {
        this.transform.Translate(speed/50,0,0);
    }
}
