using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicValueProvider : MonoBehaviour
{
    /// <summary>
    /// this is incredibly hardcoded, please don't ask questions
    /// </summary>



    public ShipMovement SM;
    private float originalRotation;
    private float originalSpeedRotation;

    private void Start()
    {
        //this.transform.eulerAngles.z.OnVariableChange += VariableChangeHandler; this should work but idk why i hate this; if u can find a better solution pls do it
        originalRotation = WrapAngle(this.transform.eulerAngles.z);
        originalSpeedRotation = WrapAngle(this.transform.eulerAngles.x);
    }

    private void Update()
    {

        if (WrapAngle(transform.eulerAngles.x) > 45) transform.eulerAngles = new Vector3(45,transform.eulerAngles.y,transform.eulerAngles.z);
        if (WrapAngle(transform.eulerAngles.x) < -45) transform.eulerAngles = new Vector3(-45, transform.eulerAngles.y, transform.eulerAngles.z);   // i hate vr

        if (WrapAngle(transform.eulerAngles.z) != originalRotation && this.transform.name == "wheel1")
        {
            originalRotation = WrapAngle(transform.eulerAngles.z);
            rotateShip();
        }

        if (WrapAngle(transform.eulerAngles.x) != originalSpeedRotation && (this.transform.name == "left_gas_lever" || this.transform.name == "right_gas_lever"))
        {
            originalSpeedRotation = WrapAngle(this.transform.eulerAngles.x);
            changeSpeed();
        }
    }

    private void VariableChangeHandler(float newVal)
    {
    }

    public void changeSpeed()
    {
        SM.velocity = (WrapAngle(this.transform.eulerAngles.x)/3)*-1;
    }

    public void rotateShip()
    {
        SM.angle = WrapAngle(this.transform.eulerAngles.z);
    }

    private static float WrapAngle(float angle)
    {
        angle %= 360;
        if (angle > 180)
            return angle - 360;

        return angle;
    }
}

