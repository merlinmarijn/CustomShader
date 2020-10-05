using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playercam;

    public float MoveSpeed;
    private float Turnspeed;

    private Rigidbody RB;

    Animator Animation;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            float HorizontalMovement = Input.GetAxis("Horizontal");
            float VerticalMovement = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(HorizontalMovement, 0, VerticalMovement);


            Vector3 forward = new Vector3(playercam.transform.forward.x, 0, playercam.transform.forward.z);
            Vector3 forwardmomentum = forward * Time.deltaTime * MoveSpeed * VerticalMovement;

            Vector3 sideways = new Vector3(playercam.transform.right.x, 0, playercam.transform.right.z);
            Vector3 sidewaysmomentum = sideways * Time.deltaTime * MoveSpeed * HorizontalMovement;


            transform.position += forwardmomentum + sidewaysmomentum;


            Vector3 temp = transform.position + (forwardmomentum + sidewaysmomentum);

            transform.LookAt(new Vector3(temp.x, transform.position.y, temp.z));
        if (forwardmomentum != Vector3.zero || sidewaysmomentum != Vector3.zero)
        {
            Animation.SetFloat("Blend", 0.2f);
        } else
        {
            Animation.SetFloat("Blend", 0f);

        }
    }
}
