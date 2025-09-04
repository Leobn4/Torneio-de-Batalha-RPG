using System;

public abstract class Criatura 
{
    public string nome;
    public int vida;
    public int ataque;
    public int defesa;
    
   
    public abstract void Atacar(Criatura alvo);
    
    public void ReceberDano(int dano)

}

public class Mago : Criatura
{
    public int mana; // Atributo de mana do mago
    public int custoMana; // Custo de mana por ataque mágico

    // Construtor
    public Mago(string nome, int vida, int ataque, int defesa, int mana, int custoMana)
    {
        this.nome = nome;
        this.vida = vida;
        this.ataque = ataque;
        this.defesa = defesa;
        this.mana = mana;
        this.custoMana = custoMana;
    }

    // Implementação do ataque mágico
    public override void Atacar(Criatura alvo)
    {
        if (mana >= custoMana) // Verifica se o mago tem mana suficiente
        {
            // Ataque mágico: ignora a defesa do alvo
            int danoMagico = this.ataque; // Ignora a defesa do alvo
            Console.WriteLine($"{nome} usou ataque mágico em {alvo.nome}!");

            // O alvo recebe o dano
            alvo.ReceberDano(danoMagico);

            // Deduz o custo de mana após o ataque
            mana -= custoMana;
            Console.WriteLine($"{nome} gastou {custoMana} de mana. Mana restante: {mana}");
        }
        else
        {
            // Se não tiver mana suficiente, o mago não ataca
            Console.WriteLine($"{nome} não tem mana suficiente para atacar!");
        }
    }
}
