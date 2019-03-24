using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyCollect : MonoBehaviour {

    private KeyController Controller;

    private void Start()
    {
        Controller = GetComponentInParent<KeyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Controller.HasKey = true;

        if (other.tag == "Player")
        gameObject.SetActive(false);
    }
}
