using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class RangedEnemyAI : MonoBehaviour
{
    public float lookRadius = 10f;

    public float GunRange = 10;
    private Transform target;
    private Transform BaseTarget;
    
    private NavMeshAgent agent;
    
    [Header("Gun Fire Rate")]
    public float FireRate;
    
    [Header("Particles")]
    public ParticleSystem GunFlash;
    public GameObject GunImpact;
    
    [SerializeField]
    private float TimeToFire = 0f;

    //public GameObject Weapon;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;

    public PlayerController playerRef;
    
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.Player.transform;
        BaseTarget = BaseManager.instance.Base.transform;
        
        playerRef = FindObjectOfType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        float distance = Vector3.Distance(target.position, transform.position);
        float dist = Vector3.Distance(BaseTarget.position, transform.position);
        
     
        
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                // playerRef.PlayerHealthBar.value -= 3;
                FaceTarget();
            } 
        } else  if (distance >= lookRadius)
        {
            agent.SetDestination(BaseTarget.position);
            
            if (distance >= agent.stoppingDistance && dist <= lookRadius)
            {
                    
                //playerRef.PlayerHealthBar.value -= 3;
                FaceBase();
            }
        }
        
        
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        
        RaycastHit HitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out HitInfo, GunRange) && Time.time >= TimeToFire)
        {
            GunFlash.Play();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * HitInfo.distance, Color.yellow);
            TimeToFire = Time.time + 1f / FireRate;
           // Debug.Log(HitInfo.transform.name);
            PlayerController playerRef = HitInfo.transform.GetComponent<PlayerController>(); 
            if (playerRef != null)
            {
                playerRef.PlayerHealthBar.value -= 10;
                //Debug.Log(playerRef.PlayerHealthBar.value);

            }
            GameObject Impact = Instantiate(GunImpact, HitInfo.point, Quaternion.LookRotation(HitInfo.normal));
           
            Destroy(Impact, .03f);
        }
    }

    void FaceBase()
    {
        Vector3 direction = (BaseTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        
        RaycastHit HitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out HitInfo, GunRange) && Time.time >= TimeToFire)
        {
            GunFlash.Play();
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * HitInfo.distance, Color.yellow);
            TimeToFire = Time.time + 1f / FireRate;
          //  Debug.Log(HitInfo.transform.name);
            
            PlayerController playerRef = HitInfo.transform.GetComponent<PlayerController>(); 
            if (playerRef != null)
            {
                playerRef.PlayerHealthBar.value -= 10;
                Debug.Log(playerRef.PlayerHealthBar.value);

            }
            
            GameObject Impact = Instantiate(GunImpact, HitInfo.point, Quaternion.LookRotation(HitInfo.normal));
           
            Destroy(Impact, .03f);
        }
    }

    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPostion = Vector3.zero;
        ;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPostion = hit.position;
        }

        return finalPostion;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Damage the player");
        }
    }
}
   