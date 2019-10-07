using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GADETask2
{
  class FactoryBuilding :Building
  {
    public FactoryBuilding(int x, int y, int h, int f, string sy) : base(x, y, h, f, sy)
    {

    }
    private int productionSpeed;

    public int ProductionSpeed
    {
      get { return productionSpeed; }
      set { productionSpeed = value; }
    }
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


		public Unit UnitSpawn()
		{	
			Random random = new Random();
			double theD = random.NextDouble();
			double rand = random.NextDouble();
			int nextX = (rand < 0.732) ? -1 : 1;
			int nextY = (rand > 0.23) ? -1 : 1;
			if (theD < 0.5f)
			{
				return new MeleeUnit(xPos + nextX, yPos + nextY, 3, 5, 1, faction, "M");
			}
			else
			{
				return new RangedUnit(xPos + nextX, yPos + nextY, 30, 5, 1, 2, faction, "U");
			}
	    }
		public override void TakeDamage(int d)
		{
			health -= d;
			if (health < 0)
			{
				Destruction();
			}
		}
		public override bool isDead()
		{
			return destroyed;
		}
		public override void Destruction()
    {
			destroyed = true;
    }
    public override string ToString()
    {
			string temp = "";
			temp += symbol + "Forge ";
			temp += "Resource:";
			temp += "{" + Symbol + "}";
			temp += "(" + XPos + "," + YPos + ")";
			temp += "Heath:" + Health + ", ";
			temp += (isDead() ? " DEAD!" : ", ALIVE!");
			return temp;
		}
		public override void Save(StreamWriter writer)
		{
			string temp = "";
			temp += symbol + "Forge ";
			temp += "Resource:";
			temp += "{" + Symbol + "}";
			temp += ";" + XPos + ", " + YPos + ", ";
			temp += Health + ", ";
			temp += faction;
			writer.WriteLine(temp);
		}
	}
}
