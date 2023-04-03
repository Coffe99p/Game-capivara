using UnityEngine;

public class GeradorMoita : MonoBehaviour
{
   
   public GameObject Moita;

   public float MaxSpeed;
    public float CurrentSpeed;
     public float MinSpeed;
   
    public float SpeedMultiplier;
    
    void Awake()
    {
        CurrentSpeed = MinSpeed;
        GerarMoita();
    }

    public void GerarProximaCmEspaco()
    {
       float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("GerarMoita", randomWait); 
    }

    void GerarMoita()
    {
       GameObject MoitaIns = Instantiate(Moita, transform.position, transform.rotation); 

       MoitaIns.GetComponent<MoitaCodigo>().geradorMoita = this; 

        MoitaIns.tag = "Moita"; // adicionando a tag "Moita" ao objeto recém-criado
    }

    void Update()
    {
        if(CurrentSpeed < MaxSpeed)
        {
            CurrentSpeed += SpeedMultiplier;
        }
    }
}
