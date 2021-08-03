using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DEADtoRESTART : MonoBehaviour
{
    public void ChangeFirstScene()
    {
      SceneManager.LoadScene("REALFINAL3"); //요건 씬 전환
    }
}
