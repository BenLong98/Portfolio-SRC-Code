﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public int scoreValue = 10;
    public AudioClip deathClip;


    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;


    void Awake ()
    {
        anim = GetComponentInChildren <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        hitParticles = GetComponentInChildren <ParticleSystem> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();

        currentHealth = startingHealth;
    }


    void Update ()
	{
    }


    public void TakeDamage (int amount, Vector3 hitPoint)
	{
		if (isDead)
			return;


			enemyAudio.Play ();

			currentHealth -= amount;
            
			hitParticles.transform.position = hitPoint;
			hitParticles.Play ();

			if (currentHealth <= 0) {
				Death ();
			}

	}


    void Death ()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger ("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play ();
		Destroy (gameObject, 2f);
		ScoreManager.score += scoreValue;
    }


 
}
