﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : LivingEntity {

    // Audio
    public AudioClip deathClip;
    public AudioClip hitClip;
    public AudioClip itemPickUpClip;

    private AudioSource playerAudioPlayer;

    private PlayerMovement playerMovement;
    private PlayerShooter playerShooter;
    private PlayerInput playerInput;

    private void Awake() {

        playerMovement = GetComponent<PlayerMovement>();
        playerShooter = GetComponent<PlayerShooter>();
        playerInput = GetComponent<PlayerInput>();

    }

    protected override void OnEnable() {
        base.OnEnable();
        UIManager.instance.UpdateHealthText((int) startingHealth);
    }

    public override void OnDamage(float damage) {
        base.OnDamage(damage);
        UIManager.instance.UpdateHealthText((int) health);

        if (health <= 0 && !dead) {
            Die();
        }
         
    }

    public override void RestoreHealth(float newHealth) {
        base.RestoreHealth(newHealth);

        UIManager.instance.UpdateHealthText((int) health);

    }

    public override void Die() {
        playerMovement.enabled = false;
        playerShooter.enabled = false;
        playerInput.enabled = false;
        base.Die();
    }

    
}
