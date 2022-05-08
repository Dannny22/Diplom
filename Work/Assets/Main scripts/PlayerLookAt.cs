using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAt : MonoBehaviour
{
    Animator _animator;
    public Camera _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
         _animator = GetComponent<Animator>();
         //_mainCamera = Camera.main;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        _animator.SetLookAtWeight(1f, .5f, 1f, .5f, .5f);
        Ray lookAtRay = new Ray(transform.position, _mainCamera.transform.forward);
        _animator.SetLookAtPosition(lookAtRay.GetPoint(25));
    }
}
