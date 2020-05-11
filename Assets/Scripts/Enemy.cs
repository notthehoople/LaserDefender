using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Configuration Parameters
    [Header ("Enemy Stats")] 
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [Header("Shooting")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject enemyLaserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [Header ("Enemy Effects")]
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip enemyFireSound;
    [SerializeField] [Range(0, 1)] float shootSoundVolume = 0.7f;
    [SerializeField] AudioClip enemyDeathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = 0.7f;

    // Cached component references
    AudioSource enemyAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        enemyAudioSource = GetComponent<AudioSource>();
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
            shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity) as GameObject;
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(enemyFireSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D whatHitUs)
    {
        DamageDealer damageDealer = whatHitUs.gameObject.GetComponent<DamageDealer>();
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
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
