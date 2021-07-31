using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : MonoBehaviour
{

    //오디오 소스 컴포넌트 변수
    AudioSource aSource;

    void Start()
    {
      //오디오 소스 컴포넌트 가져오기
      aSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {

      
        //포탄 소리를 플레이 한다.
      aSource.Play();
      /////////////////////
      //자신의 위치에서 일정한 반경만큼을 검색해서 그 범위 안에 에너미들을 찾는다.///////////////////
      //Collider[] player = Physics.OverlapSphere(transform.position, explosionRadius, 1 << 11);

      //검출된 에너미들에게 수류탄 데미지를 입힌다.//////////////////
      //for(int i=0; i<player.Length; i++)
      //{
        ///에너미FSM에 있는 HITENEMY함수가져오기//////////////////////
        //PlayerCtrl eFSM = player[i].transform.GetComponent<PlayerCtrl>();
        //eFSM.OnTriggerEnter();
        
      //}
      /////////////////////
      Destroy(this.gameObject);
    }
}
