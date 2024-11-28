namespace atp_2024_2_gestao_produto_poo
{
    class Program
    {
        static int Menu()
        {
            int opcao = 0;

            Console.WriteLine("=====> ESTOQUE DE PRODUTOS <=====");
            Console.WriteLine("1 - Adicionar produto");
            Console.WriteLine("2 - Editar produto");
            Console.WriteLine("3 - Apagar produto");
            Console.WriteLine("4 - Buscar produto");
            Console.WriteLine("5 - Listar produtos");
            Console.WriteLine("0 - Sair");
            Console.Write("Digite a opcao desejada: ");

            opcao = int.Parse(Console.ReadLine());

            return opcao;
        }
        
        
        static void Main(string[] args)
        {
            Estoque estoque = new Estoque(5);

            int op = 0;

            do
            {
                Console.Clear();
                op = Menu();

                switch (op)
                {
                    case 1: estoque.Adicionar();
                        break;
                    case 2: estoque.Editar();
                        break;
                    case 3: estoque.Apagar();
                        break;
                    case 4: estoque.Buscar();
                        break;
                    case 5: estoque.Imprimir();
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default: Console.WriteLine("Opção Inválida!");
                        break;
                }
                Console.ReadKey();

            } while (op != 0);



            Console.ReadKey();
        }
    }

    class Produto
    {
        public int Id;
        public string Nome; 
        public double Preco;
        public int Qtd;

        public void Imprimir()
        {
            Console.WriteLine($"{Id};{Nome};{Preco};{Qtd}");
        }

        public void Adicionar(int id)
        {
            Id = id;
            Console.Write("Digite o nome do produto: ");
            Nome = Console.ReadLine();
            Console.Write("Digite o preço do produto: ");
            Preco = double.Parse(Console.ReadLine());
            Console.Write("Digite o quantidade do produto: ");
            Qtd = int.Parse(Console.ReadLine());
        }
    }

    class Estoque
    {
        private Produto[] produtos;
        private int MAX;
        private int N;
        private int SEQUENCIA;

        public Estoque(int max)
        {
            MAX = max;
            produtos = new Produto[MAX];
            N = 0;
            SEQUENCIA = 1;

            for(int i=0; i < MAX; i++)            
                produtos[i] = new Produto();            
        }

        private int BuscarPosicaoProdutoPorId(int id)
        {
            int pos = -1;
            for (int i = 0; i < N; i++)
                if (produtos[i].Id == id)
                {
                    pos = i;
                    break;
                }
            return pos;
        }

        private int BuscarPosicaoProdutoPorNome(string nome)
        {
            int pos = -1;
            for (int i = 0; i < N; i++)
                if (produtos[i].Nome == nome)
                {
                    pos = i;
                    break;
                }
            return pos;
        }

        public void Imprimir()
        {
            Console.WriteLine($"\nQuantidade de Produtos: {N}");
            for (int i = 0; i < N; i++)
                produtos[i].Imprimir();
        }

        public void Adicionar()
        {
            if(N == MAX)
            {
                Console.WriteLine("\nEstoque Cheio");
            }
            else
            {
                produtos[N].Adicionar(SEQUENCIA);
                N++;
                SEQUENCIA++;
                Console.WriteLine("\nProduto Adicionado com sucesso!!!");
            }
        }

        public void Editar()
        {
            Console.Write("\nDigite o codigo do produto: ");
            int cod = int.Parse(Console.ReadLine());
            int pos = BuscarPosicaoProdutoPorId(cod);
            if(pos == -1)
            {
                Console.WriteLine("\nProduto não encontrado!\n");
            }
            else
            {
                produtos[pos].Adicionar(cod);
                Console.WriteLine("\nProduto Alterado com sucesso!!!");
            }
        }

        public void Apagar()
        {
            Console.Write("\nDigite o codigo do produto: ");
            int cod = int.Parse(Console.ReadLine());
            int pos = BuscarPosicaoProdutoPorId(cod);
            if (pos == -1)
            {
                Console.WriteLine("\nProduto não encontrado!\n");
            }
            else
            {
                N--;
                for (int i = pos; i < N; i++)
                    produtos[i] = produtos[i + 1];
                Console.WriteLine("\nProduto Removido com sucesso!!!");
            }
        }

        public void Buscar()
        {

        }
    }
}
