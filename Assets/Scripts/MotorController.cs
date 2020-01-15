using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorController : MonoBehaviour
{
    private WheelJoint2D wheelJoint;
    private JointMotor2D jointMotor;
    public float[] rotationSpeed = new float [] {100,-100,200,-300,350};
    public float[] rotationTime = new float [] {1f,0.5f,2f,3f,2.5f,1.5f};


    private void Awake()  {
        wheelJoint = GetComponent<WheelJoint2D>();
        jointMotor = new JointMotor2D();    
        StartCoroutine("RotateController");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // // Update is called once per frame
    // void Update()
    // {
    //    // jointMotor.motorSpeed = speeds[Random.Range(0, speeds.Length)];
    // }

    IEnumerator RotateController() {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            jointMotor.motorSpeed = rotationSpeed[Random.Range(0, rotationSpeed.Length)];
            jointMotor.maxMotorTorque = 10000;
            wheelJoint.motor = jointMotor;
            yield return new WaitForSeconds(rotationTime[Random.Range(0, rotationTime.Length)]);
        }

    }

}
