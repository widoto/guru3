using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    // 스파크 파티클 프리팹을 연결할 변수
    public GameObject sparkEffect;

    //오디오 소스 컴포넌트 변수
    AudioSource aSource;

    // 충돌이 시작할 때 발생하는 이벤트

    void Start()
    {
        //오디오 소스 컴포넌트 가져오기
        //aSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision coll)
    {


        // 충돌한 게임오브젝트의 태그값 비교
        if (coll.collider.CompareTag("BULLET"))
        {

            
            //포탄 소리를 플레이 한다.
            //aSource.Play();
            // 첫 번째 충돌 지점의 정보 추출
            ContactPoint cp = coll.GetContact(0);
            // 충돌한 총알의 법선 벡터를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(-cp.normal);

            // 스파크 파티클을 동적으로 생성
            GameObject spark = Instantiate(sparkEffect, cp.point, rot);
            

            this.transform.GetComponent<Cube>().Explosion();
            // 일정 시간이 지난 후 스파크 파티클을 삭제
            Destroy(spark, 0.5f);

            // 충돌한 게임오브젝트 삭제
            Destroy(coll.gameObject);
        }

    }
}
