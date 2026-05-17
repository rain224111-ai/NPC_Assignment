using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sometime_Flip : MonoBehaviour
{
    public int maxCount = 100; //빈도. 시간 Inspertor에 지정 
    int count = 0; //시간 세는 변수 
    bool flipFlag = false;

    void Start() //맨 처음에만 실행하는 함수 
    {
        count=0;
    }

    void FixedUpdate() //일정시간마다 반복하는 함수 
    {
        count=count+1;
        if (count>=maxCount)
        {
            this.transform.Rotate(0,0,180); //2D의 경우, Z축의 값으로 회전을 시킨다.
            count=0; //초기화식

            //그림이 180도 회전하므로, 상하가 뒤집힘.
            //따라서, 반복할 때마다 위 아래를 반전시켜줘야함

            flipFlag = !flipFlag; //초기값이 false였으니 fipFlag는 true임 
            this.GetComponent<SpriteRenderer>().flipY = flipFlag;
        }

        
    }

}
