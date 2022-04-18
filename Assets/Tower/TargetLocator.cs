using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    Transform target;

    [SerializeField]
    Transform weapon;

    [SerializeField]
    float range = 15f;

    [SerializeField]
    ParticleSystem projectileParticles;

    void Start()
    {
        target = FindObjectOfType<Enemy>().transform;
        weapon = gameObject.transform.GetChild(1);
    }

    void Update()
    {
        FindClosetTarget();
        AimWeapon();
    }

    void FindClosetTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance =
                Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance =
            Vector3.Distance(transform.position, target.position);

        weapon.LookAt (target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
