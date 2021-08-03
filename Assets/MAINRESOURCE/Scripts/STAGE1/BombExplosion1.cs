using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion1 : MonoBehaviour
{
    // 폭발 효과 프리팹 변수
    public GameObject explosion;

    //수류탄 데미지 변수///////////////
    //public int bombPower = 50;

    //폭발 반경///////////////////////////
    //public float explosionRadius = 5.0f;

    // 만일 충돌한다면 폭발효과 이펙트를 생성한다.
    // 자신을 제거한다.

    
    private void OnCollisionEnter(Collision collision)
    {

      GameObject go = Instantiate(explosion);
      go.transform.position = transform.position;

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
      Destroy(gameObject); //내가 마 사라진다 마
    }
}
