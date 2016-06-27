using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float Speed;

	void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, -1*Time.deltaTime*Speed, 0));
    }   
}
