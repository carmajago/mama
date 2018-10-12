using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarSintomas : MonoBehaviour {


    public List<GameObject> sintomas;
    public Transform target;

    private GameObject sintomaActual;
    private int contador=0;
    

    public void cambiar()
    {
        if (sintomaActual != null)
        {
            Destroy(sintomaActual);
        }

        if (contador == sintomas.Count ) contador = 0;

        sintomaActual = Instantiate(sintomas[contador]);
        sintomaActual.transform.parent = target;
        sintomaActual.transform.position = Vector3.zero;
        contador++;
    }

    public void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Destroy(sintomaActual);
        }
    }


}
