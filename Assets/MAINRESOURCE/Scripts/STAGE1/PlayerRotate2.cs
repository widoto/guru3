using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate2 : MonoBehaviour
{
    public float rotSpeed =300.0f;
    
    //회전 누적 변수
    float mx = 0;

    //이거 새거 새거//
    private Transform tr;

    //이거 새거새거
    public float turnSpeed = 80.0f;

    //이거 새거 새거
    IEnumerator Start()
    {
        //이거 새거 새거//
        tr = GetComponent<Transform>();

        //이거 세줄 새거 새거//
        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;

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
        

        //2. 입력받은값을이용해서 회전방향을 결정한다.
        //Vector3 dir = new Vector3(0,mouse_X,0);
        //dir.Normalize();
        mx += mouse_X * rotSpeed *Time.deltaTime;
        //3. 결정된횐전방향을물체의 회전속성에 대입한다.  
        // R = R0+ VT
        //transform.eulerAngles += dir * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0,mx,0);
    }
}
