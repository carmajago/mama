using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stexto : MonoBehaviour
{

    public Text textshowed = null;
    public void cambioP (string word)
    
    {
        textshowed.text = word;   
    }
}


