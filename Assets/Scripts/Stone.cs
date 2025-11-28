using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using Assets.Scripts.Data;


[RequireComponent(typeof(Rigidbody))]
public class Stone : MonoBehaviour
{
    public event Action Hit;
    public event Action Missed;

    public event Action<Stone> AddScore;
    public event Action<Stone> RemoveHp;

    private Rigidbody m_rb;

    public Projectile projectile;

    public LevelController levelController;

    public int score { get; private set; } = 1;

    private void Awake()
    {
        projectile.stone = this;
        m_rb = GetComponent<Rigidbody>();
        projectile.OnProjectileInitialize();
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stick>())
        {
            Hit?.Invoke();
        }
        else
        {
            Missed?.Invoke();
        }
    }

    public void OnAddScore(int _score)
    {
        score = _score;
        AddScore?.Invoke(this);
    }
    public void OnRemoveHp()
    {
        RemoveHp?.Invoke(this);
    }

    public void AddForce(Vector3 force)
    {
        m_rb.AddForce(force, ForceMode.Force);
    }
}
