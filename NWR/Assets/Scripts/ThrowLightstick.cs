using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowLightstick : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lightstick;
    public int lightstickNumber;
    public Text lightstickText;
    private void Start()
    {
        if (PlayerPrefs.HasKey("LightstickCount"))
            lightstickNumber = PlayerPrefs.GetInt("LightstickCount");
        else
        {
            lightstickNumber = 5;
            PlayerPrefs.SetInt("LightstickCount", lightstickNumber);
        }
        lightstickText.text = lightstickNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && lightstickNumber > 0)
        {
            GameObject stick = (GameObject)Instantiate(lightstick, transform.position, transform.rotation);
            Physics2D.IgnoreCollision(stick.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            stick.GetComponent<Rigidbody2D>().AddForce(transform.up * 20f, ForceMode2D.Impulse);

            lightstickNumber--;
            PlayerPrefs.SetInt("LightstickCount", lightstickNumber);
            lightstickText.text = lightstickNumber.ToString();
        }
    }
}
