using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{

    [Header("Particles")]
    public ParticleSystem GunFlash;
    public GameObject GunImpact;
    
    private Transform target;
    public float range = 15f;

    public Transform PartToRotate;
    public string enemyTag = "Enemy";

    public float GunRange = 10;
    public float fireRate;
    [SerializeField]
    private float TimeToFire = 0f;
    public float turnSpeed = 10;
    public GameObject[] enemies;
    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; 
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); 
            if (distanceToEnemy < shortestDistance) 
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range && Time.time >= TimeToFire )
        {
            target = nearestEnemy.transform;
            TimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
        if (target == null)
            return;
        
            //Target Lock on
            Vector3 dir = target.position - transform.position;
            Quaternion lookRoatation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation, lookRoatation, Time.deltaTime * turnSpeed).eulerAngles;
            PartToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

           
    }

    void Shoot()
    {
        GunFlash.Play();
        RaycastHit HitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out HitInfo, GunRange) && Time.time >= TimeToFire)
        {
            GunFlash.Play();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * HitInfo.distance, Color.yellow);
            Debug.Log(HitInfo.transform.name);
           

            Kill killRef = HitInfo.transform.GetComponent<Kill>(); 
            if (killRef!= null)
            {
                killRef.TakeDamage(2);
            }
            
            GameObject Impact = Instantiate(GunImpact, HitInfo.point, Quaternion.LookRotation(HitInfo.normal));
           
            Destroy(Impact, .5f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

