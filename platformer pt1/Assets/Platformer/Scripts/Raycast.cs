using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera camera;
    public AudioClip breaking;
    public AudioClip CoinSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<BrickBreak>() != null)
                {
                    audioSource.clip = breaking;
                    Destroy(hitInfo.collider.gameObject);
                    audioSource.Play();
                }
                else if (hitInfo.collider.gameObject.GetComponent<CoinPop>() != null)
                {
                    audioSource.clip = CoinSound;
                    Debug.Log("Question Mark Block been tapped :D");
                    audioSource.Play();
                }
            }
        }
        
    }
}
