using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowTo1 : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeFirstScene()
    {
      SceneManager.LoadScene("HowTo2");
    }
}
