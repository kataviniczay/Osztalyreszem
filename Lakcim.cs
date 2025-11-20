using System;
namespace Projektkonzol
{
	public class Lakcim
	{
		public string Iranyitoszam { get; set; }
		public string Varos { get; set; }
		public string UtcaHazszam { get; set; }

		public Lakcim(string[] tomb)
		{
			Iranyitoszam = tomb[0];
			Varos = tomb[1];
			UtcaHazszam = tomb[2];
		}
	}
}

