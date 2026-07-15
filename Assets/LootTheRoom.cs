using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LootTheRoom : MonoBehaviour
{
    public GameObject Player;
    public CharacterStats Character;

    // Text thet will be changed
    public TextMeshProUGUI Text;
    // Tracks that the button has been pressed
    public bool pressesd;

    // Start is called before the first frame update
    void Start()
    {
        // Try and find the player object made in charecter creation
        try
        {
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            pressesd = false;
        }
        // If the player object is not found the load these for testing
        catch
        {
            pressesd = false;
        }
    }

    // Called when user clicks the button
    public void OnCheck()
    {
        // Make sure it has not been pressesd yet
        if (pressesd == false)
        {
            pressesd = true;
            // "Roll" a wisdom check DC 12
            if (Random.Range(1, 20) + Character.PlayerStats["Wisdom"] >= 12)
            {
                StartCoroutine(WisdomSuccsess());
            }
            else
            {
                StartCoroutine(WisdomFail());
            }
        }
    }

    // If they passed
    IEnumerator WisdomSuccsess()
    {
        // "Roll" a d5 of healing
        int Healing = Random.Range(1, 5);
        // Tell the user what they found
        Text.text = "You notice a loose floorboard. When you lift it, you find a small leather sack with seven copper pieces. You also discover a glass bottle filled with an enticing blue liquid.";
        yield return new WaitForSeconds(2f);
        // Show the user how much they healed
        Text.text = "You heal " + (Healing) +" hit points";
        //Apply the healing but ensuring that the user's current HP dose not go over the max data
        if (Character.PlayerStats["Current Heath"] + Healing >= Character.PlayerStats["Max Heath"])
        {
            Character.PlayerStats["Current Heath"] = Character.PlayerStats["Max Heath"];
        }
        else
        {
            Character.PlayerStats["Current Heath"] += Healing;
        }
        // Wait so they can read
        yield return new WaitForSeconds(2f);
        // Send them back to the Courtyard
        SceneManager.LoadScene(16);
    }

    // If they fail
    IEnumerator WisdomFail()
    {
        // Tell them they didn't find anything
        Text.text = "Dang no coins! Oh well, better keep looking for Michael.";
        // Wait so they can read
        yield return new WaitForSeconds(2f);
        // Send them back to the courdyard
        SceneManager.LoadScene(16);
    }
}
