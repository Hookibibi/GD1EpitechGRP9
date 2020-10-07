using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLights : MonoBehaviour
{
    private bool touchingGene = false;
    private bool lightActive;
    public GameObject globalLight;
    public GameObject pointLight;
    public float startDuration = 15;
    private float timeRemaining;
    private bool lampTurnon;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        lampTurnon = true;
        lightActive = false;
        timeRemaining = startDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            if (touchingGene && lightActive == false)
            {
                TurnOn();
                lightActive = true;
            }
            else
                Debug.Log("already turned on");
        }
        if (Input.GetKeyDown(KeyCode.F) && timeRemaining > 0.0f)
        {
            lampTurnon = !lampTurnon;
            pointLight.SetActive(lampTurnon);
        }
        if (lampTurnon && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                lampTurnon = false;
                pointLight.SetActive(false);
                audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter");
        if (other.tag == "Generator")
        {
            touchingGene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");
        if (other.tag == "Generator")
        {
            touchingGene = false;
        }
    }

    private void TurnOn()
    {
        globalLight.SetActive(true);
    }
}
