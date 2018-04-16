using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triger : MonoBehaviour {

    public GameObject wall;
    private Animator anim;
    void OnTriggerEnter(Collider other)
    {
        anim = wall.GetComponent<Animator>();
        if (other.GetComponent<Collider>().CompareTag("Player"))
        {
           
            anim.Play("animation");
        }
    }
}
