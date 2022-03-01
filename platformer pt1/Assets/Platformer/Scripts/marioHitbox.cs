using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class marioHitbox : MonoBehaviour
{
    public float hitboxRange;
    public float sideRange;
    public AudioClip breaking;
    public AudioClip CoinSound;
    public int addScore = 00000;
    public int addCoin = 00;

    public GameObject scoreText;
    public GameObject coinCounterText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray headRay = new Ray(transform.position, Vector3.up);
        Ray leftSideRay = new Ray(transform.position, Vector3.right);
        Ray rightSideRay = new Ray(transform.position, Vector3.left);
        AudioSource audioSource = GetComponent<AudioSource>();
        
        if (Physics.Raycast(headRay, out hit, hitboxRange) && Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.collider.gameObject.GetComponent<BrickBreak>())
            {
                audioSource.clip = breaking;
                Destroy(hit.collider.gameObject);
                audioSource.Play();
                addScore += 100;
                scoreText.GetComponent<TextMeshProUGUI>().text = addScore.ToString();
            }
        }
        else if (Physics.Raycast(leftSideRay, out hit, sideRange) || Physics.Raycast(rightSideRay, out hit, sideRange))
        {
            if (hit.collider.gameObject.GetComponent<CoinCollect>())
            {
                audioSource.clip = CoinSound;
                Destroy(hit.collider.gameObject);
                audioSource.Play();
                addScore += 100;
                addCoin += 1;
                scoreText.GetComponent<TextMeshProUGUI>().text = addScore.ToString();
                coinCounterText.GetComponent<TextMeshProUGUI>().text = addCoin.ToString();
            }
        }
        
    }
    
}
