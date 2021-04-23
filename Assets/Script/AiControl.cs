using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiControl : MonoBehaviour
{
      public NavMeshAgent agent; // declarando  como publico o componete 
        // Use this for initialization
      void  Start ()
      {
        agent= this.GetComponent<NavMeshAgent>(); // pegando componete que em no objeto que este scripte sera posto
    }
}
