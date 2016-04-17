using UnityEngine;
using System.Collections;

public class PlayerControllerPC : MonoBehaviour
{
    //Components
    Animator rotateAnimator;

    //Handling
    public Transform rotateChild;

    //GameObject
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float bulletSpeed;


    void Start()
    {
        rotateAnimator = rotateChild.GetComponent<Animator>();
    }

    void Update()
    {
        Space();
    }

    void Space()
    {
        if (Input.GetButtonUp("Jump")) //Release SpaceBar
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation	
    }

}
