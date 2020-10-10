using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageHealth : MonoBehaviour
{
    public int EnemyHealth = 100;
    public float damageCooldown = 0.5f;
    private bool canAttack = true;
    private float saveCD;
    // Start is called before the first frame update
    void Start()
    {
        saveCD = damageCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack == false)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                canAttack = true;
                damageCooldown = saveCD;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            EnemyHealth -= 35;
            if (EnemyHealth < 0)
            {
                PlayerPrefs.SetString(SceneManager.GetActiveScene().name + gameObject.name, "taken");
                Destroy(collision.gameObject);
                gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Player") && canAttack == true)
        {
            PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();
            player.SendMessage("takeDamage");
            canAttack = false;
        }
    }
}
