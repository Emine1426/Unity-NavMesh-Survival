using UnityEngine;
using UnityEngine.EventSystems;

public class Move : MonoBehaviour
{
    public int speed = 5;
    CharacterController controller;
    Animator anim;
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    float verticalVelocity = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetFloat("saldiri", 1);
            if (Sword.IsAtacking == false && GetComponent<CharacterHealth>().health > 0)
            {
                audio.Play();
            }

        }
        else
        {
            anim.SetFloat("saldiri", 0);

        }



        float move = Input.GetAxis("Vertical");
        float turn = Input.GetAxis("Horizontal");
        anim.SetFloat("hareket", move);
        Vector3 forward = transform.forward * move * speed;

        if (GetComponent<CharacterHealth>().health > 0)
        {
            transform.Rotate(0, turn, 0);
        }

        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = 5;
            }
        }
        else
        {

            verticalVelocity -= 9.87f * Time.deltaTime;
        }

        Vector3 moveDirection = new Vector3(forward.x, verticalVelocity, forward.z);
        if (Sword.IsAtacking == false)
        {
            if (GetComponent<CharacterHealth>().health > 0)
            {
                controller.Move(moveDirection * Time.deltaTime);
            }
        }
    }
}

