using System;
using UnityEngine;
using Random = UnityEngine.Random;

/*

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private CharacterAnimation animationScript;


    private EnemyMovement enemyMovement;
    private bool characterDied;

    public bool isPlayer;

    private void Awake()
    {
        animationScript = GetComponentInChildren<CharacterAnimation>();
    }

    public void ApplyDamage(float damage, bool knockDown)
    {
        if (characterDied)
            return;
        
        health -= damage;

        if (health <= 0)
        {
            animationScript.Death();
            characterDied = true;
            
            if (isPlayer)
            {}

            return;
        }

        if (isPlayer == false)
        {
            if (knockDown)
            {
                if (Random.Range(0, 2) > 0)
                {
                    animationScript.KnockDown();                    
                }
                
            }

            else
            {
                if (Random.Range(0, 3) > 1)
                {
                    animationScript.Hit();                    
                }
                
            }
        }
    }
}
*/
