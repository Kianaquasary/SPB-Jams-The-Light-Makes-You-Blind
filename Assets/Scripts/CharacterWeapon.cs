using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ParticleSystemData
{
    public GameObject prefab; // Particle system prefab
    public float fireRate; // Fire rate in seconds
    public AudioClip soundEffect; // Sound effect for the particle system
}

public class CharacterWeapon : MonoBehaviour
{
    public ParticleSystemData[] particleSystems; // Array of particle system data
    public Transform firePoint; // Fire point GameObject attached to the character
    public AudioSource audioSource; // Reference to the AudioSource component

    private float[] nextFireTimes; // Next time each particle system can fire

    private int currentPrefabIndex = 0; // Current index for particle system selection

    // Start is called before the first frame update
    void Start()
    {
        nextFireTimes = new float[particleSystems.Length];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentPrefabIndex = 0;
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            currentPrefabIndex = 1;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            currentPrefabIndex = 2;
        }

        if (Input.GetButton("Fire1"))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        float currentFireRate = particleSystems[currentPrefabIndex].fireRate;
        if (Time.time >= nextFireTimes[currentPrefabIndex])
        {
            nextFireTimes[currentPrefabIndex] = Time.time + 1f / currentFireRate;
            GameObject bullet = Instantiate(particleSystems[currentPrefabIndex].prefab, firePoint.position, firePoint.rotation);
            // Apply any modifications or settings to the bullet particle system

            // Play bullet's particle system
            bullet.GetComponent<ParticleSystem>().Play();

            // Play the sound effect
            audioSource.PlayOneShot(particleSystems[currentPrefabIndex].soundEffect);
        }
    }
}


