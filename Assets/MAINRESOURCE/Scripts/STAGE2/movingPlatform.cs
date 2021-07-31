using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
      Player.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
      Player.transform.parent = null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
