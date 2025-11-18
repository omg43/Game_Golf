using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private float m_power;
    [SerializeField] private Transform m_point;
    [SerializeField] private float m_minAnlgeZ = -30;
    [SerializeField] private float m_maxAnlgeZ = 30;
    [SerializeField] [Min(0)] private float m_speed;

    private Vector3 m_direction;
    private Vector3 m_lastPointPosition;

    private bool m_isExecute;
    private void FixedUpdate()
    { 
        var angles = transform.localEulerAngles;
        if (m_isExecute)
        {
            angles.z = Rotate(angles.z,m_minAnlgeZ);
        }
        else {
            angles.z = Rotate(angles.z, m_maxAnlgeZ);
        }
        
        transform.localEulerAngles = angles;    
        
        m_direction = (m_point.position - m_lastPointPosition).normalized;
        m_lastPointPosition = m_point.position;

        m_isExecute = false;
    }

    public void Down() => m_isExecute = true;
    public void Up() => m_isExecute = false;

    private float Rotate(float angleZ, float target)
    {
        var x = Mathf.MoveTowardsAngle(angleZ, target, Time.deltaTime * m_speed);
        return x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Stone>(out var stone))
        {
            stone.AddForce(m_power * m_direction);
        }
    }
}
