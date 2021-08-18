using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;

    public float fireRate = 0.2f;
    float nextFire = 0.0f;
    public bool canShoot = true;


    void Update()
    {
        Fire();

        if (CrossPlatformInputManager.GetButton("Fire2"))
            Reload();

        if (CrossPlatformInputManager.GetButtonUp("Fire1") && canShoot)
        {
            animator.SetBool("Shoot", false);
            animator.SetBool("ShootWalk", false);
            nextFire = 0.0f;
        }
    }

   void Fire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (StaticDataManager.bullets <= 0)
                canShoot = false;

            if (canShoot)
            {
                AudioManager.instance.Play("BulletShoot");
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && canShoot)
        {
            StaticDataManager.bullets -= 1;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.SetBool("Shoot", true);
        }
    }

    void Reload()
    {
        FindObjectOfType<AudioManager>().Play("Reload");
        canShoot = true;
        StaticDataManager.bullets = 60;
    }
}
