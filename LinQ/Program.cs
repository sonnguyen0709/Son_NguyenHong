using static LinQ.Data.Datas;
using LinQ.Standard_Operation;
using System;
using LinQ.Other_Method;

public class Program
{
    public static void Main()
    {
        var join = new Join();
        join.Show();
        Console.WriteLine();

        var restriction = new Restriction();
        restriction.Show();
        Console.WriteLine();

        var projection = new Projection();
        projection.Show();
        Console.WriteLine();

        var partitioning = new Partitioning();
        partitioning.Show();
        Console.WriteLine();

        var ordering = new Ordering();
        ordering.Show();
        Console.WriteLine();

        var grouping = new Grouping();
        grouping.Show();
        Console.WriteLine();

        var setting = new SetOperation();
        setting.Show();
        Console.WriteLine();

        var conversion = new Conversion();
        conversion.Show();
        Console.WriteLine();

        var element = new Element();
        element.Show();
        Console.WriteLine();

        var generation = new Generation();
        generation.Show();
        Console.WriteLine();

        var quantifier = new Quantifier();
        quantifier.Show();
        Console.WriteLine();

        var aggregate = new Aggregate();
        aggregate.Show();
        Console.WriteLine();

        var zip = new Zip();
        zip.Show();
        Console.WriteLine();

        var concat = new Concat();
        concat.Show();
        Console.WriteLine();

        var sequenceEqual = new SequenceEqual();
        sequenceEqual.Show();
        Console.WriteLine();

        var chunk = new Chunk();
        chunk.Show();
        Console.WriteLine();
    }
}
