using System.Collections;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
   
    public float speed;
    public float tilt;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    
    private float nextFire;
    private Rigidbody rb;
    private AudioSource audio;

   // private bool isActive = false;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        
       if (Input.GetButton("Fire1") && Time.time > nextFire) //Fire1 = ctrl key
       {
           nextFire = Time.time + fireRate;
           //GameObjct clone = 
           Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //as GameObject
           audio.Play();

       }


    }

    void FixedUpdate()
    {

       float moveHorizontal = Input.GetAxis("Horizontal");
       float moveVertical = Input.GetAxis("Vertical");

       Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
       rb.velocity = movement * speed;

       rb.position = new Vector3
       (
           Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
           0.0f,
           Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
       );

       rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);

       
    }

    


    //void OnTriggerEnter(Collider other)
    // {
    // if (other.gameObject.CompareTag ("Pickup") && isActive == false)
    // {
    //   isActive = true;
    //   fireRate = fireRate/2;
    // Instantiate(explosion, other.transform.position, other.transform.rotation);
    //    Destroy(other.gameObject);
    // }
    //   }

}