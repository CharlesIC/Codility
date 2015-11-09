using System;
using System.Linq;
using System.Collections.Generic;

namespace Practice
{
    public static class Palantir
    {
        public static int GetMinTimeDifference(string[] times)
        {
            times = new[] { "10:00", "19:20", "06:45", "00:12", "23:50", "04:22" };

            var n = times.Length;
            Array.Sort(times);

            var minDiff = 1500;
            for (int i = 0; i < n; i++)
            {
                var t1 = times[i].Split(':');
                var t2 = times[(i + 1) % n].Split(':');

                var h1 = int.Parse(t1[0]);
                var h2 = int.Parse(t2[0]);

                var m1 = int.Parse(t1[1]);
                var m2 = int.Parse(t2[1]);

                h1 = h1 == 0 ? 24 : h1;

                var diff = ((h2 - h1 + 24) % 24) * 60;
                diff += (m2 - m1);

                minDiff = Math.Min(minDiff, diff);
            }

            return minDiff;
        }


        public static string[] GetSuspiciousList(string[] transactions)
        {
            transactions = new[] { "Tom|4000|NYC|50" };

            var suspects = new Dictionary<string, int>();
            var record = new Dictionary<string, Tuple<string, int>>();

            foreach (var transaction in transactions)
            {
                var t = transaction.Split('|');

                var name = t[0];
                var amount = int.Parse(t[1]);
                var location = t[2];
                var time = int.Parse(t[3]);

                // Type 1 Fraud
                if (!suspects.ContainsKey(name) && amount > 3000)
                {
                    suspects.Add(name, time);
                }

                // Type 2 Fraud
                if (record.ContainsKey(name))
                {
                    var previousRecord = record[name];

                    if ((time - previousRecord.Item2 < 60) && (!location.Equals(previousRecord.Item1)))
                    {
                        if (suspects.ContainsKey(name))
                        {
                            suspects[name] = Math.Min(previousRecord.Item2, suspects[name]);
                        }
                        else
                        {
                            suspects.Add(name, previousRecord.Item2);   
                        }
                    }

                    record[name] = new Tuple<string, int>(location, time);
                }
                else
                {
                    record.Add(name, new Tuple<string, int>(location, time));
                }
            }

            var suspectList = suspects.ToList();
            suspectList.Sort((s1, s2) => s1.Value.CompareTo(s2.Value));

            return suspectList.Select(s => s.Key).ToArray();
        }
    }
}
