using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab; // local que o prefab do objeto que sera criado  na cena 
    public int numFish = 20; // numero de objetos que vãos ser criados
    public GameObject[] allFish;// arrey de objetos 
    public Vector3 swinLimits = new Vector3(5, 5, 5);

    [Header("Configurações do Cardume")]
    [Range(0.0f, 5.0f)]// tamanho da velocidade minima 
    public float minSpeed;
    [Range(0.0f, 5.0f)]// tamanho da velocidade maxima 
    public float maxSpeed;
    private void Start()
    {
        allFish = new GameObject[numFish]; // pondo todos os objetos em um arrey
        for(int i = 0; i < numFish; i++)//pasando em cada objeto para poder spawnar em posições diferentes
        {
            Vector3 pos = this.transform.position + new Vector3(
                Random.Range(-swinLimits.x, swinLimits.x), 
                Random.Range(-swinLimits.y, swinLimits.y),
                Random.Range(-swinLimits.z, swinLimits.z));
            allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity); 
        }
    }
}
