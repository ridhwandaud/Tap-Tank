using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerMousePosition : MonoBehaviour
{
    //Components
    Animator rotateAnimator;

    //Handling
    public Transform rotateChild;

    //GameObject
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float bulletSpeed;
    public int bulletAmmo;
    public int totalBullet;
    public Text text;


    void Start()
    {
        rotateAnimator = rotateChild.GetComponent<Animator>();
        totalBullet = bulletAmmo;
        text.text = bulletAmmo + "/" + totalBullet;
    }

    void Update()
    {
        MousePosition();

        if(bulletAmmo == 0)
        {
            Invoke("Reload", 1);   
        }
    }

    void Reload()
    {
        bulletAmmo = totalBullet;
        text.text = bulletAmmo + "/" + totalBullet;
    }

    void MousePosition()
    {
     
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotateChild.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        if (Input.GetMouseButtonUp(0))
        {
            if(bulletAmmo > 0)
            {
                Shoot();
            }
            
        }
    }

    void Shoot()
    {
        bulletAmmo--;
        text.text = bulletAmmo + "/" + totalBullet;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation
        	
    }

    
}
