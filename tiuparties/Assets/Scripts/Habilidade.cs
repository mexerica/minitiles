using System;

[Serializable]
public class Habilidade
{
    public string nome;
    public int custo;
    public int proximoIndice;

    public Habilidade(string nome, int custo, int proximoIndice) {
        this.nome = nome;
        this.custo = custo;
        this.proximoIndice = proximoIndice;
    }
}
