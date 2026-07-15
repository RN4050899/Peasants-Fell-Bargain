using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


/*makes it serializable. See https://docs.unity3d.com/ScriptReference/Serializable.html for more details
* Also needs "using System;" to make it serializable. 
* Serializable makes it so that game objects or data structures are in a format unity can understand. 
*/
//[Serializable] 

/*this creates the little drop down menu in TESTING STATS. 
 * See https://docs.unity3d.com/ScriptReference/CreateAssetMenuAttribute.html for more details
 */
//[CreateAssetMenu]


public class CharacterStats : MonoBehaviour
{
    public CharacterStats Instance;
    public Dictionary<string, int> PlayerStats = new Dictionary<string, int>()
    {
        { "Point Pool", 5},
        { "Strength", 0},
        { "Agility", 0},
        { "Wisdom", 0},
        { "Max Heath", 0},
        { "Current Heath", 0},
        { "Armor Class", 0}};

    // This number will represent which bargain the player got (0 if no bargain)
    public int bargain;

    // Tracks if the player should attack first
    public bool advantage;

    // Tracks which locations the player has visited in the court yard 
    public bool visitedA = false;
    public bool visitedB = false;
    public bool visitedC = false;
    public bool visitedD = false;

    // Text box we get the name from
    public TextMeshProUGUI nameEntry;

    // String of name
    public string playername;
    // This makes is so that the Player object will not be destroyed on scene change.
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        playername = "Player";
    }
    
    // Applyed the strength and agility bonuses to HP and AC
    public void finalize()
    {
        PlayerStats["Max Heath"] = 10 + PlayerStats["Strength"];
        PlayerStats["Current Heath"] = 10 + PlayerStats["Strength"];
        PlayerStats["Armor Class"] = 10 + PlayerStats["Agility"];
    }

    // Checking if player wants to leave game
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void changeName()
    {
        playername = nameEntry.text;
    }

}