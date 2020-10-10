using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float Health;
    public GameObject playerHealthObj;
    private Slider playerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        playerHealthSlider = playerHealthObj.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthSlider.value = Health / 10;
        if (Health <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("GameOver");
        }
    }

    public void takeDamage()
    {
        Health -= 20;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            Health -= 0.1f;
        }
    }
}

