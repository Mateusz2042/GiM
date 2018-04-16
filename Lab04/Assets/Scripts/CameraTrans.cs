using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrans : MonoBehaviour
{

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

    }
    public GameObject player;

    private Vector3 offset;

    // Use this for initialization

    void Start()

    {

        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame

    void LateUpdate()

    {

        transform.position = player.transform.position + offset;

    }
}
