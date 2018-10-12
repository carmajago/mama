using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SintomasController : MonoBehaviour {

    public Transform camara;
    public Vector3 offset;

    public Vector3 origen;
    public Vector3 rotacion;

    public float smoothTime = 0.1f;
    public float speed = 3.0f;

    public float followDistance = 10f;
    public float verticalBuffer = 1.5f;
    public float horizontalBuffer = 0f;
    private Vector3 velocity = Vector3.zero;
     
	void Start () {
        camara = Camera.main.transform;
        StartCoroutine(iraCamara());
        origen = transform.position;
        rotacion = transform.eulerAngles;
	}
    void LateUpdate()
    {
        //Vector3 targetPosition = camara.TransformPoint(new Vector3(horizontalBuffer, followDistance, verticalBuffer));
        //Debug.Log(targetPosition);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //transform.eulerAngles = camara.eulerAngles;
       // transform.eulerAngles = new Vector3(90, camara.localRotation.y, camara.localRotation.z);
        //rotation.y = camara.rotation.y;
    }

    public void reiniciar()
    {
        transform.eulerAngles = rotacion;
        Debug.Log("Entra");
        transform.position = origen;
        StopAllCoroutines();
        StartCoroutine(iraCamara());
    }
	
	
    IEnumerator iraCamara()
    {
        Vector3 targetPosition = camara.TransformPoint(new Vector3(horizontalBuffer, followDistance, verticalBuffer));
        while ((targetPosition - transform.position).magnitude >= 0.1)
        {
            Vector3 targetDir = camara.position - transform.position;
            float step = Time.deltaTime;
           
            transform.position = Vector3.MoveTowards(transform.position,( targetPosition), step*1.3f);
            //transform.eulerAngles= Vector3.RotateTowards(transform.position, (camara.position + offset), step, 0.01f);
            transform.rotation = Quaternion.Lerp(transform.rotation, camara.rotation, 0.07f);
            yield return null;
            
        }
    }
}
