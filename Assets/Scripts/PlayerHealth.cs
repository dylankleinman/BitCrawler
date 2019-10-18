using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int PlayerHealthPoints = 10;
    [SerializeField] Text healthText;
    [SerializeField] Button button;
    public bool isPlaying = true;

    private void Start()
    {
        healthText.text = "Health: " + PlayerHealthPoints.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            PlayerHealthPoints--;
            healthText.text = "Health: " + PlayerHealthPoints.ToString();
            if (PlayerHealthPoints == 0)
            {
                StopGame();
            }

        }
    }

    public void StopGame()
    {
        isPlaying = false;
        DisplayRestartButton();
        RemoveTowers();
        StopEnemies();
    }

    private static void StopEnemies()
    {
        EnemyMovement[] enemies = FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement enemy in enemies)
        {
            enemy.GetComponent<EnemyMovement>().movementPerFrame = 0;
        }
    }

    private static void RemoveTowers()
    {
        Tower[] towers = FindObjectsOfType<Tower>();
        foreach (Tower tower in towers)
        {
            Destroy(tower.gameObject);
        }
    }

    private void DisplayRestartButton()
    {
        button.gameObject.SetActive(true);
        button.onClick.AddListener(ReLoadScene);
    }

    public void ReLoadScene()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            waypoint.GetComponent<Waypoint>().isPlaceable = false;
        }
        SceneManager.LoadScene("SampleScene");
    }
}
