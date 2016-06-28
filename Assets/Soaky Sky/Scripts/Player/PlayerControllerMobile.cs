using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControllerMobile : MonoBehaviour
{
    //Components
    Animator rotateAnimator;

    //Handling
    public Transform rotateChild;
	public int bulletAmmo;
	public int totalBullet;

    //GameObject
    public GameObject bulletPrefab;
    public GameObject bulletSpawn;
    public float bulletSpeed;

    void Start()
    {
        rotateAnimator = rotateChild.GetComponent<Animator>();
		totalBullet = bulletAmmo;
    }

    void Update()
    {
       	//Touch();
		MousePosition ();

		if(bulletAmmo == 0)
		{
			Invoke("Reload", 1);   
		}
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

	void Reload()
	{
		bulletAmmo = totalBullet;
	}

	void MousePosition()
	{
		if (Input.GetMouseButton (0)) 
		{
			rotateChild.gameObject.SetActive(true);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rotateChild.rotation = Quaternion.LookRotation (Vector3.forward,transform.position - mousePos);
		}
		else if (Input.GetMouseButtonUp (0))  // cooldown check
		{
			Shoot ();
		}
	}

    void Shoot()
    {
		bulletAmmo--;
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation
        //Vector2 bulletVector = bullet.transform.rotation * Vector2.up;
        //Debug.Log("bulletVector "+bulletVector);
        
        //bullet.GetComponent<ricochet>().setDirection(bulletVector);
        //Debug.Log("bullet rotation to vector from player"+bulletVector);
        //Debug.Log("bullet position "+bullet.transform.position);
        
        
        rotateChild.gameObject.SetActive(false);
    }



}
