using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 100f;
    public Text timer, health, state;
    private float timeCounter = 500f;
    private int healthCounter = 50;
    private bool isGame = true, isFinish = false;
    public GameObject panel;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (timeCounter <= 0)
        {
            isGame = false;
        }
        if (isGame && !isFinish)
        {
            timeCounter -= Time.deltaTime;
            timer.text = " " + (int)timeCounter;      
        }
        else if(!isFinish)
        {
            panel.SetActive(true);
            state.text = "Oyun tamamlanamadý";
        }
    }
    private void FixedUpdate()
    {
        if (isGame && !isFinish)
        {
            float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            Vector3 power = new Vector3(horizontal, 0f, vertical);
            rb.AddForce(power);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Finish")
        {
            isFinish = true;
            panel.SetActive(true);
            state.text = "Oyun tamamlandý";
           
        }
        else if (collision.gameObject.tag == "Wall")
        {
            healthCounter -= 1;
            health.text = " " + healthCounter;
            if (healthCounter <= 0) 
            {
                isFinish = true;
                isGame = false;
                panel.SetActive(true);
                state.text = "Oyun tamamlanamadý";
            }
        }
    }
}
