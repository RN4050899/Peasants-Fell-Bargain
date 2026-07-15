using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This code represents a enemy combat unit

public class Unit : MonoBehaviour
{
	// Name we want the player to see
	public string unitName;
	// The max amount of random damage we want the unit to do (damage will be rolled from 1 to this number)
	public int damage;
	// The units to hit bonus
	public int toHit;
	// Max hit poinits of this charecter and current hit points
	public int maxHP;
	public int currentHP;
	// What the player needs to roll in order to land a hit
	public int armorClass;
	// Number of attacks that the unit gets per turn
	public int attacks;

	// Takes in an intereger damage, applys it, and checks if the unit has died
	public void TakeDamage(int dmg)
	{
		// Deal the damage
		currentHP -= dmg;
	}

	public bool deadCheck()
	{
		if (currentHP <= 0)
			return true;
		else
			return false;
	}

}
