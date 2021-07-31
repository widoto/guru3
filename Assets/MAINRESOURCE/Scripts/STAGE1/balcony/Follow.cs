using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePos;
    public GameObject bullet;

    Transform tranobj;
    float mLastTime;
    RaycastHit hit;
    void Start()
    {
        tranobj = GameObject.Find("Player").transform;
        mLastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(tranobj);

        float time = Time.time;
        Debug.DrawRay(firePos.position,firePos.forward * 15, Color.red);
        if(Physics.Raycast(firePos.position,firePos.forward,out hit, 15))
        {
          //Debug.Log(hit.collider.gameObject.tag);
          if(time - mLastTime > 2.0f)
          {
              Instantiate(bullet,firePos.position,firePos.rotation);
              mLastTime = time;
          }
          
        }
    }
}
