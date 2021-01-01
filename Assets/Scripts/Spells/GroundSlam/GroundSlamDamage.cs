﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSlamDamage : MonoBehaviour
{
    [SerializeField] private Vector2 size = new Vector2(0, 0);
    [SerializeField] private float damage = 0;

    private PlayerJump playerJump;

    void Awake()
    {
        playerJump = GameObject.Find("Player").GetComponent<PlayerJump>();

    }

    void Update()
    {
        if (playerJump.GetIsGrounded())
        {
            
            Collider2D[] enemies = Physics2D.OverlapBoxAll((Vector2)transform.position, size, 0, 1 << LayerMask.NameToLayer("Enemy"));
            foreach (Collider2D enemy in enemies)
            {
                enemy.gameObject.GetComponent<IHealth>().TakeDamage(damage);
                enemy.gameObject.GetComponent<IStatusEffect>().BecomePoisoned();
                enemy.gameObject.GetComponent<IStatusEffect>().BecomeOiled();
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position, size);
    }
}