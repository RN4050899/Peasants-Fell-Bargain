using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This Code is used to display to the player what bargain they where given
public class WhatBagain : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject Player;
    public CharacterStats Character;
    int bargainType;
    // Start is called before the first frame update
    void Start()
    {
        // Try and find the player object made in charecter creation
        try
        {
            Player = GameObject.Find("Player");
            Character = Player.GetComponent<CharacterStats>();
            bargainType = Character.bargain;
            // bases on the intiger code of the bargain the player was given show them the matching text
            switch (bargainType)
            {
                case 2:
                    dialogueText.text = "You gained +2 hit points.";
                    break;
                case 3:
                    dialogueText.text = "You gained +2 hit points and +1 point of Wisdom";
                    break;
                case 4:
                    dialogueText.text = "You gained +2 hit points and +1 point of Agility.";
                    break;
                case 5:
                    dialogueText.text = "You gained +2 hit points and +1 point of Strength.";
                    break;
                case 6:
                    dialogueText.text = "You gained +2 hit points and +2 point of Wisdom.";
                    break;
                case 7:
                    dialogueText.text = "You gained +2 hit points and +2 point of Agility.";
                    break;
                case 8:
                    dialogueText.text = "You gained +2 hit points and +2 point of Strength.";
                    break;
                case 9:
                    dialogueText.text = "You gained +2 hit points and +3 point of Wisdom.";
                    break;
                case 10:
                    dialogueText.text = "You gained +2 hit points and +3 point of Agility.";
                    break;
                case 11:
                    dialogueText.text = "You gained +2 hit points and +3 point of Strength.";
                    break;
                case 12:
                    dialogueText.text = "You gained +3 hit points and +3 point of Wisdom.";
                    break;
                case 13:
                    dialogueText.text = "You gained +3 hit points and +3 point of Agility.";
                    break;
                case 14:
                    dialogueText.text = "You gained +3 hit points and +3 point of Strength.";
                    break;
                default:
                    dialogueText.text = "You gained +1 hit point.";
                    break;
            }
        }
        // If the player if not found show an error
        catch
        {
            dialogueText.text = "Error!! player not found";
        }
    }

    
}
