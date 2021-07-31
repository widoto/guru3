using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    // 폭발 효과 프리팹 변수
    public GameObject explosion;
    //폭발 반경///////////////////////////
    public float explosionRadius = 5.0f;

    
    private void OnCollisionEnter(Collision collision)
    {
      // 만일 충돌한다면 폭발효과 이펙트를 생성한다.
      GameObject go = Instantiate(explosion);
      go.transform.position = transform.position;
  
      
      // 자신을 제거한다.
      Destroy(gameObject);
    }
}
