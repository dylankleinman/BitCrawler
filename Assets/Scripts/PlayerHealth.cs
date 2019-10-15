using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int PlayerHealthPoints = 10;
    [SerializeField] Text healthText;

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
        }
    }
}
