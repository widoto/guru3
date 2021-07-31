using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    

    // Start is called before the first frame update
    [SerializeField] GameObject m_goPrefab = null;
    [SerializeField] float m_force= 0f;
    [SerializeField] Vector3 m_offset = Vector3.zero;

    void Start()
    {
      
        
    }
    
    public void Explosion(){
      
      GameObject t_clone = Instantiate(m_goPrefab, transform.position, Quaternion.identity);
      Rigidbody[] t_rigids = t_clone.GetComponentsInChildren<Rigidbody>();
      for(int i =0;i<t_rigids.Length;i++)
      {
        t_rigids[i].AddExplosionForce(m_force,transform.position+m_offset,10f);
      }
      gameObject.SetActive(false);
    }
}
