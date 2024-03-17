using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timer;
    public float timeBetweenFiring;
    public float despawnDelay = 0.50f;
    float timeUntilMelee;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void UpdateWeaponCrosshair(Vector3 mousePos)
    {
        this.mousePos = mousePos;
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    public void UseWeapon()
    {
        if (canFire)
        {
            canFire = false;
            GameObject bulletInstance = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            Destroy(bulletInstance, despawnDelay);
        }
    }

    void Update()
    {
        // Shoot cooldown
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                timer = 0;
                canFire = true;
            }
        }
    }
}