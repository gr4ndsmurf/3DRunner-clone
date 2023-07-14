using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public int maxScore;

    public TextMeshProUGUI coinText;
    public PlayerController playerController;

    public Animator playerAnim;
    public GameObject player;

    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            AddCoin();
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            playerController.xSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            if (score >= maxScore)
            {
                playerAnim.SetBool("win", true);
            }
            else
            {
                playerAnim.SetBool("lose", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collision"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
