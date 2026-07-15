using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// This code handels the logic for combat

// Here are some notes to help it make more sense 
//// Combat workes like a state machine with the states listed in the BattleState enum
//// The IEnumerator are coroutines that these states call
//// Note: the main reason that IEnumerator are used are so the WaitForSeconds() function can be called 

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
	// These are the sprites the represent the combatants
	public GameObject playerPrefab;
	public GameObject enemyPrefab;

	// These are the "platfroms that the combatans stand on (not currently visable)
	public Transform playerBattleStation;
	public Transform enemyBattleStation;

	// These are the combatants (Where stats are saved)
	CombatPlayer playerUnit;
	Unit enemyUnit;

	// Dialogue text that is changed to explain to the player what is happening
	public TextMeshProUGUI dialogueText;

	// The box's showing the compatants heath
	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;

	// Current state the battle is in
	public BattleState state;

	// A bool that tracks if either side has died
	public bool PlayerisDead;
	public bool EnemyisDead;

	// A bool that trakes if the player has attaked this turn (used to fix the bug where plyers could spam attack)
	public bool playerAttacked;

	// The sceen the player will go to if they win
	public int sceneIfWin;

	// Start is called before the first frame update
	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
		playerAttacked = true;
	}

	// Runs first to set up combat
	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
		playerUnit = playerGO.GetComponent<CombatPlayer>();
		playerUnit.SetupCP();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
		enemyUnit = enemyGO.GetComponent<Unit>();

		dialogueText.text = "A " + enemyUnit.unitName + " approaches...";

		// Updates health for both units
		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);

		// Waiting so the player can read the text
		yield return new WaitForSeconds(2f);

		// Decideing who attacks first depending on if the player has advantage or not 
		if (playerUnit.vantage)
		{
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator PlayerRangedAttack()
	{
		// Checking that is is the players turn and that they have not attacked yet
		if (state == BattleState.PLAYERTURN && playerAttacked == false)
		{
			playerAttacked = true;
			// Add 2 to the players AC for this turn
			playerUnit.armorClass += 2;
			// "Roll" to see if the player hits ("D20" + agility vs. enemy AC)
			if (enemyUnit.armorClass <= Random.Range(1, 20) + playerUnit.agility)
			{
				// If hit, calculate damage, tell the player, and damage the enemy
				int damage = Random.Range(1, 4) + playerUnit.agility;
				dialogueText.text = "You hit with your bow for " + (damage) + " points of damage.";
				enemyUnit.TakeDamage(damage);
				EnemyisDead = enemyUnit.deadCheck();
				if (EnemyisDead == true)
				{
					state = BattleState.WON;
					EndBattle();
				}
			}
			else
			{
				// If miss, tell player
				dialogueText.text = "You missed with your bow";
			}

			// Update the ememys heath 
			enemyHUD.SetHP(enemyUnit);

			// Wait so player can read
			yield return new WaitForSeconds(2f);

			// Otherwise go to the enemy turn
			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator PlayerMeleeAttack()
	{
		// Checking that is is the players turn and that they have not attacked yet
		if (state == BattleState.PLAYERTURN && playerAttacked == false)
		{
			playerAttacked = true;
			// "Roll" to see if the player hits ("D20" + strength vs. enemy AC)
			if (enemyUnit.armorClass <= Random.Range(1, 20) + playerUnit.strength)
			{
				// If hit, calculate damage, tell the player, and damage the enemy
				int damage = Random.Range(1, 8) + playerUnit.strength;
				dialogueText.text = "You hit with your sword for " + (damage) + " points of damage.";
				enemyUnit.TakeDamage(damage);
				EnemyisDead = enemyUnit.deadCheck();
				if (EnemyisDead)
				{
					state = BattleState.WON;
					EndBattle();
				}
			}
			else
			{
				// If miss, tell player
				dialogueText.text = "You missed with your sword.";
			}

			// Update the ememys heath
			enemyHUD.SetHP(enemyUnit);

			// Wait so player can read
			yield return new WaitForSeconds(2f);

			state = BattleState.ENEMYTURN;
			StartCoroutine(EnemyTurn());
		}
	}

	IEnumerator EnemyTurn()
	{
		for (int i = 0; i < enemyUnit.attacks; i++)
		{
			// Tell the player that the enemy is attaking
			dialogueText.text = enemyUnit.unitName + " attacks!";

			// Wait so player can read
			yield return new WaitForSeconds(1f);

			// "Roll" to see if the enemy hits ("D20" + damage vs. enemy AC)
			if (playerUnit.armorClass <= Random.Range(1, 20) + enemyUnit.toHit)
			{
				// If hit, calculate damage, tell the player, and damage the player
				int damage = Random.Range(1, enemyUnit.damage);
				dialogueText.text = "The " + enemyUnit.unitName + " hit you for " + damage + " points of damage.";
				playerUnit.TakeDamage(damage);
				PlayerisDead = playerUnit.deadCheck();
				if (PlayerisDead == true)
				{
					state = BattleState.LOST;
					EndBattle();
				}
			}
			else
			{
				// If miss, tell player
				dialogueText.text = "The " + enemyUnit.unitName + " missed you!";
			}

			// Update the ememys heath
			playerHUD.SetHP(playerUnit);

			// Wait so player can read
			yield return new WaitForSeconds(2f);

		}

		// Reset player's AC in case they had used a ranged attack last
		playerUnit.armorClass = 10 + playerUnit.agility;
		state = BattleState.PLAYERTURN;
		PlayerTurn();

	}

	// If in the Won or Lost game states go the coresponding next scene
	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			playerUnit.updatePlayerStats();
			SceneManager.LoadScene(sceneIfWin);
		}
		else if (state == BattleState.LOST)
		{
			SceneManager.LoadScene(9);
		}
	}

	// For the player turn wait for them to click a button
	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
		playerAttacked = false;
	}

	// If player clicks the Ranged Attack Button
	public void OnRangedAttackButton()
	{
		if (state == BattleState.PLAYERTURN)
			StartCoroutine(PlayerRangedAttack());
		else
			return;
	}
	// If player clicks the Melee Attack Button
	public void OnMeleeAttackButton()
	{
		if (state == BattleState.PLAYERTURN)
			StartCoroutine(PlayerMeleeAttack());
		else
			return;
	}

}