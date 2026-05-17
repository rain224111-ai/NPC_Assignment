using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sometime_Turn : MonoBehaviour
{
    public float angle = 90; //각도 Inspector에 지정
    public int maxCount = 50; //빈도 Inspector에 지정

    int count = 0; // 지연시간 측정 변수

    void Start() 
    {
        count = 0; //처음 실행할 때 count를 리셋
    }

    void FixedUpdate()  //일정 시간마다 계속 실행. FixedUpdate 미사용시 1회만 
    {
        count = count+1; //count에 1을 더해서 지연시간 측정 
        if (count>=maxCount)  //만약 count(지연시간)이 50 이상일 경우 실행하라
        {
            this.transform.Rotate(0,0,angle); //90도 만큼 회전한다. 2D의 경우, Z축을 통해 회전시킴 
            count = 0; //카운터를 리셋 
        }
    }
    
}
