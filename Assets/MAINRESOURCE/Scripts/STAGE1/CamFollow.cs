using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    // 지정한 위치로 카메라의 위치를 변경하고 싶다.

    // 카멜가 쫒아다닐 위치 변수
    public Transform followPosition;
    void Start()
    {
        
    }
    void Update()
    {
      
      //나의 위치를 followposition고 맞추기
        transform.position = followPosition.position;
    }
}
