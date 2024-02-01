using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Zombie,
    Dragon,
    Bear
}

[CreateAssetMenu(fileName = "EnemyData", menuName = "TD/CreateEnemys")]
public class EnemyFabric : ScriptableObject
{
    public List<EnemyHolder> Enemies = new List<EnemyHolder>();

    public T CreateEnemy<T>(EnemyType enemy) where T : Enemy
    {
        var enemyFabric = Enemies.Find(x => x.EnemyType == enemy);

        if (enemyFabric != null)
        {
            return Instantiate(enemyFabric.Enemy) as T;
        }

        return default;
    }

    public Enemy SpawnEnemy(int index)
    {
        return Instantiate(Enemies[index].Enemy);
    }
}

[Serializable]
public class EnemyHolder
{
    public Enemy Enemy;
    public EnemyType EnemyType;
}