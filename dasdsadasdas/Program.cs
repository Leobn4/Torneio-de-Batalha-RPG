using System;
using System.Collections.Generic;

public abstract class Criatura 
{
    public string nome;
    public int vida;
    public int ataque;
    public int defesa;
    
   
    public abstract void Atacar(Criatura alvo);
    
    public void ReceberDano(int dano)
        

public class Guerreiro : Criatura
{
 public Guerreiro(string nome, int vida, int ataque, int defesa, int EnergiaVigor)
        : base(nome, vida, ataque, defesa)
    {
        EnergiaVigor = energiaVigor;
    }
public override void Defesa(Guerreiro)
    
   
    public override void Atacar(Criatura alvo)
    {
       
        int chanceCritica = random.Next(1, 101);
        int danoFinal;

        if (chanceCritica <= 20)
        {
            
            danoFinal = ataque * 2;
            Console.WriteLine($"O Cavaleiro fez um ataque CRÍTICO em {nome}!");
        }
        else
        {
          
            danoFinal = ataque;
            Console.WriteLine($"O Cavaleiro fez um ataque normal em {nome}.");
        }
        
     
    }
}
    public class Arqueiro : Criatura
    {
     public Arqueiro(string nome, int vida, int ataque, int defesa, int EnergiaVigor)
        : base(nome, vida, ataque, defesa)
    {
        EnergiaVigor = energiaVigor;
    }
public override void Defesa(Arqueiro)
    
   
    public override void Atacar(Criatura alvo)
    {
       
        int chanceCritica = random.Next(1, 101);
        int danoFinal;

        if (chanceErro <= 30)
        {
            
            danoFinal = ataque = 0;
            Console.WriteLine($" O Arqueiro erro o {nome}!");
        }
        else
        {
          
            danoFinal = ataque;
            Console.WriteLine($"O Arqueiro fez um ataque normal em {nome}.");
        }
        
     
    }
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

    public class Torneio
{
    private List<Criatura> criaturas;

    public Torneio(List<Criatura> criaturas)
    {
        if (criaturas.Count < 2)
            throw new ArgumentException("É necessário pelo menos 2 criaturas para iniciar o torneio.");

        this.criaturas = criaturas;
    }

    public void Iniciar()
    {
        while (criaturas.Count > 1)
        {
            List<Criatura> vencedores = new List<Criatura>();

            for (int i = 0; i < criaturas.Count; i += 2)
            {
                if (i + 1 < criaturas.Count)
                {
                    Criatura a = criaturas[i];
                    Criatura b = criaturas[i + 1];

                    Console.WriteLine($"\nBatalha: {a.nome} vs {b.nome}");

                    while (a.EstaVivo() && b.EstaVivo())
                    {
                        a.Atacar(b);
                        if (b.EstaVivo()) b.Atacar(a);
                    }

                    Criatura vencedor = a.EstaVivo() ? a : b;
                    Console.WriteLine($"Vencedor: {vencedor.nome}");
                    vencedores.Add(vencedor);
                }
                else
                {
                    vencedores.Add(criaturas[i]);
                }
            }

            criaturas = vencedores;
        }

        Console.WriteLine($"\n Campeão do Torneio: {criaturas[0].nome}");
    }
}
public class Program
{
    public static void Main()
    {
        
        var guerreiro1 = new Guerreiro("Guerreiro A", 100, 30, 10, 50);
        var guerreiro2 = new Guerreiro("Guerreiro B", 100, 28, 12, 50);
        var mago = new Mago("Mago", 80, 35, 5, 100, 20);
        var arqueiro = new Arqueiro("Arqueiro", 90, 25, 8, 40);

        
        var criaturas = new List<Criatura> { guerreiro1, guerreiro2, mago, arqueiro };

    
        var torneio = new Torneio(criaturas);
        torneio.Iniciar();
    }
}
}

    


    
