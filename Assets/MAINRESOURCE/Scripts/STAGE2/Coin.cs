using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
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
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
      GameObject clone = Instantiate(coinEffectPrefab);
      clone.transform.position = transform.position;

      //동전 획득 소리를 플레이한다..
      Sfx.SoundPlay();
      Destroy(gameObject);
    }
}
