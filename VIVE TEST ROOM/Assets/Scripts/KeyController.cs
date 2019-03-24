using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyController : MonoBehaviour {


    public bool HasKey = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (HasKey)
        {
            //FadeOut Camera
        }
    }
}
