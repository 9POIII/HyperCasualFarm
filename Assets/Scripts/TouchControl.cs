using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private GameObject jumpers;
    private bool canMove = true;

    private void Update()
    {
        if (Input.touchCount > 0 && canMove && Input.touches[0].phase == TouchPhase.Began)
        {
            var interactable = SetInteractable();
            if (interactable != null)
            {
                interactable.ActivateMotor();
                canMove = false;
            }
        }
        else if (Input.touchCount <= 0 && canMove == false)
        {
            var interactable = SetInteractable();
            if (interactable != null)
            {
                interactable.DisactivateMotor();
                canMove = true;
            }
        }
        
#if UNITY_EDITOR
        
        if (Input.GetMouseButtonDown(0))
        {
            var interactable = SetInteractable();
            if (interactable != null)
            {
                interactable.ActivateMotor();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var interactable = SetInteractable();
            if (interactable != null)
            {
                interactable.DisactivateMotor();
            }
        }
#endif
    }

    private IUseHinge SetInteractable()
    {
        return jumpers.GetComponent<IUseHinge>();
    }
}
