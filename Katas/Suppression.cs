using System.Buffers.Text;
using System.Runtime.InteropServices;
using System.Threading.Channels;
using System.Xml.Linq;


namespace Katas
{
	internal class Suppression
	{
		//static void Main(string[] args)
		//{
		//	//Console.WriteLine("Hello, World!");
		//	//var node3 = new Node(10, new Node(1, null, null), new Node(2, null, null));
		//	//Console.WriteLine(BfsKata.SumTreeBFS(node3) == 13);

		//	//node3 = new Node(10, new Node(1, null, null), new Node(2, null, null));
		//	//var res = BfsKata.SumTreeDFS(node3);
		//	//Console.WriteLine($"{res == 13}, {res}");


		//	//ComputeDamage(25); 
		//	//Console.WriteLine();
		//	//Console.WriteLine();
		//	//ComputeDamage(50);

			

		//	Func<double, double> Lucky = (x) => 1.0 - (Math.Pow(1.0-x, 2));

		//	Console.WriteLine($"Lucky 40: {Lucky(0.4)}");


			

		//	for (double i = 0.05;i <= 1; i+=0.05)
		//	{
		//		var suppression = Math.Round(i, 2);
		//		var damageTaken = 1.0 - 0.5 * suppression;
		//		var damageMitigation = Math.Round(1.0-damageTaken, 2);
		//		Console.WriteLine($"{suppression} suppression results in {String.Format("{0:0}" ,damageTaken * 100)}% damage taken");

				
		//	}
		//	Console.WriteLine();
		//	Console.WriteLine();

		//	for (double i = 0.05; i <= 1; i += 0.05)
		//	{
		//		var suppression = Math.Round(i, 2);
		//		var damageTaken = 1.0 - 0.5 * suppression;
		//		var damageMitigation = Math.Round(1.0 - damageTaken, 2);
		//		//Console.WriteLine($"{suppression} suppression results in {damageMitigation * 100}% damage mitigation");
		//		var ehp = Math.Round(100.0 / damageTaken,2);
		//		var suppressionValue = (int)(suppression * 100);
		//		Console.WriteLine($"SuppressionValue now {suppressionValue}%.");
		//		Console.WriteLine($"EHP now {ehp}%.");
		//		var gainedEhp = (ehp - 100);
		//		var ehpGainPerSuppression = Math.Round( gainedEhp / suppressionValue,2);
		//		Console.WriteLine($"Ehp per point of suppression {ehpGainPerSuppression}%.");
		//		Console.WriteLine();
		//	}


			
		//}

		private static void ComputeDamage(int pen)
		{
			for (int i = 5; i <= 75; i += 5)
			{
				var ratio = Math.Round(flipEle(i, pen), 2);

				var dmg = String.Format("{0:0}", (ratio * 100));
				Console.WriteLine($"Deal {dmg}% Of Damage against {i}% res, compared to having {pen} pen.");

				if (Int32.Parse(dmg) > (100 - i))
				{
					Console.WriteLine($"Beats dealing {(100 - i)}% damage.");
				}
				Console.WriteLine();

				// i=25 => 87% : (75+75+75+125) / ((75+25)*4) 
				// i=50 => 100% : (50+50+50+150) / ((50+25)*4)
				// i=75 => 125% : (25+25+25+175) / ((25+25)*4)
			}
		}

		private static double flipEle(int monsterRes, int pen) {
			if (monsterRes > 75) 
			{
				return -1;
			}

			double chance = 0.25;
			double recip_chance = 1 - chance;

			double freq = 1 / chance;


			double acc = 0.0;
			acc += (recip_chance * freq) * (100 - monsterRes);
			acc += (chance * freq) * (100 + monsterRes);


			var norm = (100-monsterRes + pen)*freq;

			return acc / norm;
			}
	}
}