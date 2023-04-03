using UnityEngine;

public class MoitaCodigo : MonoBehaviour
{
   
    public GeradorMoita geradorMoita;


    

    
    void Update()
    {
        transform.Translate(Vector2.left * geradorMoita.CurrentSpeed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NextLine"))
        {
            geradorMoita.GerarProximaCmEspaco();
        }
         if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
}
