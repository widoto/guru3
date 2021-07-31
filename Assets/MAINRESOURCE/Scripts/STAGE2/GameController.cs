using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshProUGUI textCoinCount;
    private int coinCount = 0;

    private void Awake()
    {
      textCoinCount.enabled = true;
    }
    void Start()
    {
        
    }

    public void IncreaseCoinCount()
    {
      coinCount ++;
      textCoinCount.text = coinCount.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
