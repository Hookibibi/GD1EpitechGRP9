using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnLights : MonoBehaviour
{
    private bool touchingGene = false;
    private bool lightActive;
    public GameObject globalLight;
    public GameObject pointLight;
    public float startDuration;
    private float timeRemaining;
    private bool lampTurnon;
    public AudioSource audioSource;

    public Text lightTime;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("LightLvl"))
        {
            startDuration = PlayerPrefs.GetInt("LightLvl") * 30;
        }
        else
        {
            startDuration = 30;
            PlayerPrefs.SetInt("LightLvl", 1);
        }
        if (PlayerPrefs.HasKey("ElecTurnedOn") && PlayerPrefs.GetString("ElecTurnedOn") == "true")
        {
            TurnOn();
            lightActive = true;
        }
        else
        {
            lampTurnon = true;
            lightActive = false;
            timeRemaining = startDuration;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (touchingGene && lightActive == false)
            {
                TurnOn();
                lightActive = true;
                PlayerPrefs.SetString("ElecTurnedOn", "true");
            }
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
                timeRemaining = 0.0f;
                lampTurnon = false;
                pointLight.SetActive(false);
                audioSource.Play();
            }
        }
        lightTime.text = "Lumière restante : " + DisplayTime(timeRemaining);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Generator")
        {
            touchingGene = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Generator")
        {
            touchingGene = false;
        }
    }

    private void TurnOn()
    {
        globalLight.SetActive(true);
    }

    string DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        return (string.Format("{0:00}:{1:00}", minutes, seconds));
    }
}
