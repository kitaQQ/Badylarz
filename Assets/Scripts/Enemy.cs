
using UnityEngine;

public class Enemy : Interactable {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;

    public float health = 100;

    public int worth = 50;

    public GameObject deathEffect;

    public bool hasInteract;

    public float speedBeforeStop;

    public float atackPower = 1f;

    private void Start()
    {
        speed = startSpeed;
        speedBeforeStop = speed;
        hasInteract = false;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct); 
    }

    void Die()
    {
        PlayerStats.Money += worth;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        Destroy(gameObject);
    }

    public override void Interact()
    {
        speedBeforeStop = speed;
        hasInteract = true;
        Debug.Log("Interacting with ennemy");
    }

    //private void Update()
    //{
    //    if (hasInteract)
    //    {
    //        GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
    //        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    //        if (distanceToPlayer > 2f)
    //        {
    //            startSpeed = 10f;
    //            speed = 10f;
    //            hasInteract = false;
    //        }
    //    }
    //}


}
