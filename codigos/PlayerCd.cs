using UnityEngine;
using UnityEngine.UI;

public class PlayerCd : MonoBehaviour
{
    public float ForcaPulo;
    float Metros;


    [SerializeField]
    bool NoChao = false; 
    bool isAlive = true;
    
    Rigidbody2D RB;

    public Text MetrosTxt;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        Metros = 0;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(NoChao == true)
            {
                RB.AddForce(Vector2.up * ForcaPulo);
                NoChao = false; 
            }
        }       

        if(isAlive)
        {
            Metros += Time.deltaTime * 4;
            MetrosTxt.text = Metros.ToString("F") + "Metros";
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("chao"))
    {
        if (NoChao == false)
        {
            NoChao = true;
        }
    }

     if (collision.gameObject.CompareTag("Moita"))
    {
       isAlive = false;
       Time.timeScale = 0;
    }
}
}
