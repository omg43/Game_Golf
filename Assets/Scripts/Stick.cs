using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private float m_minAnlgeZ = -30;
    [SerializeField] private float m_maxAnlgeZ = 30;
    [SerializeField] [Min(0)] private float m_speed;
    private void Update()
    { 
        var angles = transform.localEulerAngles;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angles.z = Rotate(angles.z,m_minAnlgeZ);
        }
        else {
            angles.z = Rotate(angles.z, m_maxAnlgeZ);
        }
        transform.localEulerAngles = angles;    
    }
    private float Rotate(float angleZ, float target)
    {
        var x = Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        return x;
    }
}
