using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    public TMP_Text coinText, lastText, timeText;
    private int totalCoin = 0;
    private float time;
    public GameObject panel1, panel2;
    void Start()
    {
        animator = GetComponent<Animator>();
        Time.timeScale = 1f;
        time = 60f;
    }
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + (int)time;
        }
        else
        {
            panel2.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            lastText.text = "Total Coin: " + totalCoin.ToString();
        }
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector3(0, 0, 3f) * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.R))
        {
            animator.SetBool("isRunning", true);
            transform.Translate(new Vector3(0, 0, 7f) * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            totalCoin++;
            Destroy(other.gameObject);
            coinText.text ="Total coin: " + totalCoin.ToString();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            totalCoin--;
            Destroy(other.gameObject);
            coinText.text = "Total coin: " + totalCoin.ToString();
        }
        else if (other.gameObject.tag == "Finish") 
        {
            panel1.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            lastText.text = "Total Coin: " + totalCoin.ToString();
        }
    }
}