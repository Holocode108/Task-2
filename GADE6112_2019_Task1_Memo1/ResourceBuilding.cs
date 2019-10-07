using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GADETask2
{
  class ResourceBuilding : Building
  {
    string minerals = "Tiberuim";
    int resourcesGenerated;
    int rpr = 2;
    int resourcePool = 100;


		public int XPos
		{
			get { return base.xPos; }
			set { base.xPos = value; }
		}
		public int YPos
		{
			get { return base.yPos; }
			set { base.yPos = value; }
		}

		public int Health
		{
			get { return base.health; }
			set { base.health = value; }
		}

		public int MaxHealth
		{
			get { return base.maxHealth; }
		}

		public int Faction
		{
			get { return base.faction; }
		}


		public string Symbol
		{
			get { return base.symbol; }
			set { base.symbol = value; }
		}

	public ResourceBuilding(int x, int y, int h, int f, string sy) :base(x,y,h,f,sy)
    {

		}
		public override void TakeDamage(int d)
		{
			health -= d;
			if (health < 0)
			{
				Destruction();
			}
		}


		public override void Destruction()
    {
			destroyed = true;
    }
		public override bool isDead()
		{
			return destroyed;
		}

		public override string ToString()
    {
			string temp = "";
			temp += symbol + "Mechanicum ";
			temp += "Resource:";
			temp += "{" + Symbol + "}";
			temp += "(" + XPos + "," + YPos + ")";
			temp += "Health " + Health + ", ";
			temp += (isDead() ? " DEAD!" : ", ALIVE!");
			return temp;
		}
	public int MineResource()
		{
			resourcesGenerated += rpr;

			resourcePool -= rpr;
			return (resourcePool > 0) ? rpr : 0;
		}
		public override void Save(StreamWriter writer)
		{
			string temp = "";
			temp += symbol + "Mechanicum ";
			temp += "Resource:";
			temp += "{" + Symbol + "}";
			temp += ";" + XPos + ", " + YPos + ", ";
			temp +=  Health + ", ";
			temp += faction;
			writer.WriteLine(temp);
		}

	}
}
