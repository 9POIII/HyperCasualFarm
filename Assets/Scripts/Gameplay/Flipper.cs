using UnityEngine;

public class Flipper : MonoBehaviour, IUseHinge
{
    [SerializeField] private HingeJoint2D[] hingeJoint2D;
    public HingeJoint2D[] HingeJoint2D
    {
        get => hingeJoint2D;
        set => hingeJoint2D = value;
    }

    public void ActivateMotor()
    {
        for (int i = 0; i < HingeJoint2D.Length; i++)
        {
            HingeJoint2D[i].useMotor = true;
        }
    }

    public void DisactivateMotor()
    {
        for (int i = 0; i < HingeJoint2D.Length; i++)
        {
            HingeJoint2D[i].useMotor = false;
        }
    }
}
