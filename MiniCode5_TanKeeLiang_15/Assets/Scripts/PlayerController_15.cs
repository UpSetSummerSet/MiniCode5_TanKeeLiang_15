using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController_15 : MonoBehaviour
{
    float speed = 10.0f;
    float energyCount = 0;
    public int AECollected = 1;

    float zLimit = 24.72f;
    float xLimit = 24.4f;

    public Animator playerAnim;
    public GameObject ECounter;
    public GameObject GameManager1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ECounter.GetComponent<Text>().text = "Energy Counter: " + energyCount;

        if(GameManager1.GetComponent<GameManager>().levelTime > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                playerAnim.SetBool("IsRunning", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                playerAnim.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetBool("IsRunning", false);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                playerAnim.SetBool("IsRunning", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                transform.rotation = Quaternion.Euler(0, 90, 0);
                playerAnim.SetBool("IsRunning", true);
            }
            else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                playerAnim.SetBool("IsRunning", false);
            }
        }
        else if(GameManager1.GetComponent<GameManager>().levelTime == 0)
        {
            playerAnim.SetBool("IsRunning", false);
        }

        if (energyCount == 50)
        {
            SceneManager.LoadScene("WinScene");
        }
        else if (GameManager1.GetComponent<GameManager>().levelTime == 0 || energyCount < 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (transform.position.z < -zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        else if (transform.position.z > zLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        if (transform.position.x < -xLimit)
        {
            transform.position = new Vector3(-xLimit, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xLimit)
        {
            transform.position = new Vector3(xLimit, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("AddEnergy"))
        {
            energyCount += 5;
            Destroy(collision.gameObject);
            AECollected--;
        }
        else if (collision.gameObject.CompareTag("MinusEnergy"))
        {
            energyCount -= 25;
            Destroy(collision.gameObject);
        }
    }
}
