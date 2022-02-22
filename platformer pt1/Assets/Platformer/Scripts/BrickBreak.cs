using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBreak : MonoBehaviour
{
    private GameObject brick;
    
    // Start is called before the first frame update
    void Start()
    {
        brick = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        Debug.Log("Selected a brick");
    }

    private void OnMouseExit()
    {
        Debug.Log("Left the brick");
    }
}
