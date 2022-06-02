using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform target;
    float xPositionBound = 12;
    float zPositionBound = 11;
    public GameObject powerUpIndicator;
    Rigidbody rb;
    public float forwardSpeed;
    float verticalInput;
    private GameObject obj;
    float powerForce = 15;

    public  bool  isPoweredUp = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        obj = GameObject.Find("FocalPoint");
    }


    void Update()
    {

        if(transform.position.x<-xPositionBound || transform.position.x>xPositionBound||transform.position.z<-zPositionBound|| transform.position.z>zPositionBound ){

            float xPosition = Random.Range(-xPositionBound, xPositionBound);
            float zPosition = Random.Range(-zPositionBound, zPositionBound);            
                transform.position = new Vector3(xPosition,transform.position.y,zPosition);
        }
        verticalInput = Input.GetAxis("Vertical");

      rb.AddForce(obj.transform.forward * verticalInput * forwardSpeed);
        powerUpIndicator.transform.position = transform.position;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Power_Up"))
        {

            isPoweredUp = true;
            powerUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(StartPowerUp());
        
        }


    }

    IEnumerator StartPowerUp()
    {
        yield return new WaitForSeconds(7);
        isPoweredUp = false;
        powerUpIndicator.SetActive(false);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy" && isPoweredUp)
        {

          //  Debug.Log("Anika");
            Rigidbody rbEnemy = collision.collider.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.collider.transform.position - transform.position);
            rbEnemy.AddForce(awayFromPlayer * powerForce, ForceMode.Impulse);
                
                
        }
    }
}
