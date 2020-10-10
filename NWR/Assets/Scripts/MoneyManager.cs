using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text PaddleText;
    public Text dechetsText;
    public Text ArgentWin;
    public Text ArgentTotal;

    private int paddleCount;
    private int trashCount;
    private int moneyCount;
    private int fraisCount;
    private int totalMoney;

    private float cooldown = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("CurrentPaddle"))
        {
            paddleCount = PlayerPrefs.GetInt("CurrentPaddle");
            PaddleText.text = "Sol contaminés nettoyés : " + PlayerPrefs.GetInt("CurrentPaddle").ToString();
        }
        else
        {
            PaddleText.text = "Sol contaminés nettoyés : 0";
            paddleCount = 0;
        }

        if (PlayerPrefs.HasKey("CurrentTrash"))
        {
            dechetsText.text = "Déchets récupérés " + PlayerPrefs.GetInt("CurrentTrash").ToString();
            trashCount = PlayerPrefs.GetInt("CurrentTrash");
        }
        else
        {
            trashCount = 0;
            dechetsText.text = "Déchets récupérés : 0";
        }

        moneyCount = (paddleCount * 50) + (trashCount * 100);
        ArgentWin.text = "Argent gagné : " + moneyCount.ToString();
        fraisCount = 150;
        if (PlayerPrefs.HasKey("currentMoney"))
            totalMoney = moneyCount - fraisCount + PlayerPrefs.GetInt("currentMoney");
        else
            totalMoney = moneyCount - fraisCount;
        PlayerPrefs.SetInt("currentMoney", totalMoney);
        ArgentTotal.text = "Argent total (+ économies) : " + totalMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            // Go Back to Hub
        }
    }
}
