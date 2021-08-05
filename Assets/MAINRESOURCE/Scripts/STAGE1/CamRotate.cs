using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    //회전 속력 변수
    public float rotSpeed =300.0f;

    //회전 각도 제한
    public float rotLimit= 60.0f;
    //회전누적변수 돈다이 머리가 돈다이
    float mx = 0;
    float my =0;
    void Start()
    {
        
    }

    
    void Update()
    {


        
        /////
        //게임 상태가 게임중 상태가 아니면 업데이트 함수를 종료
        //if(GameManager.gm.gState != GameManager.GameState.Run)
        //{
          //return;
        //}
        
        //사용자의 마우스입력을받아서 물체를상호좌우로 회전시키고 싶다!
        //1. 사용자의마우스 입력을 받는다.
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");

        mx += mouse_X * rotSpeed * Time.deltaTime;
        my += mouse_Y * rotSpeed * Time.deltaTime;
        my = Mathf.Clamp(my,-rotLimit, rotLimit);
        //2. 입력받은값을이용해서 회전방향을 결정한다.
        //Vector3 dir = new Vector3(-mouse_Y,mouse_X,0);
        //dir.Normalize();
        //3. 결정된횐전방향을물체의 회전속성에 대입한다.  
        // R = R0+ VT
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(-my,mx,0);
        //4. 회전 값중에서 x축 값을마이너스 90도에서 플러스90도 사이로 제한하고 싶다.
        //Vector3 rot = transform.eulerAngles;
        //rot.x = Mathf.Clamp(rot.x, -90.0f,90.0f);
        //transform.eulerAngles = rot;
    }
}
