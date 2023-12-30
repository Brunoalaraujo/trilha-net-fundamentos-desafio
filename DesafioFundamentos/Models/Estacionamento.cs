using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para estacionar: ");

            // Pedir para o usuário digitar uma placa, converte para maiúsculas. 
            string novaPlaca = "";
            novaPlaca = Console.ReadLine().ToUpper();


            // Validação da placa com Regex
            Regex modeloPlacaAntiga = new Regex(@"^[A-Z]{3}-\d{4}$"); // ABC-1234
            Regex modeloPlacaMercosul = new Regex(@"^[A-Z]{3}\d{1}[A-Z]{1}\d{2}$"); // ABC1D23

            // Adicionar na lista "veiculos"
            if (modeloPlacaAntiga.IsMatch(novaPlaca) || modeloPlacaMercosul.IsMatch(novaPlaca)) // Compara a novaPlaca com a Regex
            {
                veiculos.Add(novaPlaca);
                Console.WriteLine($"Veículo com a placa {novaPlaca}, foi cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine($"A placa {novaPlaca} é inválida");
            }

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = "";
            placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;
                decimal valorTotal = 0;

                // Converte a quantidade de horas que o veículo permaneceu estacionado, digitado pelo usuário, em int
                horas = int.Parse(Console.ReadLine());

                // Calcula valor total                
                valorTotal = precoInicial + (precoPorHora * horas);

                // Remover a placa digitada da lista de veículos
                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                // Realizar um laço de repetição, exibindo os veículos estacionados
                foreach (string carro in veiculos)
                {
                    Console.WriteLine(carro);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
