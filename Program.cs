using System;
using System.Collections.Generic;

class CuentaBancaria
{
    public string Nombre { get; set; }
    public double Saldo { get; private set; }
    private List<string> transacciones;

    public CuentaBancaria(string nombre, double saldoInicial)
    {
        Nombre = nombre;
        Saldo = saldoInicial;
        transacciones = new List<string> { $"Cuenta creada con saldo inicial: {Saldo:C}" };
    }

    public void Depositar(double cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            transacciones.Add($"Depósito: +{cantidad:C}");
            Console.WriteLine($"Depósito exitoso. Nuevo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("Cantidad inválida. Inténtalo de nuevo.");
        }
    }

    public void Retirar(double cantidad)
    {
        if (cantidad > 0 && cantidad <= Saldo)
        {
            Saldo -= cantidad;
            transacciones.Add($"Retiro: -{cantidad:C}");
            Console.WriteLine($"Retiro exitoso. Nuevo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("Fondos insuficientes o cantidad inválida.");
        }
    }

    public void MostrarSaldo()
    {
        Console.WriteLine($"Saldo de {Nombre}: {Saldo:C}");
    }

    public void MostrarTransacciones()
    {
        Console.WriteLine($"Historial de transacciones de {Nombre}:");
        foreach (var t in transacciones)
        {
            Console.WriteLine(t);
        }
    }
}

class ProgramaBanco
{
    static void Main()
    {
        CuentaBancaria cuentaAngel = new CuentaBancaria("Angel", 1000);
        CuentaBancaria cuentaBraley = new CuentaBancaria("Braley", 1000);
        
        while (true)
        {
            Console.WriteLine("\n--- Menú de Banco ---");
            Console.WriteLine("1. Ver saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Ver historial de transacciones");
            Console.WriteLine("5. Salir");
            Console.Write("Elige una opción: ");
            
            string opcion = Console.ReadLine();

            if (opcion == "5")
            {
                Console.WriteLine("Saliendo del programa...");
                break;
            }

            Console.Write("\nElige la cuenta (Angel/Braley): ");
            string nombreCuenta = Console.ReadLine().Trim().ToLower();
            CuentaBancaria cuenta = null;

            if (nombreCuenta == "angel")
                cuenta = cuentaAngel;
            else if (nombreCuenta == "braley")
                cuenta = cuentaBraley;
            else
            {
                Console.WriteLine("Cuenta no encontrada.");
                continue;
            }

            switch (opcion)
            {
                case "1":
                    cuenta.MostrarSaldo();
                    break;
                case "2":
                    Console.Write("Ingrese la cantidad a depositar: ");
                    if (double.TryParse(Console.ReadLine(), out double deposito))
                        cuenta.Depositar(deposito);
                    else
                        Console.WriteLine("Entrada inválida.");
                    break;
                case "3":
                    Console.Write("Ingrese la cantidad a retirar: ");
                    if (double.TryParse(Console.ReadLine(), out double retiro))
                        cuenta.Retirar(retiro);
                    else
                        Console.WriteLine("Entrada inválida.");
                    break;
                case "4":
                    cuenta.MostrarTransacciones();
                    break;
                default:
                    Console.WriteLine("Opción inválida. Inténtalo de nuevo.");
                    break;
            }
        }
    }
}
