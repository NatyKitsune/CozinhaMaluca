using UnityEngine;

public class ControladorJogador : MonoBehaviour
{
    public float taxaMovimentacao;

    public Geral juizDoJogo;

    // Update is called once per frame
    void Update()
    {
        float altX, altY;
        // Para cima e para baixo
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < 468)
            altY = 60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > 30)
            altY = -60 * Time.deltaTime * taxaMovimentacao;
        else
            altY = 0;

        // Para os lados
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > 30)
            altX = -60 * Time.deltaTime * taxaMovimentacao;
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 929)
            altX = 60 * Time.deltaTime * taxaMovimentacao;
        else
            altX = 0;

        // Modificar posição:

        Vector3 novaPos = new Vector3(altX, altY, 0);
        transform.position += novaPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Voador")
        {
            //Marca ponto no placar
            juizDoJogo.MarcarPonto();
            //Volta o objeto para a posição horizontal original
            collision.GetComponent<ControladorVoador>().posicaoObj.x = 
                collision.GetComponent<ControladorVoador>().posInicialX;
            //Atualiza a posição vertical do objeto
            float posicaoY = Random.value * 468;

            collision.GetComponent<ControladorVoador>().MudarImagem();
        }
    }
}
//x = 929 Y = 468 X- =30 Y-=30