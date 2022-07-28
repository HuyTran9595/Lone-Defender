using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerWeapons : MonoBehaviour
{
    [Header("Gun Shot Distance")]
    public float GunRange;
    
    [Header("Reference To Player Camera")]
    public Camera PlayerCam;
    
    [Header("Particles")]
    public ParticleSystem GunFlash;
    public GameObject GunImpact;
    
    [Header("Gun Impact Force")]
    public float ForceImpact;
    
    [Header("Gun Fire Rate")]
    public float FireRate;
    
    [SerializeField]
    private float TimeToFire = 0f;

    [Header("Gun Ammo")] 
    public int AmmoAmount;

    public TextMeshProUGUI AmmoText;


    public PlayerController playerRef;
    
    // Update is called once per frame
    private void Awake()
    {
        AmmoText.text = AmmoAmount.ToString();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= TimeToFire && AmmoAmount >= 1 && playerRef.isPause == false)
        {
            AmmoAmount -= 1;
            AmmoText.text = AmmoAmount.ToString();
            TimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        AmmoText.text = AmmoAmount.ToString();
    }

    void Shoot()
    {
        
        
        GunFlash.Play();
        
        RaycastHit HitInfo;
        if (Physics.Raycast(PlayerCam.transform.position, PlayerCam.transform.forward, out HitInfo, GunRange))
        {
            Debug.Log(HitInfo.transform.name);

            Kill killRef = HitInfo.transform.GetComponent<Kill>(); 
            if (killRef!= null)
            {
                killRef.TakeDamage(2);
                HitInfo.rigidbody.AddForce(HitInfo.normal * ForceImpact);
            }
            
           GameObject Impact = Instantiate(GunImpact, HitInfo.point, Quaternion.LookRotation(HitInfo.normal));
           
           Destroy(Impact, .03f);
        }
    }
}
