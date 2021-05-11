using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FLOCK : MonoBehaviour
{
    public FlockManager myManager;// pegando o scrip 
    float speed; // velocidade
    bool turnnig = false;// verificação de rotação 



    void Start()
    {
        speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);// definendo uma velocidade ao objeto apartir do scripte flockmanager que a uma velocidade definida pelo usuario
    }

    // Update is called once per frame
    void Update()
    {
        Bounds b = new Bounds(myManager.transform.position, myManager.swinLimits * 2);// distacia maxaima que o peixe do cardume vai
        Vector3 direction = myManager.transform.position - transform.position;
        RaycastHit hit = new RaycastHit();
        if (!b.Contains(transform.position))
        {

            turnnig = true;
          
            direction = myManager.transform.position - transform.position;
        }
        else if(Physics.Raycast(transform.position, this.transform.forward * 50, out hit))// verificando se a colisão perto do objeto
        {
            turnnig = true;
            direction = Vector3.Reflect(this.transform.forward, hit.normal);// verifica a direção que vai e se tem algo que va colidir
        
        }
        else
        {
            turnnig = false;
        }
        if(turnnig)//rotação do objeto 
        {
            
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(direction),
                myManager.rotateSpeed * Time.deltaTime);
        }
        else
        {
            if(Random.Range(0,100) <10)// velocidades do peixes forma randomica
            {
                speed = Random.Range(myManager.minSpeed, myManager.maxSpeed);
            }
            if (Random.Range(0, 100) < 20)
            {
                AplyRules();

            }

        }
        transform.Translate(0, 0, Time.deltaTime * speed);//movimentando o objeto para frente 
      
    }
    private void AplyRules()
    {
        GameObject[] goes;// arrey de objetos
        goes = myManager.allFish;//pegando pro goes o  arrey de todos os peixes

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;

        float gSpeed = 0.01f;// velocidade
        float nDistance;// raio de destacia
        int grupSize = 0;// tamanho do grupo

        foreach(GameObject go in goes)//se não for este objeto a distacia do corpo dos objetos vai aulmentar  e se for menor que 1 vai diminuir 
        {
            if( go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= myManager.neighbourDistance)
                {
                    vcenter += go.transform.position;
                    grupSize++;

                    if(nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position -  go.transform.position);
                    }
                    FLOCK anotheFlock = go.GetComponent<FLOCK>();
                    gSpeed = gSpeed + anotheFlock.speed;

                }              
              }
        }
        if(grupSize >0)//se o  grupo for menor que 0 
        {
            vcenter = vcenter / grupSize + (myManager.goalPos - this.transform.position); // calculado o raio de ação dos peixes
            speed = gSpeed / grupSize;// a velocidade que eles vão agir referente ao grupo

            Vector3 direction = (vcenter + vavoid) - transform.position;

            if( direction !=  Vector3.zero)// se centro for diferente faça que rotacione para centro do grupo 
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.LookRotation(direction), myManager.rotateSpeed *Time.deltaTime);
            }
        }

    }
}
