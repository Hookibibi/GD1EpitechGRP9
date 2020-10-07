using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    private float HorizontalMove = 0.0f;
    private float VerticalMove = 0.0f;

    // If you use Character controller remove comment
    private CharacterController CharacterC;
    
    // Start is called before the first frame update
    void Start()
    {
        // If you use Character controller remove comment
        // CharacterC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal") * PlayerSpeed;
        VerticalMove = Input.GetAxis("Vertical")* PlayerSpeed;

        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookAt = mouseScreenPosition;

        float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

        float AngleDeg = (180 / Mathf.PI) * AngleRad;

        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(HorizontalMove * Time.deltaTime, VerticalMove * Time.deltaTime, 0.0f) * PlayerSpeed * Time.deltaTime;
        // CharacterC.Move(new Vector3(HorizontalMove * Time.deltaTime, VerticalMove * Time.deltaTime, 0.0f));
    }
}
