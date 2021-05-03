using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffectScript : MonoBehaviour
{
    public GameObject FireEffect;
    void Start()
    {
        
    }

  
    void LateUpdate()
    {
        if(FireEffect)
        Destroy(gameObject);
    }
}
