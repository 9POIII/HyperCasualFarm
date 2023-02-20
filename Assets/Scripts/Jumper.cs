using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour, IUseHinge
{
    [SerializeField] private HingeJoint2D[] hingeJoint2D;
    public HingeJoint2D[] HingeJoint2D
    {
        get => hingeJoint2D;
        set => hingeJoint2D = value;
    }

    public void ActivateMotor()
    {
        Debug.Log("start");
        for (int i = 0; i < hingeJoint2D.Length; i++)
        {
            hingeJoint2D[i].useMotor = true;
        }
    }

    public void DisactivateMotor()
    {
        Debug.Log("finish");
        for (int i = 0; i < hingeJoint2D.Length; i++)
        {
            hingeJoint2D[i].useMotor = false;
        }
    }
}
