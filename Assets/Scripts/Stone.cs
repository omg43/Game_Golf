using System;
using UnityEngine;
using System.Collections.Generic;


[RequireComponent(typeof(Rigidbody))]
public class Stone : MonoBehaviour
{
    public event Action<Stone> Hit;
    public event Action<Stone> Missed;

    private Rigidbody m_rb;

    [SerializeField] private Stone[] m_data;
    private Stone m_curretData;

    private void Awake()
    {
        m_rb = GetComponent<Rigidbody>();
        //m_curretData = m_data[UnityEngine.Random.Range()];
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stick>())
        {
            Hit?.Invoke(this);
        }
        else
        {
            Missed?.Invoke(this);
        }
    }

    public virtual void OnHit()
    {

    }
    public virtual void OnMissed()
    {

    }

    public void AddForce(Vector3 force)
    {
        m_rb.AddForce(force, ForceMode.Force);
    }
}
