using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLOCK : MonoBehaviour
{
    public FlockManager myManager;// pegando o scrip 
    float speed;

    
    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);// definendo uma velocidade ao objeto apartir do scripte flockmanager que a uma velocidade definida pelo usuario
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);//movimentando o objeto para frente 
    }
}
