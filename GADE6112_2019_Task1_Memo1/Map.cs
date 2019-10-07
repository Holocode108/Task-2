using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
namespace GADETask2
{
    public class Map
    {
        List<Unit> units;
		    List<Building> building;
        Random r = new Random();
        int numUnits = 0;
		    int numBuilding = 0;
        TextBox txtInfo;

        public List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

		public List<Building> Buildings
		{
			get { return building; }
			set { building = value; }
		}

		public Map(int n, int nb, TextBox txt)
        {
            units = new List<Unit>();
			      building = new List<Building>();
            numUnits = n;
			      numBuilding = nb;
			      txtInfo = txt;
        }

        public void Generate()
        {
            for(int i = 0; i < numBuilding; i++)
            {
      
			   if (r.Next(0,2) == 0)
				 {
					building.Add(new FactoryBuilding(r.Next(0, 20),r.Next(0, 20),3,(i % 2 == 0 ? 1 : 0),"F"));

				 }
			   else
				 {
					building.Add(new ResourceBuilding(r.Next(0, 20),r.Next(0, 20),3,(i % 2 == 0 ? 1 : 0),"R"));
				 }

            }
        }

        public void Display(GroupBox groupBox)
        {
            groupBox.Controls.Clear();
            foreach(Unit u in units)
            {
                Button b = new Button();
                if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(mu.XPos * 20, mu.YPos * 20);
                    b.Text = mu.Symbol;
                    if (mu.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                else
                {
                    RangedUnit ru = (RangedUnit)u;
                    b.Size = new Size(20, 20);
                    b.Location = new Point(ru.XPos * 20, ru.YPos * 20);
                    b.Text = ru.Symbol;
                    if (ru.Faction == 0)
                    {
                        b.ForeColor = Color.Red;
                    }
                    else
                    {
                        b.ForeColor = Color.Green;
                    }
                }
                b.Click += Unit_Click;
                groupBox.Controls.Add(b);
            }
			foreach (Building b in building)
			{
				Button button = new Button();
				if (b is FactoryBuilding)
				{
					FactoryBuilding bb = (FactoryBuilding)b;
					button.Size = new Size(20, 20);
					button.Location = new Point(bb.XPos * 20, bb.YPos * 20);
					button.Text = bb.Symbol;
					if (bb.Faction == 0)
					{
						button.ForeColor = Color.Red;
					}
					else
					{
						button.ForeColor = Color.Green;
					}
				}
				else
				{
					ResourceBuilding rb = (ResourceBuilding)b;
					button.Size = new Size(20, 20);
					button.Location = new Point(rb.XPos * 20, rb.YPos * 20);
					button.Text = rb.Symbol;
					if (rb.Faction == 0)
					{
						button.ForeColor = Color.Red;
					}
					else
					{
						button.ForeColor = Color.Green;
					}
				}
				button.Click += Unit_Click;
				groupBox.Controls.Add(button);
			}
        }

        public void Unit_Click(object sender, EventArgs e)
        {
            int x, y;
            Button b = (Button)sender;
            x = b.Location.X / 20;
            y = b.Location.Y / 20;
            foreach(Unit u in units)
            {
                if (u is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)u;
                    if (ru.XPos == x && ru.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = ru.ToString();
                    }
                }
                else if (u is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)u;
                    if (mu.XPos == x && mu.YPos == y)
                    {
                        txtInfo.Text = "";
                        txtInfo.Text = mu.ToString();
                    }
                }
            }
			foreach (Building bu in building)
			{
				if (bu is ResourceBuilding)
				{
					ResourceBuilding ru = (ResourceBuilding)bu;
					if (ru.XPos == x && ru.YPos == y)
					{
						txtInfo.Text = "";
						txtInfo.Text = ru.ToString();
					}
				}
				else if (bu is FactoryBuilding)
				{
					FactoryBuilding mu = (FactoryBuilding)bu;
					if (mu.XPos == x && mu.YPos == y)
					{
						txtInfo.Text = "";
						txtInfo.Text = mu.ToString();
					}
				}
			}
		}
		public void ReadSaveFile()
		{
			Units.Clear();
			Buildings.Clear();
			StreamReader unit = new StreamReader("Local_Unit_Save.txt");
			StreamReader build = new StreamReader("Local_Buildings_Save.txt");
			while (!unit.EndOfStream)
			{
				string line = unit.ReadLine();
				if (line.Contains("{U}"))
				{
					
					string remaining = line.Split(';')[1];
					string []arr = remaining.Split(',');
					int x = int.Parse(arr[0]);
					int y = int.Parse(arr[1]);					
					int h = int.Parse(arr[2]);
					int s = int.Parse(arr[3]);
					int a = int.Parse(arr[4]);
					int ar = int.Parse(arr[5]);
					int f = int.Parse(arr[6]);
					units.Add(new RangedUnit(x, y, h, s, a, ar, f, "U"));
				}
				else
				{
					string remaining = line.Split(';')[1];
					string[] arr = remaining.Split(',');
					int x = int.Parse(arr[0]);
					int y = int.Parse(arr[1]);
					int h = int.Parse(arr[2]);
					int s = int.Parse(arr[3]);
					int a = int.Parse(arr[4]);
					int ar = int.Parse(arr[5]);
					int f = int.Parse(arr[6]);
					units.Add(new MeleeUnit(x, y, h, s, a, f, "M"));
				}
			}
			while (!build.EndOfStream)
			{
				string line = build.ReadLine();
				if (line.Contains("{F}"))
				{

					string remaining = line.Split(';')[1];
					string[] arr = remaining.Split(',');
					int x = int.Parse(arr[0]);
					int y = int.Parse(arr[1]);
					int h = int.Parse(arr[2]);
					int f = int.Parse(arr[3]);
					building.Add(new FactoryBuilding(x, y, h, f, "F"));
				}
				else
				{
					string remaining = line.Split(';')[1];
					string[] arr = remaining.Split(',');
					int x = int.Parse(arr[0]);
					int y = int.Parse(arr[1]);
					int h = int.Parse(arr[2]);
					int f = int.Parse(arr[3]);
					building.Add(new FactoryBuilding(x, y, h, f, "R"));
				}
			}
			
		}
    }
}
