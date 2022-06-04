using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoCache
{
    public Transform Model;

    public Transform TargetLock;

    [Range(20f, 80f)]
    public float RotationSpeed = 20f;
    public Camera mainCamera;

    private Animator Anim;

    private Vector3 StickDirection;
    private bool IsWeaponEquipped = false;
    private bool IsTargetLocked = false;
    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        Cursor.visible = false;
        Anim = Model.GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void OnTick()
    {
        StickDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        HandleInputData();
        if (IsTargetLocked) HandleTargetLockedLocomotionRotation();
        else HandleStandardLocomotionRotation();
    } 

    private void HandleStandardLocomotionRotation()
    {
        Vector3 rotationOffset = mainCamera.transform.TransformDirection(StickDirection);
        rotationOffset.y = 0;
        Model.forward  += Vector3.Lerp(Model.forward, rotationOffset, Time.deltaTime * RotationSpeed);
    }

    private void HandleTargetLockedLocomotionRotation()
    {
        Vector3 rotationOffset = TargetLock.transform.position - Model.position;
        rotationOffset.y = 0;
        Model.forward += Vector3.Lerp(Model.forward, rotationOffset, Time.deltaTime * RotationSpeed);
    }

    private void HandleInputData()
    {
        Anim.SetFloat("Speed", Vector3.ClampMagnitude(StickDirection, 1).magnitude);
        Anim.SetFloat("Horizontal", StickDirection.x);
        Anim.SetFloat("Vertical", StickDirection.z);
        IsWeaponEquipped = Anim.GetBool("IsWeaponEquipped");
        IsTargetLocked = Anim.GetBool("IsTargetLocked");
        if (IsWeaponEquipped && Input.GetKeyDown(KeyCode.T))
        {
            Anim.SetBool("IsTargetLocked", !IsTargetLocked);
            IsTargetLocked = !IsTargetLocked;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Anim.SetBool("IsWeaponEquipped", !IsWeaponEquipped);
            IsWeaponEquipped = !IsWeaponEquipped;
            if (IsWeaponEquipped == false)
            {
                Anim.SetBool("IsTargetLocked", false);
                IsTargetLocked = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetTrigger("Jump");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Anim.SetBool("CrouchIdle", true); 
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            Anim.SetBool("CrouchIdle", false);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Anim.SetTrigger("Roll");
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Enemy.Attack = true;
            Anim.SetTrigger("Attack");
        }
    }
}
