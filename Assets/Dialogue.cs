using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Dialogue : MonoBehaviour
{
    // Text elemant that will be changed
    public TextMeshProUGUI textComponent;
    // Array of strings that this diolog box will display
    public string[] lines;
    // Factor that controles the scroll rate of text
    public float textSpeed;
    // Scene that we want to go to after the text is done
    public int NextScene;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        startDialogue();

    }
    // Alyssa was here
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            // Check if what we are showing is the whole line
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        
    }

    // Show the first line of text
    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    //Typeing one charecter at a time
    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    // Drew was here
    //testing changes
    void NextLine()
    {
        if(index < lines.Length-1) 
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(NextScene);
        }
    }
}
