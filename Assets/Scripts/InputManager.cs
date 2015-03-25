using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    float RotationDeltaRate = 90;        
    private float pitch = 60;
    private float yaw = 0;
    private Quaternion orientation;
       
    void Update()
    {
        float move_x = Input.GetAxis("HorizontalMove");
        float move_y = Input.GetAxis("VerticalMove");
        float move_z = Input.GetAxis("ForwardMove");

        pitch += Input.GetAxis("Vertical") * Time.deltaTime * RotationDeltaRate;
        yaw -= Input.GetAxis("Horizontal") * Time.deltaTime * RotationDeltaRate;
                
        transform.Translate(Vector3.up * move_y + Vector3.right * move_x, Space.World);
        
        // Change to Space.Self to support forward movement to forward vector
        transform.Translate(Vector3.forward * move_z, Space.World);  

        orientation.eulerAngles = new Vector3(LimitAngles(pitch), LimitAngles(yaw), 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, orientation, Time.time);     
    }

    float LimitAngles(float angle)
    {
        float result = angle;

        while (result > 360)
            result -= 360;

        while (result < 0)
            result += 360;

        return result;
    }
}
