
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;//numer obecnego waypointa

    //Ustawienie wroga ma pozyci startowej
    private void Start()
    {
        target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;//wyznaczenie kierunku poruszania sie
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);//dzieki Time.deltaTime poruszanie sie nie bedzie zalezec od frameratu

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)//jezeli odpowiednio blisko waypointu zmienamy nasz target na nastepny waypoint
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= Waypoints.points.Length -1)//zeby nie wyleciec poza tablice
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
}
