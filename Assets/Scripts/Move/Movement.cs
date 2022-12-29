using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public CharacterController controller;
    AudioSource source;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float runSpeed = 12f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 3.5f;

    [SerializeField] private float timeBetweenSteps = 0.7f;
    [SerializeField] private AudioClip[] defaultSound;
    [SerializeField] private AudioClip[] grassSound;
    [SerializeField] private AudioClip[] snowSound;
    int soundControl;
    float timer;

    Vector3 velocity;
    bool isGrounded;
    bool isMove;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.transform.tag)
        {
            case "Ground": soundControl = 0; break;
            case "Grass": soundControl = 1; break;
            case "Snow": soundControl = 2; break;

        }
    }

    void Update()
    {
        #region Move
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        #endregion

        #region Footsteps
        isMove = (x != 0 || z != 0) ? true : false;
        if (isMove && isGrounded)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                switch (soundControl)
                {
                    case 0: source.clip = defaultSound[UnityEngine.Random.Range(0, defaultSound.Length)]; break;
                    case 1: source.clip = grassSound[UnityEngine.Random.Range(0, defaultSound.Length)]; break;
                    case 2: source.clip = snowSound[UnityEngine.Random.Range(0, defaultSound.Length)]; break;

                }


                timer = timeBetweenSteps;
                source.pitch = UnityEngine.Random.Range(0.85f, 1.15f);
                source.Play();
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }
        #endregion

        #region Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        #endregion

        #region Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * runSpeed * Time.deltaTime);
            timeBetweenSteps = 0.3f;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * speed * Time.deltaTime);
            timeBetweenSteps = 0.7f;
        }

        #endregion

    }
}
