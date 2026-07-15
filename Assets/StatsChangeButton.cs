using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


// This code contains the functionsq that are called when the player uses the buttons on the charecter creation page.
public class StatsChangeButton : MonoBehaviour
{
    // Name of the stat that we wanna edit
    public string stat;
    // The charecter that we wanna edit
    public CharacterStats character;
    // The number that the user with see change for that stat
    public TextMeshProUGUI statDisplay;
    // The text for the point pool that will also change
    public TextMeshProUGUI pointPoolDisplay;
    // The text for the description of the stat
    public TextMeshProUGUI description;

    // Adding to a stat
    public void Add() 
    {
        // Checking that the the stat is greater then 0 and there are still ponits left in the point pool
        if (character.PlayerStats[stat] < 3 && character.PlayerStats["Point Pool"] > 0)
        {
            // Add to the stat
            character.PlayerStats[stat] += 1;
            // Subtract from the point pool
            character.PlayerStats["Point Pool"] -= 1;
            // Update the text for the stat and the point pool
            statDisplay.text = character.PlayerStats[stat].ToString();
            pointPoolDisplay.text = character.PlayerStats["Point Pool"].ToString();
        }
    }

    public void Subtract()
    {
        // Checking that the the stat is greater then 0 and there are less than 5 points in the point pool
        if (character.PlayerStats[stat] > 0 && character.PlayerStats["Point Pool"] < 5)
        {
            // Subtract from the stat
            character.PlayerStats[stat] -= 1;
            // Add to the point pool
            character.PlayerStats["Point Pool"] += 1;
            // Update the text for the stat and the point pool
            statDisplay.text = character.PlayerStats[stat].ToString();
            pointPoolDisplay.text = character.PlayerStats["Point Pool"].ToString();
        }
    }

    // Called when cursor hovers over button to show a discription (show tool tip)
    public void showDescription()
    {
        if (stat == "Strength")
        {
            description.text = "Strength: This is how tough you are. Strength helps you take more damage and deal out more damage with a melee attack";
        }
        else if (stat == "Agility")
        {
            description.text = "Agility: Being fast and light on your feet means you are harder to hit on the battlefield. it also helps when attacking at range.";
        }
        else if (stat == "Wisdom")
        {
            description.text = "Wisdom: Being wise may not help in combat but is can help you notice things that others might miss.";
        }
    }

    // Called when cursor stops hovering over button to hide the discription (hide tool tip)
    public void hideDescription()
    {
        description.text = " ";
    }
}
