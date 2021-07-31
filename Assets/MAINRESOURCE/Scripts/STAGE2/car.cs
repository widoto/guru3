using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //전진

        if(GameManager.instance.gState != GameManager.GameState.Run)
        {
          return;
        }
        transform.Translate(Vector3.left  *15* Time.deltaTime,Space.World);
    }
}
