using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
/// <summary>
/// Esta clase se encarga de controlar la animacion del personaje.
/// También bloqueo los botones cuando no existen más pasos siguientes o anteriores
/// </summary>
public class AnimacionController : MonoBehaviour
{

    private Animator animator;

    public GameObject sonidos;

    [Header("Botones")]
    public GameObject botonReiniciar;
    public Button botonAnterior;

    private int contador = 0; //El contador va hasta el numero de pasos que se realicen;

    private AudioSource[] pasos;
    void Start()
    {
        botonReiniciar.GetComponent<Button>().onClick.AddListener(reiniciar);

        animator = GetComponent<Animator>();
        botonAnterior.onClick.AddListener(pasoAnterior);
       // botonReiniciar.onClick.AddListener(pasoSiguiente);
        botonAnterior.interactable = false;
        pasos = new AudioSource[sonidos.transform.childCount];

        for (int i = 0; i < sonidos.transform.childCount; i++)
        {
            pasos[i] = sonidos.transform.GetChild(i).GetComponent<AudioSource>();
        }
        StartCoroutine(AnimacionAutomatica());
    }



    private void pasoSiguiente()
    {
        if (contador > 0)
        {
            pasos[contador - 1].Stop();
        }
        Debug.Log(contador);

        if (contador == 1)
        {
            StartCoroutine(cicloPapacion());
        }

        pasos[contador].Play();
        contador++;
        animator.SetTrigger("Siguiente");
        verificarLimites();
    }
    private void pasoAnterior()
    {
        contador--;
        Debug.Log(contador);
        
        pasos[contador].Stop();
        if(contador!=0)
        pasos[contador - 1].Play();
        animator.SetTrigger("Anterior");
        verificarLimites();
    }


    private void verificarLimites()
    {
        //botonSiguiente.interactable = true;
        botonAnterior.interactable = true;


        if (contador < 1)
        {
            botonAnterior.interactable = false;
        }
        if (contador == 3)
        {
          //  botonSiguiente.interactable = false;
        }



    }

    IEnumerator cicloPapacion()
    {

            yield return new WaitForSeconds(4);
            animator.SetTrigger("Ciclo");

            yield return new WaitForSeconds(4);
            animator.SetTrigger("Ciclo");

    }

    IEnumerator AnimacionAutomatica()
    {

        botonReiniciar.SetActive(false);
        pasos[0].Play();
        Debug.Log(pasos[0].name);
        yield return new WaitForSeconds(pasos[0].clip.length + 1f);
        animator.SetTrigger("Siguiente");
        pasos[1].Play();
        Debug.Log(pasos[1].name);
        yield return new WaitForSeconds( pasos[1].clip.length + 1f);
        animator.SetTrigger("Siguiente");
        pasos[2].Play();
        Debug.Log(pasos[2].name);
        yield return new WaitForSeconds(pasos[2].clip.length + 1f);
        animator.SetTrigger("Siguiente");
        pasos[3].Play();
        Debug.Log(pasos[3].name);
        yield return new WaitForSeconds(pasos[3].clip.length + 1f);
        //animator.SetTrigger("Siguiente");
       // yield return new WaitForSeconds(pasos[3].clip.length + 1f);

        botonReiniciar.SetActive(true);
    }

    public void reiniciar()
    {
        animator.SetTrigger("Siguiente");
        StartCoroutine(AnimacionAutomatica());

    }

    


}
