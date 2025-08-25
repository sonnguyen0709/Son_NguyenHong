using LinQ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ.Other_Method
{
    public class Chunk
    {
        public void Show()
        {
            var chunks = Datas.AllProducts.Chunk(2);

            Console.WriteLine("Chunk Example: ");
            int group = 1;

            foreach (var chunk in chunks)
            {
                Console.WriteLine($"Group {group++}: {string.Join(", ", chunk.Select(p => p.Name))}");
            }
        }
    }
}
