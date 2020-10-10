using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadiationGestion : MonoBehaviour
{
    public float radiationExposure;
    public float radiationResistance;
    public float radiationProtection;
    public float radiationLimit;
    public float grayLevel;

    public PlayerMovement playerMov;

    public Text protec;
    public Text expo;
    public GameObject protecGameObject;
    private Slider protection;

    public float timeUntilExposure;
    private float saveTime;
    public float radiationTaken;
    // Start is called before the first frame update
    void Start()
    {
        protection = protecGameObject.GetComponent<Slider>();
        if (PlayerPrefs.HasKey("ResistanceLvl"))
        {
            int lvl = PlayerPrefs.GetInt("ResistanceLvl");
            if (lvl == 1)
                radiationResistance = 100;
            else if (lvl == 2)
                radiationResistance = 200;
            else if (lvl == 3)
                radiationResistance = 300;
        }
        else
        {
            radiationResistance = 100;
            PlayerPrefs.SetInt("ResistanceLvl", 1);
        }
        if (PlayerPrefs.HasKey("ProtectionLvl"))
        {
            int lvl = PlayerPrefs.GetInt("ProtectionLvl");
            if (lvl == 1)
                radiationProtection = 2;
            if (lvl == 2)
                radiationProtection = 3;
            if (lvl == 3)
                radiationProtection = 4;
        }
        else
        {
            radiationProtection = 2;
            PlayerPrefs.SetInt("ProtectionLvl", 1);
        }
        radiationExposure = 5;
        if (PlayerPrefs.HasKey("exposition"))
            radiationTaken = PlayerPrefs.GetFloat("exposition");
        else
            radiationTaken = 0;
        timeUntilExposure = radiationResistance / (radiationExposure - radiationProtection);
        saveTime = timeUntilExposure;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilExposure > 0)
        {
            timeUntilExposure -= Time.deltaTime;
            protection.value = (timeUntilExposure / saveTime) * 10;
        }
        if (timeUntilExposure <= 0.0f)
        {
            timeUntilExposure = 0.0f;
            radiationTaken += (grayLevel * Time.deltaTime);

            if (radiationTaken >= 10 && radiationTaken < 20)
                playerMov.PlayerSpeed = 11;
            else if (radiationTaken >= 20)
                playerMov.PlayerSpeed = 10;
            if (radiationLimit <= radiationTaken)
            {
                gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");
            }
        }
        expo.text = "Exposition : ";
        expo.text += radiationTaken.ToString("F2") + " gray";
        PlayerPrefs.SetFloat("exposition", radiationTaken);
    }
}
