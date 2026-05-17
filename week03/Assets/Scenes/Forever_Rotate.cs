using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Forever_Rotate : MonoBehaviour
{
    public float angle = 90;

    void FixedUpdate() //일정 시간동안 반복 
    {
        this.transform.Rotate(0,0,angle/50);
    }

}
