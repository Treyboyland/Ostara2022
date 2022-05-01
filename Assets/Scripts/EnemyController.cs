using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    List<Enemy> enemies;

    [SerializeField]
    HomeBase homeBase;

    private void Awake()
    {
        DisableEnemies();
        homeBase.OnActivateEnemy.AddListener(ActivateEnemies);
        homeBase.OnBaseReached.AddListener(DisableEnemies);
    }

    void DisableEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    void ActivateEnemies()
    {
        foreach (var enemy in enemies)
        {
            enemy.transform.position = homeBase.SpawnLocation;
            enemy.gameObject.SetActive(true);
        }
    }

}
