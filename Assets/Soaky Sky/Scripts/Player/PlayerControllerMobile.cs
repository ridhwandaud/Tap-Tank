using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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

	private int pointerID = -1;

    void Start()
    {
		if (Application.isMobilePlatform) {
			pointerID = 0; //for mobile and unity
		}
        rotateAnimator = rotateChild.GetComponent<Animator>();
		totalBullet = bulletAmmo;
    }

    void Update()
    {
		MousePosition ();
    }
		

	void MousePosition()
	{
		if (Input.GetMouseButton (0) && Time.timeScale != 0) 
		{
			//For Block click through UI 
			if(EventSystem.current.IsPointerOverGameObject(pointerID)){
				return; //Not Shoot
			}
			rotateChild.gameObject.SetActive(true);
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			rotateChild.rotation = Quaternion.LookRotation (Vector3.forward,transform.position - mousePos);
		}
		else if (Input.GetMouseButtonUp (0))  // cooldown check
		{
			//For Block click through UI 
			if(EventSystem.current.IsPointerOverGameObject(pointerID)){
				return; //Not Shoot
			}
			Shoot ();
		}
	}

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.transform.position, Quaternion.identity);
        bullet.transform.rotation = rotateChild.rotation;// this is to follow rotating child 
        bullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed); //to add force according to rotation
        rotateChild.gameObject.SetActive(false);
    }



}
