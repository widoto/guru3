using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField]
    private GameObject coinEffectPrefab;
    private float rotateSpeed;

    private void Awake()
    {
      rotateSpeed = Random.Range(0,360);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
      if(GameManager.instance.gState != GameManager.GameState.Run)
        {
          return;
        }
        transform.Rotate(Vector3.right * rotateSpeed *2* Time.deltaTime);
    }

    
}
