using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("This is the first log message.");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("This is the second log message.");

        Console.WriteLine(object.ReferenceEquals(logger1, logger2)
            ? "\n Only one Logger instance exists."
            : "\n Different Logger instances exist.");
    }
}
