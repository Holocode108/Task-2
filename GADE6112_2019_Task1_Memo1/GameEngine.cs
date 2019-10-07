using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GADETask2
{
    public class GameEngine
    {
        Map map;
        private int round;
        Random r = new Random();
        GroupBox grpMap;
		private bool saving = false;

		private int FactionZeroR = 0;
		private int FactionOneR = 0;
		public int Round
        {
            get { return round; }
        }

        public GameEngine(int numUnits, int numBuilding, TextBox txtInfo, GroupBox gMap)
        {
            grpMap = gMap;
            map = new Map(numUnits, numBuilding, txtInfo);
            map.Generate();
            map.Display(grpMap);

            round = 1; 
        }

        public void Update()
        {
            for(int i = 0; i < map.Units.Count; i++)
            {
                if (map.Units[i] is MeleeUnit)
                {
                    MeleeUnit mu = (MeleeUnit)map.Units[i];
                    if (mu.Health <= mu.MaxHealth * 0.25) // Running Away
                    {
                        mu.Move(r.Next(0, 4));
                    }
                    else
                    {
                        (Unit closest, int distanceTo) = mu.Closest(map.Units);
						        (Building bclosest, int bdistance) = mu.Closest(map.Buildings);
                        //Check In Range
                        if (distanceTo <= mu.AttackRange)
                        {
                            mu.IsAttacking = true;
                            mu.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (mu.XPos > closestMu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestMu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestMu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestMu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (mu.XPos > closestRu.XPos) //North
                                {
                                    mu.Move(0);
                                }
                                else if (mu.XPos < closestRu.XPos) //South
                                {
                                    mu.Move(2);
                                }
                                else if (mu.YPos > closestRu.YPos) //West
                                {
                                    mu.Move(3);
                                }
                                else if (mu.YPos < closestRu.YPos) //East
                                {
                                    mu.Move(1);
                                }
                            }
                        }

                    }
                }
                else if (map.Units[i] is RangedUnit)
                {
                    RangedUnit ru = (RangedUnit)map.Units[i];
                   
                        (Unit closest, int distanceTo) = ru.Closest(map.Units);
                      
                        //Check In Range
                        if (distanceTo <= ru.AttackRange)
                        {
                            ru.IsAttacking = true;
                            ru.Combat(closest);
                        }
                        else //Move Towards
                        {
                            if (closest is MeleeUnit)
                            {
                                MeleeUnit closestMu = (MeleeUnit)closest;
                                if (ru.XPos > closestMu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestMu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestMu.YPos) //West
                                {
								
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestMu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                            else if (closest is RangedUnit)
                            {
                                RangedUnit closestRu = (RangedUnit)closest;
                                if (ru.XPos > closestRu.XPos) //North
                                {
                                    ru.Move(0);
                                }
                                else if (ru.XPos < closestRu.XPos) //South
                                {
                                    ru.Move(2);
                                }
                                else if (ru.YPos > closestRu.YPos) //West
                                {
                                    ru.Move(3);
                                }
                                else if (ru.YPos < closestRu.YPos) //East
                                {
                                    ru.Move(1);
                                }
                            }
                        }

                  //  }

                }
            }
			for (int i = 0; i < map.Buildings.Count; i++)
			{
				Building bitch = map.Buildings[i];
				if (bitch is ResourceBuilding)
				{
					ResourceBuilding bREE= (ResourceBuilding)bitch;
					
					switch (bREE.Faction)
					{
						case 0:
							{
								FactionZeroR += bREE.MineResource();
							}
							break;
						case 1:
							{
								FactionOneR += bREE.MineResource();
							}
							break;

						default: break;
					}

				}
				else if (bitch is FactoryBuilding)
				{ 
					FactoryBuilding bFac = (FactoryBuilding)bitch;
					int a = bFac.Faction;
					switch (a)
					{
						case 0:
							{
								if (FactionZeroR >= 6)
								{
									map.Units.Add(bFac.UnitSpawn());
								}
							}
							break;
						case 1:
							{
								if (FactionOneR >= 6)
								{
									map.Units.Add(bFac.UnitSpawn());
								}
							}
							break;

						default: break;
					}

				}
				else
				{
					Console.WriteLine("NANI THE FUCK YOU HERE FOR ");
				}
			}


            map.Display(grpMap);
            round++;
        }

        public int DistanceTo(Unit a, Unit b)
        {
            int distance = 0;

            if (a is MeleeUnit && b is MeleeUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is MeleeUnit)
            {
                RangedUnit start = (RangedUnit)a;
                MeleeUnit end = (MeleeUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is RangedUnit && b is RangedUnit)
            {
                RangedUnit start = (RangedUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            else if (a is MeleeUnit && b is RangedUnit)
            {
                MeleeUnit start = (MeleeUnit)a;
                RangedUnit end = (RangedUnit)b;
                distance = Math.Abs(start.XPos - end.XPos) + Math.Abs(start.YPos - end.YPos);
            }
            return distance;
        }
		public void TheProperSave()
		{
			StreamWriter units = new StreamWriter("Local_Unit_Save.txt");
			StreamWriter buildings = new StreamWriter("Local_Buildings_Save.txt");
			foreach(Unit u in map.Units)
			{
				if (u is RangedUnit)
				{
					RangedUnit uu = (RangedUnit)u;
					if (uu.IsDead)
						continue;
					uu.Save(units);
				}
				else
				{
					MeleeUnit uu = (MeleeUnit)u;
					if (uu.IsDead)
						continue;
					uu.Save(units);
				}
			}
			foreach (Building u in map.Buildings)
			{
				if (u is FactoryBuilding)
				{
					FactoryBuilding uu = (FactoryBuilding)u;
					if (uu.isDead())
						continue;
					uu.Save(buildings);
				}
				else
				{
					ResourceBuilding uu = (ResourceBuilding)u;
					if (uu.isDead())
						continue;
					uu.Save(buildings);
				}
			}
			units.Close();
			buildings.Close();
		}
		//Code given by Declan Porter
		public void DeclanFunctionalApproachToTheSaveFunction()
		{
			StreamWriter writer = new StreamWriter("Local_Save.txt");
			string Faction0 = "";
			string Faction1 = "";

			writer.WriteLine("START OF SAVE");
			foreach (Unit u in map.Units)
			{
				if (u is MeleeUnit)
				{
					MeleeUnit uu = (MeleeUnit)u;
					if (uu.Faction == 0)
					{
						Faction0 += uu.ToString() + "\n";
					}
					else
					{
						Faction1 += uu.ToString() + "\n";
					}
				}
				else if (u is RangedUnit)
				{
					RangedUnit uu = (RangedUnit)u;
					if (uu.Faction == 0)
					{
						Faction0 += uu.ToString() + "\n";
					}
					else
					{
						Faction1 += uu.ToString() + "\n";
					}
				}
			}
			writer.WriteLine("UNITS -- FACTION 0");
			writer.WriteLine(Faction0);
			writer.WriteLine("UNITS -- FACTION 1");
			writer.WriteLine(Faction1);
			Faction0 = "";
			Faction1 = "";
			foreach (Building u in map.Buildings)
			{
				if (u is ResourceBuilding)
				{
					ResourceBuilding uu = (ResourceBuilding)u;
					if (uu.Faction == 0)
					{
						Faction0 += uu.ToString() + "\n";
					}
					else
					{
						Faction1 += uu.ToString() + "\n";
					}
				}
				else if (u is FactoryBuilding)
				{
					FactoryBuilding uu = (FactoryBuilding)u;
					if (uu.Faction == 0)
					{
						Faction0 += uu.ToString() + "\n";
					}
					else
					{
						Faction1 += uu.ToString() + "\n";
					}
				}
			}

			writer.WriteLine("BUILDINGS-- FACTION 0");
			writer.WriteLine(Faction0);
			writer.WriteLine("BUILDINGS-- FACTION 1");
			writer.WriteLine(Faction1);
			writer.WriteLine("END OF SAVE");

		}
		public void ReadSave()
		{
			map.ReadSaveFile();
		}
    }
}
