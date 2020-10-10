using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class Weapons : MonoBehaviour
{
    public bool currentWeapon;
    public int ammoGun;
    public int ammoWater;

    public Text ammoText;

    public GameObject bulletPrefab;
    public GameObject waterPrefab;

    public GameObject imageGun;
    public GameObject imageWater;

    public GameObject ammoGunImage;
    public GameObject waterGunImage;

    public GameObject baseLight;
    private UnityEngine.Experimental.Rendering.Universal.Light2D baseLightComp;

    private float timebetweenShot;
    private bool canShoot;

    private bool aiming;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = true;
        aiming = false;
        ammoText.text = ammoGun.ToString();
        baseLightComp = baseLight.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

        if (PlayerPrefs.HasKey("gunAmmo"))
        {
            ammoGun = PlayerPrefs.GetInt("gunAmmo");
        }
        else
        {
            ammoGun = 24;
            PlayerPrefs.SetInt("gunAmmo", ammoGun);
        }

        if (PlayerPrefs.HasKey("tankLevel"))
        {
            int lvl = PlayerPrefs.GetInt("tankLevel");
            if (lvl == 1)
                ammoWater = 50;
            else if (lvl == 2)
                ammoWater = 100;
            else if (lvl == 3)
                ammoWater = 200;
        }
        else
        {
            PlayerPrefs.SetInt("tankLevel", 1);
            ammoWater = 50;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentWeapon == true && ammoGun > 0 && canShoot == true)
        {
            GameObject bulletObj = Instantiate(bulletPrefab, transform.position, transform.rotation);

            Physics2D.IgnoreCollision(bulletObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            bulletObj.GetComponent<Rigidbody2D>().AddForce(transform.up * 20f, ForceMode2D.Impulse);

            canShoot = false;
            ammoGun--;
            PlayerPrefs.SetInt("gunAmmo", ammoGun);
            ammoText.text = ammoGun.ToString();
            timebetweenShot = 0.6f;
        }
        else if (Input.GetMouseButton(0) && currentWeapon == false && ammoWater > 0 && canShoot == true)
        {
            GameObject waterObj = Instantiate(waterPrefab, transform.position, transform.rotation);

            Physics2D.IgnoreCollision(waterObj.GetComponent<Collider2D>(), GetComponent<Collider2D>());

            waterObj.GetComponent<Rigidbody2D>().AddForce(transform.up * 5f, ForceMode2D.Impulse);

            canShoot = false;
            ammoWater--;
            ammoText.text = ammoWater.ToString();
            timebetweenShot = 0.05f;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            currentWeapon = !currentWeapon;
            if (currentWeapon)
            {
                ammoText.text = ammoGun.ToString();
                imageGun.SetActive(true);
                ammoGunImage.SetActive(true);
                waterGunImage.SetActive(false);
                imageWater.SetActive(false);
            }
            else
            {
                ammoText.text = ammoWater.ToString();
                imageGun.SetActive(false);
                ammoGunImage.SetActive(false);
                waterGunImage.SetActive(true);
                imageWater.SetActive(true);
            }
        }
        if (canShoot == false)
        {
            timebetweenShot -= Time.deltaTime;
            if (timebetweenShot < 0)
                canShoot = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            aiming = !aiming;
            if (aiming)
            {
                baseLightComp.pointLightInnerAngle = 40;
                baseLightComp.pointLightOuterAngle = 60;
                baseLightComp.pointLightOuterRadius = 10;
            }
            else
            {
                baseLightComp.pointLightInnerAngle = 60;
                baseLightComp.pointLightOuterAngle = 100;
                baseLightComp.pointLightOuterRadius = 5;
            }
        }
    }
}
