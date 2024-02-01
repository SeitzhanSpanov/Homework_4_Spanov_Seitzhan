using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    public event EventHandler<HealthEvent> OnHealthChanged;
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _moveTarget;
    [SerializeField] private float _health;

    public void SetDestination(Vector3 targetPosition)
    {
        _agent.SetDestination(targetPosition);
    }

    public void TakeDamage(float dmg)
    {
        _health -= dmg;
OnHealthChanged?.Invoke(this, new HealthEvent { Health = _health });
        if (_health <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }
   
}

public interface IEnemy
{
    void TakeDamage(float dmg);
}