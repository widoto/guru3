using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Final : MonoBehaviour
{
    public void ChangeFirstScene()
    {
      SceneManager.LoadScene("FinalClear"); //요것두 씬전환
    }
}
