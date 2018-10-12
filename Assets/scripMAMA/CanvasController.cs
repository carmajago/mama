using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{


    private Animator animator;
    public GameObject mujer;


    private bool main;
    private bool mama;
    private bool info;
    private bool senales;


    void Start()
    {
        animator = GetComponent<Animator>();

        mujer.SetActive(false);

    }

    public void abrirMenuMama()
    {
        main = false;
        mama = true;
        animator.SetTrigger("Main");
        animator.SetTrigger("AutoExamen");
        mujer.SetActive(true);
    }

    public void abrirMenuSenales()
    {
        main = false;
        senales = true;
        animator.SetTrigger("Main");
        animator.SetTrigger("Sintomas");

    }
    public void abrirMenuInfo()
    {
        main = false;
        info = true;
        animator.SetTrigger("Main");

    }

    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (main)
            {
                Application.Quit();
            }
            else if (mama)
            {
                animator.SetTrigger("AutoExamen");
                mama = false;
                main = true;
                mujer.SetActive(false);
            }
            else if (info)
            {

            }
            else if (senales)
            {
                senales = false;
                main = true;
                animator.SetTrigger("Sintomas");
            }

            
        }
    }



}
