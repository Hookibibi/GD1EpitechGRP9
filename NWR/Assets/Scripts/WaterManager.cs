using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterManager : MonoBehaviour
{
    private float cooldownBeforeExpires;
    // Start is called before the first frame update
    void Start()
    {
        cooldownBeforeExpires = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownBeforeExpires -= Time.deltaTime;
        if (cooldownBeforeExpires < 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Puddle"))
        {
            Color current = collision.gameObject.GetComponent<SpriteRenderer>().color;
            current.a -= 0.2f;
            collision.gameObject.GetComponent<SpriteRenderer>().color = current;
            if (current.a <= 0.0f)
            {
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + collision.gameObject.name, "taken");
                collision.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Puddle"))
        {
            Color current = collision.gameObject.GetComponent<SpriteRenderer>().color;
            current.a -= 0.2f;
            collision.gameObject.GetComponent<SpriteRenderer>().color = current;
            if (current.a <= 0.0f)
            {
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + collision.gameObject.name, "taken");
                if (PlayerPrefs.HasKey("CurrentPaddle"))
                    PlayerPrefs.SetInt("CurrentPaddle", PlayerPrefs.GetInt("CurrentPaddle"));
                else
                    PlayerPrefs.SetInt("CurrentPaddle", 1);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
