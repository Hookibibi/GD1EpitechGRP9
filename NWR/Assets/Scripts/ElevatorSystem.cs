using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorSystem : MonoBehaviour
{
    private bool touchingElev;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingElev)
        {
            // Go back to Main Menu
            PlayerPrefs.Save();
            SceneManager.LoadScene("BackToHub");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ascenseur")
        {
            touchingElev = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ascenseur")
        {
            touchingElev = false;
        }
    }

}
