using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public int highScore;

    public float fireRate = 0.2f;
    float nextFire = 0.0f;
    public int bullets = 60;
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

        if (highScore > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

   void Fire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (bullets <= 0)
            {
                canShoot = false;
            }
            if (canShoot)
            {
                FindObjectOfType<AudioManager>().Play("BulletShoot");
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && canShoot)
        {
            bullets -= 1;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.SetBool("Shoot", true);
        }
    }

    void Reload()
    {
        FindObjectOfType<AudioManager>().Play("Reload");
        canShoot = true;
        bullets = 60;
    }
}
