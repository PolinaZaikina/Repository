using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5._2
{

    internal class FitnessCenter
    {
        public List<Record> Records { get; set; }

        public FitnessCenter()
        {
            Records = new List<Record>();
        }

        public void FindClientWithMaxDuration()
        {
            var result = Records
                .GroupBy(r => new { r.Year, r.ClientID })
                .Select(g => new
                {
                    g.Key.ClientID,
                    g.Key.Year,
                    TotalDuration = g.Sum(r => r.Duration)
                })
                .OrderByDescending(r => r.TotalDuration)
                .ThenByDescending(r => r.ClientID)
                .GroupBy(r => r.Year);

            foreach (var yearGroup in result)
            {
                Console.WriteLine($"Год: {yearGroup.Key}");
                foreach (var client in yearGroup)
                {
                    Console.WriteLine($"ID клиента: {client.ClientID}\tОбщая продолжительность: {client.TotalDuration}");
                }
                Console.WriteLine();
            }
        }
    }
}
