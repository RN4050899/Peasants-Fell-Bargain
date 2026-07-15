using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is used to control wether or not the player attacks first
public class vantage : MonoBehaviour
{
    public GameObject Player;
    public CharacterStats Character;

    // If we want them to attack first
    public void advantage()
    {
        // Try and find the player object made in charecter creation
        try
        { 
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            // Set player advantage to true
            Character.advantage = true;
        }
        // If the player object is not found do nothing
        catch
        {

        }
    }

    // If we want them to attack second
    public void disadvantage()
    {
        // Try and find the player object made in charecter creation
        try
        {
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            // Set player advantage to true
            Character.advantage = false;
        }
        // If the player object is not found do nothing
        catch
        {

        }
    }
}
