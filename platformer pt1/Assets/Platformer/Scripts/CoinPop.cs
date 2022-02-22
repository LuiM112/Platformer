using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPop : MonoBehaviour
{
    private GameObject QBlock;
    
    // Start is called before the first frame update
    void Start()
    {
        QBlock = GetComponent<GameObject>();
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
