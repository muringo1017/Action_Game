using System;
using UnityEngine;

/*
public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damaged = 2f;

    public bool isPlayer, isEnemy;

    public GameObject hitFx;

    private void Update()
    {
        DectectCollision();
    }

    void DectectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);

        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                Vector3 hitFxPos = hit[0].transform.position;
                hitFxPos.y += 1.3f;

                if (hit[0].transform.forward.x > 0)
                {
                    hitFxPos.x += 0.3f;
                }
                
                else hitFxPos.x -= 0.3f;

                Instantiate(hitFx,  hitFxPos, Quaternion.identity);

                if (gameObject.CompareTag(Tags.LEFT_ARM_TAG)||gameObject.CompareTag(Tags.RIGHT_ARM_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damaged, true);
                }

                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damaged, false);
                }
            }
            
            gameObject.SetActive(false);
        }
    }
}
*/