using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
	//public GameObject bolt;
	public float speed;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

	void OnTriggerEnter(Collider other)
	{ 
		 if (other.CompareTag ("Pickup") || other.CompareTag("Enemy"))
		 {
			 Destruction();
		 }
	}

	void Destruction()
	{
		Destroy(this.gameObject);
	}
}