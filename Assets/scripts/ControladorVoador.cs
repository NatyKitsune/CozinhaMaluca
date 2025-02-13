using UnityEngine;
using UnityEngine.UI;

public class ControladorVoador : MonoBehaviour
{
    public float deslocamentoObjeto; //determinar velocidade inicial do obj
    public float incrementoVelocidade; //determinar o aumento de velocidade por segundo
    public Sprite[] imagensObjetos; //Um onibus de vetor que vc pode colocar varias imagens, sprites e vetores. É uma lista

    internal int sentidoV; //Para qual "lado" o objeto vai vertical
    internal Vector3 posicaoObj; // variavel em que indicamos a nova posição (X,Y,Z) dinamicamente
    internal float deslocamentoAbs; //O deslocamento do objeto
    internal int numImagemAtual = 0;

    public float posInicialX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sentidoV = 1;
        posicaoObj = transform.position;
        posInicialX = transform.position.x;

        deslocamentoAbs = deslocamentoObjeto;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimentação do objeto: Velocidade do objeto, vezes sentido (vertical) vezes *Time delta time * velocidade
        posicaoObj.y = posicaoObj.y + (deslocamentoAbs * sentidoV * Time.deltaTime);
        posicaoObj.x = posicaoObj.x + (deslocamentoAbs * Time.deltaTime);

        deslocamentoAbs += incrementoVelocidade * Time.deltaTime;

        transform.position = posicaoObj;

        //Limitadores verticais
        if (transform.position.y > 468)
            sentidoV = -1;
        else if (transform.position.y < 30)
            sentidoV = 1;
    }

    public void MudarImagem()
    {

        numImagemAtual += 1;

        if (numImagemAtual == imagensObjetos.Length)
            numImagemAtual = 0;

        GetComponent<Image>().sprite = imagensObjetos[numImagemAtual];

            
    }

}
