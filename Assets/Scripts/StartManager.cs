using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StartManager : MonoBehaviour
{
    public TMP_InputField textInput;

    public TMP_Text errorText;
 

   
    // Start is called before the first frame update
    void Start()
    {
   
    }


    bool TextInputValid(string txt)
    {
        if(txt != null && txt != "" && txt != " ")
        {
            return true;
        }
        return false;
    }



    public void StartGame()
    {
        Debug.Log("clicked!");
        string text = textInput.text.Trim();

        if (TextInputValid(text))
        {
            //save here
            MainManager.nameString = text;
            SceneManager.LoadScene(1);
        }else
        {
            errorText.gameObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (textInput != null)
        {
            Debug.Log(textInput.text);
        }
    }
}
