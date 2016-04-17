using UnityEngine;
using System.Collections;

public class PlayerControllerMobile : MonoBehaviour
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
       Touch();
    }

    void Touch()
    {
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            int pointerID = touch.fingerId;

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) //Release
            {
                Shoot();
            }

        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation	
    }

}
