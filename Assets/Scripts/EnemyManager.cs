using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event Action OnStartNewWawe;

    public static EnemyManager Instance;

    [SerializeField] private EnemyFabric _fabric;
    [SerializeField] private int _waweIndex;
    [SerializeField] private int _enemyCount;
    [SerializeField] private Transform _destinationTarget;

    private bool _started = false;

    public List<Enemy> EnemyList = new List<Enemy>();
    public int Wawe { get { return _waweIndex; } set { _waweIndex = value; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(CreateWawe(_enemyCount));
    }

    private void OnEnable()
    {
        OnStartNewWawe += EnemyManagerOnStartNewWawe;
    }

    private void OnDisable()
    {
        OnStartNewWawe -= EnemyManagerOnStartNewWawe;
    }

    private void EnemyManagerOnStartNewWawe()
    {
        _started = true;
        StartCoroutine(CreateWawe(_enemyCount, 10));
    }

    private void LateUpdate()
    {
        if (EnemyList.Count > 0 && EnemyList.All(x => x.gameObject.activeSelf == false) && !_started)
        {
            OnStartNewWawe?.Invoke();
        }
    }

    private IEnumerator CreateWawe(int enemyCount, float waweDelay = 0)
    {
        _waweIndex++;

        yield return new WaitForSeconds(waweDelay);

        if (EnemyList.Count > 0)
        {
            foreach (Enemy enemy in EnemyList)
            {
                Destroy(enemy.gameObject);
            }
        }

        EnemyList = new List<Enemy>();

        for (int i = 0; i < enemyCount; i++)
        {
            var enemy = _fabric.SpawnEnemy(_waweIndex);
            enemy.SetDestination(_destinationTarget.position);
            EnemyList.Add(enemy);
            yield return new WaitForSeconds(0.3f);
        }

        _started = false;
    }
}