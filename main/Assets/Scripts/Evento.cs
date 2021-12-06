using UnityEngine;

public class Evento
{
    public Vector3Int posicao {get; set;}

    public int tipo {get; set;}
    
    public Evento(Vector3Int posicao, int tipo){
        this.posicao = posicao;
        this.tipo = tipo;
    }

}
