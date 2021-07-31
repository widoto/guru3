using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;       // Unity-UI를 사용하기 위해 선언한 네임스페이스
using UnityEngine.Events;   // UnityEvent 관련 API를 사용하기 위해 선언한 네임스페이스
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public string sceneName = "HowTo1";

    public void ClickStart()
    {
      Debug.Log("로딩");
      SceneManager.LoadScene(sceneName);
    }

    public void ClickExit()
    {
      Debug.Log("게임종료");
      Application.Quit();
      
    }
}

