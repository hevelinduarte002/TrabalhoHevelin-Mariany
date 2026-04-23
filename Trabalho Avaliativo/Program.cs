namespace Trabalho;

class Program
{
    static void Main(string[] args)
    {
        // Controla se o jogador deseja jogar novamente
        string jogarNovamente = "s";

        // Loop principal do jogo — repete enquanto o jogador digitar "s"
        while (jogarNovamente == "s")
        {
            // Cria um gerador de números aleatórios
            Random numAleatorio = new Random();

            // Gera o número secreto entre 1 e 20
            int numSecreto = numAleatorio.Next(1, 20);

            // Contador de tentativas do jogador
            int tentativas = 0;

            Console.WriteLine("=== ACERTE O NÚMERO ===");
            Console.WriteLine("Tente adivinhar o número secreto entre 1 e 20!");
            Console.WriteLine("Digite 0 para sair.");
            Console.WriteLine("Digite um número:");

            // Lê o primeiro número digitado pelo usuário com validação
            int numero = LerNumeroValido();

            // Loop das tentativas — continua até acertar ou digitar 0
            while (numero != 0)
            {
                tentativas++; // Soma uma tentativa

                // Caso o número seja menor que o secreto
                if (numero < numSecreto)
                {
                    Console.WriteLine("O número " + numero + " é MAIOR que o secreto.");
                    Console.WriteLine("INFELIZMENTE NÃO FOI DESTA VEZ!");
                }
                // Caso o número seja mqior que o secreto
                else if (numero > numSecreto)
                {
                    Console.WriteLine("O número " + numero + " é MENOR que o secreto.");
                    Console.WriteLine("INFELIZMENTE NÃO FOI DESTA VEZ!");
                }
                // Caso o jogador acerte
                else
                {
                    Console.WriteLine("PARABÉNS, VOCÊ ACERTOU!");
                    Console.WriteLine("Você acertou em " + tentativas + " tentativa(s)!");
                    break; // Sai do loop
                }

                Console.WriteLine();
                Console.Write("Tente novamente (ou 0 para sair): ");

                // Lê novamente com validação
                numero = LerNumeroValido();
            }

            // Caso o jogador desista digitando 0
            if (numero == 0)
            {
                Console.WriteLine("O número secreto era: " + numSecreto);
            }

            // Pergunta se deseja jogar novamente
            Console.Write("Quer jogar novamente? (s/n): ");
            jogarNovamente = Console.ReadLine();
            Console.WriteLine();
        }

        // Mensagem final do programa
        Console.WriteLine("Obrigado por jogar!");
    }

    // Método responsável por validar a entrada do usuário
    static int LerNumeroValido()
    {
        int numero;

        while (true)
        {
            // Tenta converter o que o usuário digitou para número
            bool conversaoOk = int.TryParse(Console.ReadLine(), out numero);

            // Caso não seja número
            if (!conversaoOk)
            {
                Console.Write("Entrada inválida! Digite um número inteiro (0 a 20): ");
                continue;
            }

            // 0 é permitido para sair
            if (numero == 0)
            {
                return 0;
            }

            // Verifica se está dentro do intervalo permitido
            if (numero < 1 || numero > 20)
            {
                Console.Write("Número fora do intervalo! Digite um número entre 1 e 20 (ou 0 para sair): ");
                continue;
            }

            // Se chegou aqui, o número é válido
            return numero;
        }
    }
}
