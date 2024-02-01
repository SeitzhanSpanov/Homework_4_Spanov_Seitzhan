using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public Enemy enemy;
    private void Start()
    {
        enemy.OnHealthChanged += EnemyOnHealthChanged;
    }
    private void EnemyOnHealthChanged(object sender, HealthEvent e)
    {
        Debug.Log("Health changed to" + e.Health + " " + sender);

       

    }
}
