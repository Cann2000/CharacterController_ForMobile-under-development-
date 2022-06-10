using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] Joystick jy;

    CharacterController charcont;

    Vector3 movement;

    Animator anim;

    [Range(3, 15)]
    public float speed;

    float gravity;

    void Start()
    {
        gravity = 0.5f;
        charcont = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Move & Look

        movement = new Vector3(jy.Horizontal * Time.deltaTime * speed, movement.y, jy.Vertical * speed * Time.deltaTime);
        charcont.Move(movement);


        if (jy.Horizontal == 0 && jy.Vertical == 0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);

            Vector3 lookdirect = new Vector3(jy.Horizontal, 0, jy.Vertical);
            transform.rotation = Quaternion.LookRotation(lookdirect);
        }

        // Gravity

        if (charcont.isGrounded)
        {
            movement.y = 0;
        }
        else
        {
            movement.y -= gravity * Time.deltaTime;
        }
    }

    void Update()
    {

    }
}
