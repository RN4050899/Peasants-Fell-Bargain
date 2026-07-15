using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This code is used to modify the player and enemy heath stats seen in combat

public class BattleHUD : MonoBehaviour
{
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI hpText;
	public Slider hpSlider;

	// Sets up the enemy units heath text and health bar at the start of combat
	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
		hpText.text = unit.currentHP + "/" + unit.maxHP;
	}

	// Sets up the player units heath text and health bar at the start of combat
	public void SetHUD(CombatPlayer combatPlayer)
	{
		nameText.text = combatPlayer.unitName;
		hpSlider.maxValue = combatPlayer.maxHP;
		hpSlider.value = combatPlayer.currentHP;
		hpText.text = combatPlayer.currentHP + "/" + combatPlayer.maxHP;
	}

	// Updates enemy units heath text and health bar
	public void SetHP(Unit unit)
	{
		hpSlider.value = unit.currentHP;
		hpText.text = unit.currentHP + "/" + unit.maxHP;
	}

	// Updates player units heath text and health bar
	public void SetHP(CombatPlayer combatPlayer)
	{
		hpSlider.value = combatPlayer.currentHP;
		hpText.text = combatPlayer.currentHP + "/" + combatPlayer.maxHP;
	}

}
