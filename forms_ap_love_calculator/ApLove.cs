using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Threading.Tasks;
using Lamp.Plugin;

namespace Core
{
	public class ApLove
	{
		public static int Iterations { get; set; }

		public static string ToNumber(string person1name, string person2name)
		{
			if (string.IsNullOrWhiteSpace(person1name) || string.IsNullOrWhiteSpace(person2name))
			{
				return "Please enter two names";
			}
			else
			{
				person1name = person1name.ToUpperInvariant();
				person2name = person2name.ToUpperInvariant();
			}

			var combinedName = new StringBuilder();

			combinedName.Append(person1name);
			combinedName.Append(person2name);

			var loveResult = new StringBuilder();

			foreach (var c in "LOVES")
			{
				int count = combinedName.ToString().Split(c).Length - 1;
				loveResult.Append(count);
			}
			Iterations = 1;
			return TranslateToPercentage(loveResult.ToString());
		}

		static string TranslateToPercentage(string loveResult)
		{
			var newLoveResult = new StringBuilder();
			int PreviousNumber = -1;
			foreach (var i in loveResult)
			{
				if (PreviousNumber >= 0)
				{
					var sum = PreviousNumber + int.Parse(i.ToString());

					newLoveResult.Append(sum);
				}
				PreviousNumber = int.Parse(i.ToString());
			}
			Iterations = Iterations + 1;
			if (Iterations < 20 && newLoveResult.ToString().Length > 2)
			{
				return TranslateToPercentage(newLoveResult.ToString());
			}
			else if (Iterations == 20)
			{
				return "infinity";
			}
			return newLoveResult.ToString();
		}
	}
}
