using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HowTo3 : MonoBehaviour
{
    public void ChangeFirstScene()
    {
      SceneManager.LoadScene("stage2");
    }
}
