using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class Anim : MonoBehaviour {

    private Animator anim;
  //  public Text textshowed = null;   
   
    
    // Use this for initialization
    void Start() {

        anim=GetComponent<Animator>();
      

    }

    // Update is called once per frame 
    void Update() {

    }
    public void Paso1() {

        anim.Play("brazos_caidos", -1, 0f);
        anim.Play("estaticpillow", -1, 0f);
       // textshowed.text = word;
    }
    public void Paso2()
    {
        anim.Play("brazos_levantados", -1, 0f);
        anim.Play("estaticpillow", -1, 0f);
    }
    public void Paso3()
    {
        anim.Play("palpacion", -1, 0f);
        anim.Play("estaticpillow", -1, 0f);
        anim.Play("animationCOMPLETA", -1, 0f);
     
    }
    public void Paso4()
    {
        anim.Play("paso4", -1, 0f);
        anim.Play("palpacion", -1, 0f);
        anim.Play("animationCOMPLETA", -1, 0f);
    }
    public void Paso5()
    {
        anim.Play("pezon", -1, 0f);
        anim.Play("estaticpillow", -1, 0f);
    }
    }