using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum EncounterState { START, AGILITYFail, AGILITYWin, STRENGTHFail, STRENGTHWin}

public class PathSaveingThrows : MonoBehaviour
{
	public GameObject Player;
	public CharacterStats Character;

	// Main text that we want to change
	public TextMeshProUGUI Text;
	// Text under the button that we want to change
	public TextMeshProUGUI ButtonText;

	public EncounterState state;

	// Start is called before the first frame update
	void Start()
    {
		// Try and find the player object made in charecter creation
		try
		{
			Player = GameObject.Find("Player");
			Character = Player.GetComponent<CharacterStats>();
			state = EncounterState.START;
		}
		// If the player object is not found the load these for testings
		catch
		{
			state = EncounterState.START;
		}
	}

	// Called when user clicks the button
	public void OnCheck()
    {
		// Check if it has already been pressed
		// Note: in this case the first time it has been pressesd it is for the Agility check
		if(state == EncounterState.START)
        {
			// "Roll" a Agility check DC 10
			if (Random.Range(1, 20) + Character.PlayerStats["Agility"] >= 10)
			{
				state = EncounterState.AGILITYWin;
				StartCoroutine(AgilitySuccsess());
			}
			else
			{
				state = EncounterState.AGILITYFail;
				StartCoroutine(AgilityFail());
			}
		}
		// If it has been pressed once already then this time it is for the strength check
		if (state == EncounterState.AGILITYFail)
		{
			// "Roll" a Strength check DC 10
			if (Random.Range(1, 20) + Character.PlayerStats["Strength"] >= 10)
			{
				state = EncounterState.STRENGTHWin;
				StartCoroutine(StrengthSuccsess());
			}
			else
			{
				state = EncounterState.STRENGTHFail;
				StartCoroutine(StrengthFail());
			}
		}
    }

	IEnumerator AgilitySuccsess()
	{
		Text.text = "You jump back in the nick of time, just avoiding the disgusting larvae that writhe blindly on the ground before dying for lack of a fresh host.";
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(16);
	}

	IEnumerator AgilityFail()
	{
		Text.text = "Agony courses through your body as the larva start burrowing into your skin! (you take 1 point of damage)";
		ButtonText.text = "Make a strength saving throw";
		Character.PlayerStats["Current Heath"]-=1;
		yield return new WaitForSeconds(2f);
		if(Character.PlayerStats["Current Heath"] <= 0)
        {
			SceneManager.LoadScene(9);
		}
	}

	IEnumerator StrengthSuccsess()
	{
		Text.text = "You manage to fight off the larva befor it makes you its new host";
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(16);
	}

	IEnumerator StrengthFail()
	{
		Text.text = "The world around you turns dark and you feel cold. So cold…..";
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(9);
	}

}
