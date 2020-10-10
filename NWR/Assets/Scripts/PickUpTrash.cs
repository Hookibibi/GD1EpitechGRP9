using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickUpTrash : MonoBehaviour
{
    private bool touchingWaste;
    private GameObject trashTouched;
    public Text counterText;
    private int counterTrash;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("CurrentTrash", 0);
        counterTrash = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (touchingWaste)
            {
                Debug.Log("Picked up : " + SceneManager.GetActiveScene().name + trashTouched.name);
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + trashTouched.name, "taken");
                PlayerPrefs.SetInt("CurrentTrash", PlayerPrefs.GetInt("CurrentTrash") + 1);
                trashTouched.SetActive(false);
                touchingWaste = false;
                counterTrash++;
                counterText.text = counterTrash.ToString();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Waste"))
        {
            touchingWaste = true;
            trashTouched = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Waste"))
        {
            touchingWaste = false;
        }
    }

}
