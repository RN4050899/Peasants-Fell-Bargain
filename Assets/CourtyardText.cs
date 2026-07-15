using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

// This code contains the logic for the text seen in the courtyard scene
public class CourtyardText : MonoBehaviour
{
	// We need the player object to pass data between sceens
	public GameObject Player;
	public CharacterStats Character;

	// This is the Text we want this code to update
	public TextMeshProUGUI Text;

	// This is where we store what places the player has already visited
	public bool visitedA;
	public bool visitedB;
	public bool visitedC;
	public bool visitedD;

	// Start is called before the first frame update
	void Start()
	{
		// Try and find the player object made in charecter creation
		try
		{
			Player = GameObject.Find("Player");
			Character = Player.GetComponent<CharacterStats>();
			visitedA = Character.visitedA;
			visitedB = Character.visitedB;
			visitedC = Character.visitedC;
			visitedD = Character.visitedD;
		}
		// If the player object is not found the load these for testing
		catch
		{
			visitedA = false;
			visitedB = false;
			visitedC = false;
			visitedD = false;
		}
	}

	IEnumerator AButtonClick()
	{
		// If player has not been here yet send them there and record that they have been there
		if (visitedA == false)
		{
			Character.visitedA = true;
			SceneManager.LoadScene(17);
		}
		// If they have been there remind them
		else
		{
			Text.text = "You have already been to the gatehouse.";
			yield return new WaitForSeconds(2f);
			Text.text = "Where do you want to go?";
		}
	}

	IEnumerator BButtonClick()
	{
		// If player has not been here yet send them there and record that they have been there
		if (visitedB == false)
		{
			Character.visitedB = true;
			SceneManager.LoadScene(19);
		}
		// If they have been there remind them
		else
		{
			Text.text = "You have already been down the path.";
			yield return new WaitForSeconds(2f);
			Text.text = "Where do you want to go?";
		}
	}

	// If they have been there remind them
	IEnumerator CButtonClick()
	{
		// If player has not been here yet send them there and record that they have been there
		if (visitedC == false)
		{
			Character.visitedC = true;
			SceneManager.LoadScene(18);
		}
		else
		{
			Text.text = "You have already been in the stables.";
			yield return new WaitForSeconds(2f);
			Text.text = "Where do you want to go?";
		}
	}

	// If they have been there remind them
	IEnumerator DButtonClick()
	{
		// If player has not been here yet send them there and record that they have been there
		if (visitedD == false)
		{
			Character.visitedD = true;
			SceneManager.LoadScene(20);
		}
		else
		{
			Text.text = "You have already been to the barracks.";
			yield return new WaitForSeconds(2f);
			Text.text = "Where do you want to go?";
		}
	}

	// Starts the A Coroutine if button is pressed
	public void OnAButton()
	{
		StartCoroutine(AButtonClick());
	}

	// Starts the B Coroutine if button is pressed
	public void OnBButton()
	{
		StartCoroutine(BButtonClick());
	}

	// Starts the C Coroutine if button is pressed
	public void OnCButton()
	{
		StartCoroutine(CButtonClick());
	}

	// Starts the D Coroutine if button is pressed
	public void OnDButton()
	{
		StartCoroutine(DButtonClick());
	}
}
