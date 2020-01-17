using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private WheelJoint2D wheelJoint;
    private JointMotor2D jointMotor;
  
    private void Awake()  
    {
        wheelJoint = GetComponent<WheelJoint2D>();
        jointMotor = new JointMotor2D(); 
        StartCoroutine("RotateController");
    }

    private IEnumerator RotateController() 
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            jointMotor.motorSpeed = GetRandomSpeedValue();
            jointMotor.maxMotorTorque = 10000;
            wheelJoint.motor = jointMotor;
            yield return new WaitForSeconds(GetRandomTimeValue());
        }
    }

    private float GetRandomSpeedValue() 
    {
        return Random.Range(-225f, 225f);  
    }

    private float GetRandomTimeValue() 
    {
        return Random.Range(0.5f, 2.5f);
    }

}
