using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class BasicEnemyAI : MonoBehaviour
{
    //Reference to self
    [Header("Self")]
    public Transform getSelf;
    
    //Reference to NavMeshAgent component
    [Header("Nav Agent")]
    public NavMeshAgent agent;

    //Reference to player character 
    [Header("Player Character")]
    public Transform player;
    
    //Reference to the base core
    [Header("Base Core")]
    public Transform RefToBase;

    //Layers are used for AI to understand what they are tracking
    [Header("LayerMask To Set")]
    public LayerMask Ground, Player, Base;

    //Attacking
    [Header("Attack Rate")]
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    //States
    [Header("Enemy attack range and sight")]
    public float sightRange, attackRange;
    [Header("Check attack range and Enemy Sight")]
    public bool playerInSight, playerAttackRange, baseInsight, baseAttackRange;

    //Range of enemy explosion damage (Raycast distance)
   [ Header("Raycast explosion Range")]
    public float ExplosionRange;

    //Reference to particle system 
   [ Header("Explosion Particle System")]
    public ParticleSystem ExplodeEnemy;

    
    public W_Manager WaveRef;
    
    // Start is called before the first frame update
    private void Awake()
    {
        WaveRef = GameObject.Find("WaveManager").GetComponent<W_Manager>();
        
        player = GameObject.Find("First Person Player").transform; //Attach player to script in inspector (change later)
        
        RefToBase = GameObject.Find("BaseCore").transform; // Attach BaseCore to script in inspector (change later)
        
        // baseRef = GameObject.Find("Base Core").transform;

        agent = GetComponent<NavMeshAgent>(); //Reference to component

        getSelf = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, Player); // Check for player sight
        playerAttackRange = Physics.CheckSphere(transform.position, attackRange, Player); // Check for player attack range
        baseInsight = Physics.CheckSphere(transform.position, sightRange, Base); // Check for base sight
        baseAttackRange = Physics.CheckSphere(transform.position, attackRange, Base); // Check for base attack range
        
        if (playerInSight && baseInsight && !playerAttackRange) ChasePlayer(); // Chase the player
        if (playerAttackRange && playerInSight) AttackPlayer(); //Attack the player
        if (!playerInSight && !baseAttackRange ) ChaseBase(); // if player not in sight chase base 
        if (baseInsight && !playerInSight && baseAttackRange) AttackBase(); // if player not in sight and in base rannge, attack the base
        
        

    }



    private void ChasePlayer()
    {
        agent.SetDestination(player.position); //Chase the player

    }

    private void ChaseBase()
    {
        agent.SetDestination(RefToBase.position); // chase the  base
    }

    private void AttackBase() //attack the base
    {
        agent.SetDestination(RefToBase.position);
        transform.LookAt(RefToBase);

        if (alreadyAttacked) return;
        RaycastHit baseInfo;

        if (!Physics.Raycast(getSelf.transform.position, getSelf.transform.forward, out baseInfo,
            ExplosionRange)) return;
        Debug.Log(baseInfo.transform.name);
        BaseCore baseRef = baseInfo.transform.GetComponent<BaseCore>();
            
        if (baseRef != null)
        {
            baseRef.BaseHealthBar.value -= 10;
        }
            
        ExplodeEnemy.Play();
        WaveRef.KillEnemy();
        Destroy(this.gameObject, 0.3f);

        alreadyAttacked = true;
    }

    private void AttackPlayer() //attack the player
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);

        if (alreadyAttacked) return;
        RaycastHit HitInfo;
        if (!Physics.Raycast(getSelf.transform.position, getSelf.transform.forward, out HitInfo,
            ExplosionRange)) return;
        Debug.Log(HitInfo.transform.name);

        PlayerController killRef = HitInfo.transform.GetComponent<PlayerController>();
        if (killRef is null) return;
        {
            killRef.PlayerHealthBar.value -= 10;
            Debug.Log(killRef.PlayerHealthBar.value);
            //HitInfo.rigidbody.AddForce(HitInfo.normal * ForceImpact);
        }



        ExplodeEnemy.Play();
        WaveRef.KillEnemy();
        Destroy(this.gameObject, 0.3f);

        alreadyAttacked = true;
    }

}
    