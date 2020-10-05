using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    private float HorizontalMove = 0.0f;
    private float VerticalMove = 0.0f;
    private CharacterController CharacterC;
    // Start is called before the first frame update
    void Start()
    {
        CharacterC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal") * PlayerSpeed;
        VerticalMove = Input.GetAxis("Vertical")* PlayerSpeed;

    }

    private void FixedUpdate()
    {
        CharacterC.Move(new Vector3(HorizontalMove * Time.deltaTime, VerticalMove * Time.deltaTime, 0.0f));
    }
}
