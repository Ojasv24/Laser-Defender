using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]

    [SerializeField] float health = 100;
    [SerializeField] int scorePoint = 150;
    

    [Header("Laser")]

    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 12f;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject particleExplosion;
    [SerializeField] float particleExplosionTime = 1f;
    float shotCounter;

    [Header("Sound Effect")]

    [SerializeField] AudioClip deathEffect;
    [SerializeField] AudioClip laserEffect;
    [SerializeField] [Range(0, 1)] float deathSoundVol = 0.75f;



    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
       
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(laserEffect, Camera.main.transform.position, 0.5f);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        Destroy(gameObject);
        FindObjectOfType<GameStatus>().AddToScore(scorePoint);
        AudioSource.PlayClipAtPoint(deathEffect, Camera.main.transform.position,deathSoundVol);
        GameObject particle = Instantiate(particleExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(particle, particleExplosionTime);
    }
}