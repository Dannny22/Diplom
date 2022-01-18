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
    public int time = 0;
    //public bool Roll;
    //public Image UISkill1;
    //public Image UISkill2;
    public Text UISkill1Time;
    public Text UISkill2Time;

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("start", true);
        anim.SetBool("start", false);
    }
    void DiactivetAttack()
    {
        Enemy.Attack = false;
    }
    void DiactivetRoll()
    {
        //Roll = false;
        anim.SetBool("Roll 0", false);
    }
    // Update is called once per frame
    void Update()
    {
        UIMana.fillAmount = Mana;
        Mana += Time.deltaTime / 25f;
        //anim.SetBool("Jump", false);
        if (Input.GetKeyDown(KeyCode.C))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Crouch");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            //gameObject.GetComponent<Animator>().SetTrigger("Roll");
            //Roll = true;
            Invoke("DiactivetRoll", 0.5f);
            anim.SetBool("Roll 0", true);
        }

        if (Mana > 1f)
        {
            Mana = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) & CountdownSkill1 <= 0 & Mana >= 0.25f)
        {
            
            Instantiate(Skill1, transform.position, transform.rotation);
            CountdownSkill1 = 6f;
            Mana = Mana - 0.25f;
            StartCoroutine(Skill1Time());
        }
        if (CountdownSkill1 <= 0)
        {
            //UISkill1.gameObject.SetActive(false);
            UISkill1Time.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha2) & CountdownSkill2 <= 0 & Mana >= 0.5f)
        {
            Instantiate(Skill2, transform.position, transform.rotation);
            CountdownSkill2 = 11f;
            Mana = Mana - 0.5f;
            StartCoroutine(Skill2Time());
        }
        if (CountdownSkill2 <= 0)
        {
            UISkill2Time.gameObject.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Enemy.Attack = true;
            Invoke("DiactivetAttack", 0.5f);
            gameObject.GetComponent<Animator>().SetTrigger("attack");
        }
        
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
            gameObject.GetComponent<Animator>().SetTrigger("Jump 0");
            //anim.SetBool("Jump", true);
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator Skill1Time()
    {
        while (CountdownSkill1 > 0)
        {
            CountdownSkill1 = CountdownSkill1 - 1f;
            //UISkill1.gameObject.SetActive(true);
            UISkill1Time.gameObject.SetActive(true);
            UISkill1Time.text = "" + CountdownSkill1;
            //UISkill1.fillAmount = CountdownSkill1 / 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator Skill2Time()
    {
        while (CountdownSkill2 > 0)
        {
            CountdownSkill2 = CountdownSkill2 - 1f;
            //UISkill1.gameObject.SetActive(true);
            UISkill2Time.gameObject.SetActive(true);
            UISkill2Time.text = "" + CountdownSkill2;
            //UISkill1.fillAmount = CountdownSkill1 / 2.5f;
            yield return new WaitForSeconds(1f);
        }
    }

}
