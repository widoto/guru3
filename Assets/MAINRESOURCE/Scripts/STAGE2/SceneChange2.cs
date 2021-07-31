using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;       // Unity-UI를 사용하기 위해 선언한 네임스페이스
using UnityEngine.Events;
public class SceneChange2 : MonoBehaviour
{
    // Start is called before the first frame update
  
    public void ChangeFirstScene()
    {
      SceneManager.LoadScene("HowTo3");
    }

    public void ClickExit()
    {
      Debug.Log("게임종료");
      Application.Quit();
      
    }
}
