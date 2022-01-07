using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public float jumpHeight = 2f;

    public float gravity = -15f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistanse = 0.4f;
    public LayerMask groundMask;
    bool onGround;

    public GameObject Skill1;
    public GameObject Skill2;
    public float CountdownSkill1 = 0f;
    public float CountdownSkill2 = 0f;
    public float Mana = 1f;
    public Image UIMana;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIMana.fillAmount = Mana;
        CountdownSkill1 -= Time.deltaTime;
        CountdownSkill2 -= Time.deltaTime;
        Mana += Time.deltaTime / 25f;

        if (Mana > 1f)
        {
            Mana = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) & CountdownSkill1 <= 0 & Mana >= 0.25f)
        {
            Instantiate(Skill1, transform.position, transform.rotation);
            CountdownSkill1 = 5f;
            Mana = Mana - 0.25f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) & CountdownSkill2 <= 0 & Mana >= 0.5f)
        {
            Instantiate(Skill2, transform.position, transform.rotation);
            CountdownSkill2 = 10f;
            Mana = Mana - 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("attack");
        }
        anim.SetBool("Jump", false);
        onGround = Physics.CheckSphere(groundCheck.position, groundDistanse, groundMask);

        if(onGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, 0f, v).normalized;
        anim.SetFloat("speed", v, 0.15f, Time.deltaTime);
        anim.SetFloat("Blend", h, 0.15f, Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngel = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngel, 0f) * Vector3.forward;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if(Input.GetButtonDown("Jump") && onGround)
        {
            anim.SetBool("Jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


    }

}
