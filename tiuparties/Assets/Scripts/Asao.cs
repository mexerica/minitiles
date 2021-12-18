using System;

[Serializable]
public class Asao
{
    public Personagem ativo;

    public Habilidade asao;

    public Personagem passivo;

    public Asao(Personagem ativo, Habilidade asao, Personagem passivo) {
        this.ativo = ativo;
        this.asao = asao;
        this.passivo = passivo;
    }

    public override string ToString() {
        if (passivo.nome != null)
            return (ativo.nome + " vai usar " + asao.nome + " no " + passivo.nome);
        return (ativo.nome + " vai usar " + asao.nome);
    }

}
