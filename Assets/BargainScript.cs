using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script applies the affects of taking the bargain or not takeing the bargain
public class BargainScript : MonoBehaviour
{
    public GameObject Player;
    public CharacterStats Character;

    //Called if the player says no to the bargain
    public void noBargain()
    {
        //Try and find the player object made in charecter creation
        try
        {
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            //Raise the players Max HP and Current HP by 2
            Character.PlayerStats["Max Heath"] += 2;
            Character.PlayerStats["Current Heath"] += 2;
            Character.bargain = 0;
        }
        //If it is not found then do nothing
        catch
        {

        }
    }

    public void yesBargain()
    {
        //Try and find the player object made in charecter creation
        try
        {
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            // Roll a "D20" to see what affect the player gets from the bargain
            int roll = Random.Range(1, 20);
            // 20 => player gets +3 Max HP and +3 to a random stat
            // Note: the Character.bargain stat is to keep track of what type of bargain the player got (not used now but helpfull if you need to take the bargain away in the feuture)
            if (roll == 20)
            {
                Character.PlayerStats["Max Heath"] += 3;
                Character.PlayerStats["Current Heath"] += 3;
                int choice = Random.Range(1, 3);
                if (choice == 1)
                {
                    Character.PlayerStats["Strength"] += 3;
                    Character.PlayerStats["Max Heath"] += 3;
                    Character.PlayerStats["Current Heath"] += 3;
                    Character.bargain = 14;
                }
                else if (choice == 2)
                {
                    Character.PlayerStats["Agility"] += 3;
                    Character.PlayerStats["Armor Class"] += 3;
                    Character.bargain = 13;
                }
                else
                {
                    Character.PlayerStats["Wisdom"] += 3;
                    Character.bargain = 12;
                }
            }
            // 19-16 => player gets +2 Max HP and +3 to a random stat
            else if (roll >= 16)
            {
                Character.PlayerStats["Max Heath"] += 2;
                Character.PlayerStats["Current Heath"] += 2;
                int choice = Random.Range(1, 3);
                if (choice == 1)
                {
                    Character.PlayerStats["Strength"] += 3;
                    Character.PlayerStats["Max Heath"] += 3;
                    Character.PlayerStats["Current Heath"] += 3;
                    Character.bargain = 11;
                }
                else if (choice == 2)
                {
                    Character.PlayerStats["Agility"] += 3;
                    Character.PlayerStats["Armor Class"] += 3;
                    Character.bargain = 10;
                }
                else
                {
                    Character.PlayerStats["Wisdom"] += 3;
                    Character.bargain = 9;
                }
            }
            // 15-13 => player gets +2 Max HP and +2 to a random stat
            else if (roll >= 13)
            {
                Character.PlayerStats["Max Heath"] += 2;
                Character.PlayerStats["Current Heath"] += 2;
                int choice = Random.Range(1, 3);
                if (choice == 1)
                {
                    Character.PlayerStats["Strength"] += 2;
                    Character.PlayerStats["Max Heath"] += 2;
                    Character.PlayerStats["Current Heath"] += 2;
                    Character.bargain = 8;
                }
                else if (choice == 2)
                {
                    Character.PlayerStats["Agility"] += 2;
                    Character.PlayerStats["Armor Class"] += 2;
                    Character.bargain = 7;
                }
                else
                {
                    Character.PlayerStats["Wisdom"] += 2;
                    Character.bargain = 6;
                }
            }
            // 12-8 => player gets +2 Max HP and +1 to a random stat
            else if (roll >= 8)
            {
                Character.PlayerStats["Max Heath"] += 2;
                Character.PlayerStats["Current Heath"] += 2;
                int choice = Random.Range(1, 3);
                if (choice == 1)
                {
                    Character.PlayerStats["Strength"] += 1;
                    Character.PlayerStats["Max Heath"] += 1;
                    Character.PlayerStats["Current Heath"] += 1;
                    Character.bargain = 5;
                }
                else if (choice == 2)
                {
                    Character.PlayerStats["Agility"] += 1;
                    Character.PlayerStats["Armor Class"] += 1;
                    Character.bargain = 4;
                }
                else
                {
                    Character.PlayerStats["Wisdom"] += 1;
                    Character.bargain = 3;
                }
            }
            // 7-6 => player gets +2 Max HP
            else if (roll >= 6)
            {
                Character.PlayerStats["Max Heath"] += 2;
                Character.PlayerStats["Current Heath"] += 2;
                Character.bargain = 2;
            }
            // 5-1 => player gets +1 Max HP
            else
            {
                Character.PlayerStats["Max Heath"] += 1;
                Character.PlayerStats["Current Heath"] += 1;
                Character.bargain = 1;
            }
        }
        // If player object is not found then do nothing
        catch
        {

        }
    }
}
