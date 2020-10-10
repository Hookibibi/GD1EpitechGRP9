using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + gameObject.name))
        {
            if (PlayerPrefs.GetString(SceneManager.GetActiveScene().name + gameObject.name) == "taken")
            {
                PlayerPrefs.DeleteKey(SceneManager.GetActiveScene().name + gameObject.name);
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
