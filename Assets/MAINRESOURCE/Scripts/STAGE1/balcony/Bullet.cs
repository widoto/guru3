using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float mLastTime;
    // Start is called before the first frame update
    

    //오디오 소스 컴포넌트 변수
    AudioSource aSource;
    void Start()
    {

      
        mLastTime = Time.time;
        GetComponent<Rigidbody> ().AddForce(transform.forward*1000);

        //오디오 소스 컴포넌트 가져오기
        aSource = GetComponent<AudioSource>();
        //포탄 소리를 플레이 한다.
        aSource.Play();


    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if(time - mLastTime > 2.0f)
        {
          Destroy(this.gameObject);
        }
      
        
    }
  
}
