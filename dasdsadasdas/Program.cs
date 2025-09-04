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
    public int mana; 
    public int custoMana;


    public Mago(string nome, int vida, int ataque, int defesa, int mana, int custoMana)
    {
        nome = nome;
        vida = vida;
        ataque = ataque;
        defesa = defesa;
        mana = mana;
        custoMana = custoMana;
    }


    public override void Atacar(Criatura alvo)
    {
        if (mana >= custoMana) 
        {
            
            int danoMagico = ataque; 
            Console.WriteLine($"{nome} usou ataque mágico em {alvo.nome}!");


            
            alvo.ReceberDano(danoMagico);

        
            mana -= custoMana;
            Console.WriteLine($"{nome} gastou {custoMana} de mana. Mana restante: {mana}");
        }
        else
        {
    
            Console.WriteLine($"{nome} não tem mana suficiente para atacar!");
        }
    }
    public class Batalha
{
    private Criatura criaturaA;
    private Criatura criaturaB;

    public Batalha(Criatura a, Criatura b)
    {
        criaturaA = a;
        criaturaB = b;
    }

    public Criatura Executar()
    {
        Console.WriteLine($"\n Iniciando batalha entre {criaturaA.nome} e {criaturaB.nome}");

        while (criaturaA.EstaVivo() && criaturaB.EstaVivo())
        {
            Console.WriteLine($"\n{criaturaA.nome} ataca {criaturaB.nome}");
            criaturaA.Atacar(criaturaB);
            if (!criaturaB.EstaVivo()) break;

            Console.WriteLine($"{criaturaB.nome} ataca {criaturaA.nome}");
            criaturaB.Atacar(criaturaA);
        }

        Criatura vencedor = criaturaA.EstaVivo() ? criaturaA : criaturaB;
        Console.WriteLine($"\n Vencedor da batalha: {vencedor.nome}");
        return vencedor;
    }
}


    public class Torneio
{
    private List<Criatura> criaturas;

    public Torneio(List<Criatura> criaturas)
    {
        if (criaturas.Count < 2)
            throw new ArgumentException("É necessário pelo menos 2 criaturas para iniciar o torneio.");

        criaturas = criaturas;
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

    


    

