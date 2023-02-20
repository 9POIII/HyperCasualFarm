using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private bool canMove = true;
    private IUseHinge interactable;
    [SerializeField] private GameState gameState;
    
    private void Start()
    {
        interactable = SetInteractable();
    }

    private void Update()
    {
        if (interactable != null && gameState.CanPlay)
        {
            if (Input.touchCount > 0 && canMove && Input.touches[0].phase == TouchPhase.Began)
            {
                interactable.ActivateMotor();
                canMove = false;
            }
            else if (Input.touchCount <= 0 && canMove == false)
            {
                interactable.DisactivateMotor();
                canMove = true;
            }
        }

#if UNITY_EDITOR

        if (interactable != null && gameState.CanPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                interactable.ActivateMotor();
            }
            else if (Input.GetMouseButtonUp(0))
            { 
                interactable.DisactivateMotor();
            }
        }
#endif
    }

    private IUseHinge SetInteractable()
    {
        return gameObject.GetComponent<IUseHinge>();
    }
}
