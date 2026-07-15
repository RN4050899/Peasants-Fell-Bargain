using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code is the logic for the Combat player object
public class CombatPlayer : MonoBehaviour
{
	public GameObject Player;
	public CharacterStats Character;
	public string unitName;
	public int damage;
	public int strength;
	public int agility;
	public int maxHP;
	public int currentHP;
	public int armorClass;
	public bool vantage;

	// Is called right away by battle system
	public void SetupCP()
    {
		// Try and find the player object made in charecter creation
		try
		{
			Player = GameObject.Find("Player");
			Character = Player.GetComponent<CharacterStats>();
			strength = Character.PlayerStats["Strength"];
			agility = Character.PlayerStats["Agility"];
			maxHP = Character.PlayerStats["Max Heath"];
			currentHP = Character.PlayerStats["Current Heath"];
			armorClass = Character.PlayerStats["Armor Class"];
			vantage = Character.advantage;
			unitName = Character.playername;
			damage = 2;
		}
		// If the player object is not found the load these for testing
		catch
        {
			strength = 2;
			agility = 3;
			maxHP = 12;
			currentHP = 12;
			armorClass = 13;
			vantage = true;
			damage = 2;
		}
	}

	// Take in an intiger to represent damage and subtract it from the players HP
	public void TakeDamage(int dmg)
	{
		currentHP -= dmg;
	}

	public bool deadCheck()
	{
		if (currentHP <= 0)
			return true;
		else
			return false;
	}

	// Make the Player objects HP the same as the combat player's HP
	public void updatePlayerStats()
	{
		Character.PlayerStats["Current Heath"] = currentHP;
	}

}