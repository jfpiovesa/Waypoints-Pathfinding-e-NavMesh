using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgenteManager : MonoBehaviour
{ 
    GameObject[] agents;// fazendo um arrey/lista de objtos 
   void Start () 
   {
        agents= GameObject.FindGameObjectsWithTag("AI");// pegando os objetos que tem a tag "Ai" em cena e pondo dentro do Arrey/Lista quando se inicia a cena 
   }
    // Update is called once per framevoid
   void Update () 
   {
        if(Input.GetMouseButtonDown(0)) // se clicar o botão do mouse 0 faça uma ação
        {
            RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 200))// pegando a posiçãoda camera em uma certa distacia, e si a posição do mouse estiver na vissão da camera e colidir com objeto com colisão 
                {
                    foreach(GameObject a in agents)//verifica os objetos que estão dentro do arrey/lista e manda um ação 
                    a.GetComponent<AiControl>().agent.SetDestination(hit.point);//se componete AiControl tiver no objeto, mande ele seguir uma posição que sera a posição do mouse que é clicada,  passada anterior mente. 
            
                }
        }
    }
}
