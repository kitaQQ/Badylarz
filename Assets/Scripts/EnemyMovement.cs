using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform target;
    private int wavepointIndex = 0;//numer obecnego waypointa

    private Enemy enemy;

    //Ustawienie wroga ma pozyci startowej
    private void Start()
    {
        enemy = GetComponent<Enemy>(); 
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;//wyznaczenie kierunku poruszania sie
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);//dzieki Time.deltaTime poruszanie sie nie bedzie zalezec od frameratu

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)//jezeli odpowiednio blisko waypointu zmienamy nasz target na nastepny waypoint
        {
            GetNextWaypoint();
        }

        //Gdy przeciwnik jest blisko kazdy przeciwnik dostaje obrazenia obrazenia DOT ale bardzo male i sa spowalniani
        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
        if (Vector3.Distance(transform.position, player.transform.position) <= 4f)
        {
            enemy.speed = 1f;
            enemy.startSpeed = 1f;
            enemy.TakeDamage(PlayerStats.aoeDamage * Time.deltaTime);

            if (Vector3.Distance(transform.position, player.transform.position) >= 2.5f)
            {
                Debug.Log("Leaving");
                enemy.speed = enemy.speedBeforeStop;
                enemy.startSpeed = enemy.speedBeforeStop;
            }
        }

        //Atakowanie okreslonego przeciwnika obrazenia DOT
        if(enemy.hasInteract)
        {
            enemy.speed = 0f;
            enemy.startSpeed = 0f;
            enemy.TakeDamage(PlayerStats.directDamage * Time.deltaTime);
            PlayerStats.heroHealth -= enemy.atackPower * Time.deltaTime;

            if(Vector3.Distance(transform.position, player.transform.position) >= 2.5f)
            {
                Debug.Log("Leaving");
                enemy.speed = enemy.speedBeforeStop;
                enemy.startSpeed = enemy.speedBeforeStop;
                enemy.hasInteract = false;
            }
        }
        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)//zeby nie wyleciec poza tablice
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
