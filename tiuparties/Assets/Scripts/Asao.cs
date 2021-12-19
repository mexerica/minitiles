using System;

[Serializable]
public class Asao
{
    public Personagem ativo;

    public Habilidade habilidade;

    public Item item;

    public Personagem passivo;

    public Asao(Personagem ativo, Habilidade habilidade, Personagem passivo) {
        this.ativo = ativo;
        this.habilidade = habilidade;
        this.passivo = passivo;
    }

    public Asao(Personagem ativo, Item item, Personagem passivo) {
        this.ativo = ativo;
        this.item = item;
        this.passivo = passivo;
    }

    public override string ToString() {
        // se for usar uma habilidade
        if (habilidade.nome != null) {
            if (passivo.nome != null)
                return (ativo.nome + " vai usar " + habilidade.nome + " em " + passivo.nome);
            return (ativo.nome + " vai usar " + habilidade.nome);
        }
        // se for usar um item
        else {
            if (passivo.nome != null)
                return (ativo.nome + " vai usar " + item.nome + " em " + passivo.nome);
            return (ativo.nome + " vai usar " + item.nome);
        }
    }

}
