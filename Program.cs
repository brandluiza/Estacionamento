Console.Clear();

const decimal PrecoPrimeiraHora = 20;
const decimal PrecoHoraPequeno = 10;
const decimal PrecoHoraGrande = 20;
const decimal PrecoDiariaPequeno = 50;
const decimal PrecoDiariaGrande = 80;
const double AdicionalValet = 0.2;
const decimal PrecoLavagemPequeno = 50;
const decimal PrecoLavagemGrande = 100;

const int TempoDiaria = 5 * 60;
const int TempoTolerancia = 5;
const int MaxTempoPermanencia = 12 * 60;

int tempoPermanencia;
string tamanho;
bool valet, lavagem;

decimal parcialEstacionamento = 0;
decimal parcialValet = 0;
decimal parcialLavagem = 0;
decimal total = 0;

Console.BackgroundColor = ConsoleColor.DarkGreen;

Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine(" Estacionamento \n");

Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;

Console.Write("Tamanho do veículo (P/G): ");

Console.ResetColor();

tamanho = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper();

if (tamanho != "P" && tamanho != "G")
{
    Console.WriteLine("Tamanho inválido.");
    return;
}

Console.ForegroundColor = ConsoleColor.Red;

Console.Write(" Tempo de permanência: ");

Console.ResetColor();

tempoPermanencia = Convert.ToInt32(Console.ReadLine());

if (tempoPermanencia <= 0 || tempoPermanencia > MaxTempoPermanencia)
{
    Console.WriteLine(" Tempo de permanência inválido.");
    return;
}

Console.ForegroundColor = ConsoleColor.Red;

Console.Write(" Serviço de valet (S/N): ");

Console.ResetColor();

valet = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

Console.ForegroundColor = ConsoleColor.Red;

Console.Write(" Serviço de lavagem (S/N): ");

Console.ResetColor();

lavagem = Console.ReadLine()!.Trim().Substring(0, 1).ToUpper() == "S";

if (tempoPermanencia >= TempoDiaria)
{
    if (tamanho == "P")
    {
        parcialEstacionamento = PrecoDiariaPequeno;
    }
    else
    {
        parcialEstacionamento = PrecoDiariaGrande;
    }
}

else

{
    int horasPermanencia = (int)(tempoPermanencia / 60);

    int minutosRestantes = tempoPermanencia % 60;

    if (minutosRestantes > TempoTolerancia)

    {
        horasPermanencia++;
    }

    parcialEstacionamento = PrecoPrimeiraHora;

    int horasAdicionais = horasPermanencia - 1;


    if (horasAdicionais > 0)

    {

        if (tamanho == "P")

        {
            parcialEstacionamento += horasAdicionais * PrecoHoraPequeno;
        }

        else

        {
            parcialEstacionamento += horasAdicionais * PrecoHoraGrande;
        }
    }
}

if (valet)

{
    parcialValet = parcialEstacionamento * Convert.ToDecimal(AdicionalValet);
}

if (lavagem)

{
    if (tamanho == "P")

    {
        parcialLavagem += PrecoLavagemPequeno;
    }

    else

    {
        parcialLavagem += PrecoLavagemGrande;
    }
}

total = parcialEstacionamento + parcialValet + parcialLavagem;

Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine($"\nEstacionamento: {parcialEstacionamento,14:C}");

Console.WriteLine($"Valet: {parcialValet,14:C}");

Console.WriteLine($"Lavagem: {parcialLavagem,14:C}");

Console.WriteLine("-\n ");

Console.WriteLine($"Total: {total,14:C}");
Console.ResetColor();