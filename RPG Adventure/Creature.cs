using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_Adventure
{
    public class Creature : Entity
    {
        public int gold;
        public int health;
        public int damage;
        public int defence;
        public int xp;
        public int lastX;
        public int lastY;
        public string ai;
        public string name;
        public int range;
        public int rangedA;
        public int speed;
        public Item drop;
        public Creature(string nameI, string lookI, Color colorI, int healthI, int damageI, int defenceI, int speedI, int xpI, int goldI, string aiI, int xI, int yI, int lastXI, int lastYI, int rangeI, int rangedAI, Item dropI = null)
            : base(xI, yI, lookI, colorI)
        {
            if (dropI != null)
            {
                drop = dropI;
            }
            rangedA = rangedAI;
            range = rangeI;
            name = nameI;
            look = lookI;
            health = healthI;
            damage = damageI;
            defence = defenceI;
            xp = xpI;
            gold = goldI;
            ai = aiI;
            x = xI;
            y = yI;
            lastX = lastXI;
            lastY = lastYI;
            speed = speedI;
        }
        public static void creatureMovement(Creature creature, Player player, List<NPC> npcs, List<Entity> walls, List<Door> doors, Random r)
        {
            int moveX = 0, moveY = 0;
            Creature.closestEnemy(creature, player, npcs, out moveX, out moveY);
            for (int i = 0; i < creature.speed; i++)
            {
                creature.lastX = creature.x;
                creature.lastY = creature.y;
                if (creature.ai == "Default")
                {
                    //Random Movement
                    if (r.Next(0, 5 + 1) <= 2)
                    {
                        if (r.Next(0, 1 + 1) == 1)
                        {
                            creature.x += r.Next(0, 1 + 1);
                            creature.x -= r.Next(0, 1 + 1);
                        }
                        else
                        {
                            creature.y += r.Next(0, 1 + 1);
                            creature.y -= r.Next(0, 1 + 1);
                        }
                    }
                    else if (r.Next(0, 1 + 1) == 1)
                    {
                        if (moveY > creature.y)
                        {
                            creature.y++;
                        }
                        else if (moveY < creature.y)
                        {
                            creature.y--;
                        }
                    }
                    else
                    {
                        if (moveX > creature.x)
                        {
                            creature.x++;
                        }
                        else if (moveX < creature.x)
                        {
                            creature.x--;
                        }
                    }
                }
                if (creature.ai == "Zombie")
                {
                    //Random Movement
                    if (r.Next(0, 1 + 1) == 1)
                    {
                        if (moveY > creature.y)
                        {
                            creature.y++;
                        }
                        else if (moveY < creature.y)
                        {
                            creature.y--;
                        }
                    }
                    else
                    {
                        if (moveX > creature.x)
                        {
                            creature.x++;
                        }
                        else if (moveX < creature.x)
                        {
                            creature.x--;
                        }
                    }
                }
                for (int t = 0; t < walls.Count; t++)
                {
                    if (walls[t].x == creature.x & walls[t].y == creature.y)
                    {
                        creature.x = creature.lastX;
                        creature.y = creature.lastY;
                    }
                }
                for (int t = 0; t < doors.Count; t++)
                {
                    if (doors[t].x == creature.x & doors[t].y == creature.y)
                    {
                        if (doors[t].locked == true)
                        {
                            creature.x = creature.lastX;
                            creature.y = creature.lastY;
                        }
                    }
                }
            }
        }//End of creatureMovement
        public static void creatureRangedAttack(Creature creature, Player player, List<NPC> npcs, Entity arrow, List<Entity> walls, int width, int height, System.Windows.Forms.TextBox messageBox, Random r)
        {
            //Ranged Attack
            if (creature.range > 0)
            {
                int random;
                int range = creature.range;
                bool hit = false;
                bool hitnpc = false;
                bool hitp = false;
                int creaturehit = 0;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y--;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y++;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.x++;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.x--;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y--;
                    arrow.x--;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y--;
                    arrow.x++;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y++;
                    arrow.x--;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = creature.range;
                arrow.y = creature.y;
                arrow.x = creature.x;
                while (hit == false & range > 0)
                {
                    arrow.y++;
                    arrow.x++;
                    if (arrow.y < 0)
                    {
                        hit = true;
                    }
                    if (arrow.x > width)
                    {
                        hit = true;
                    }
                    if (arrow.y > height)
                    {
                        hit = true;
                    }
                    if (arrow.x < 0)
                    {
                        hit = true;
                    }
                    for (int k = 0; k < walls.Count; k++)
                    {
                        if (arrow.x == walls[k].x & arrow.y == walls[k].y)
                        {
                            hit = true;
                        }
                    }
                    if (arrow.x == player.x & arrow.y == player.y)
                    {
                        hit = true;
                        hitp = true;
                    }
                    for (int k = 0; k < npcs.Count; k++)
                    {
                        if (arrow.x == npcs[k].x & arrow.y == npcs[k].y)
                        {
                            hit = true;
                            hitnpc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                if (hitp == true)
                {
                    if (r.Next(0, 100 + 1) <= creature.rangedA)
                    {
                        random = r.Next(1, creature.damage + 1);
                        if (player.defence > random)
                        {
                            if (r.Next(0, player.defence) + 1 > random)
                            {
                                random = 0;
                            }
                        }
                        else
                        {
                            random -= player.defence;
                            if (random <= 0)
                            {
                                random = 1;
                            }
                        }
                        player.health -= random;
                        messageBox.Text = creature.name + " shot you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                    }
                    else
                    {
                        messageBox.Text = creature.name + "'s arrow missed you!" + Environment.NewLine + messageBox.Text;
                    }
                    if (hitnpc == true)
                    {
                        if (r.Next(0, 100 + 1) <= creature.rangedA)
                        {
                            random = r.Next(1, creature.damage + 1);
                            if (npcs[creaturehit].defence > random)
                            {
                                if (r.Next(0, npcs[creaturehit].defence) + 1 > random)
                                {
                                    random = 0;
                                }
                            }
                            else
                            {
                                random -= npcs[creaturehit].defence;
                                if (random <= 0)
                                {
                                    random = 1;
                                }
                            }
                            npcs[creaturehit].health -= random;
                        }
                    }
                }
            }
        }//End of creatureRangedAttack
        public static void creatureMeleeAttack(Creature creature, Player player, List<NPC> npcs, System.Windows.Forms.TextBox messageBox, Random r)
        {
            if (creature.range <= 0)
            {
                int random;
                //Melee Attack against player
                if (player.x == creature.x & player.y == creature.y)
                {
                    random = r.Next(1, creature.damage + 1);
                    if (player.defence > random)
                    {
                        if (r.Next(0, player.defence) + 1 > random)
                        {
                            random = 0;
                        }
                    }
                    else
                    {
                        random -= player.defence;
                        if (random <= 0)
                        {
                            random = 1;
                        }
                    }
                    player.health -= random;
                    messageBox.Text = creature.name + " hit you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                }
                //Melee Attack against npc
                for (int i = 0; i < npcs.Count; i++)
                {
                    if (npcs[i].x == creature.x & npcs[i].y == creature.y)
                    {
                        random = r.Next(1, creature.damage + 1);
                        if (npcs[i].defence > random)
                        {
                            if (r.Next(0, npcs[i].defence) + 1 > random)
                            {
                                random = 0;
                            }
                        }
                        else
                        {
                            random -= npcs[i].defence;
                            if (random <= 0)
                            {
                                random = 1;
                            }
                        }
                        npcs[i].health -= random;
                    }
                }
            }
        }//End of creatureMeleeAttack
        public static void creatureDead(Creature creature)
        {
            //Creature Dead Area
            if (creature.health <= 0)
            {
                creature.x = -10;
                creature.y = -10;
            }
        }//End of creatureDead
        public static void closestEnemy(Creature creature, Player player, List<NPC> npcs, out int moveX, out int moveY)
        {
            moveX = player.x;
            moveY = player.y;
            for (int i = 0; i < npcs.Count; i++)
			{
			    if (npcs[i].x < moveX & npcs[i].y < moveY)
                {
                    moveX = npcs[i].x;
                    moveY = npcs[i].y;
                }
			}
        }//End of closestEnemy
        public static Creature randomCreature(int lvlmod, out Creature rCreature, Random r)
        {
            rCreature = null;
            int random = r.Next(1, 4 + 1);
            if (random == 1)
            {
                rCreature = new Creature("Lynx", "l", Color.Tan, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 1 + lvlmod), 0, "Default", 0, 0, 0, 0, 0, 0, new Item("Lynx Fur", 0, 0, 2, 0, true, 1, 0, false, "Hand", true, "|", 0, 0));
            }
            else if (random == 2)
            {
                Item drop = null;
                if (r.Next(0, 5 + 1) == 1)
                {
                    drop = new Item("Orc Sword", r.Next(1, 1 + lvlmod), 0, r.Next(1, 4 + lvlmod), 0, false, 1, 0, false, "Hand", true, "/", 0, 0);
                }
                else if (r.Next(0, 5 + 1) == 1)
                {
                    drop = new Item("Orc Shield", 0, r.Next(1, 1 + lvlmod), r.Next(1, 4 + lvlmod), 0, false, 1, 0, false, "Shield", true, "O", 0, 0);
                }
                rCreature = new Creature("Orc", "o", Color.Green, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), 1, r.Next(1, 3 + lvlmod), r.Next(1, 2 + lvlmod), "Default", 0, 0, 0, 0, 0, 0, drop);
            }
            else if (random == 3)
            {
                rCreature = new Creature("Zombie", "Z", Color.LightGreen, r.Next(1, 3 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), "Zombie", 0, 0, 0, 0, 0, 0, new Item("Zombie Flesh", 0, 0, 1, 0, true, 1, r.Next(1, 1 + lvlmod), false, "Hand", true, "K", 0, 0));
            }
            else if (random == 4)
            {
                Item drop = null;
                if (r.Next(0, 5 + 1) == 1)
                {
                    drop = new Item("Orc Crossbow", r.Next(1, 1 + lvlmod), 0, r.Next(1, 1 + lvlmod), 0, false, 1, 0, false, "Hand", true, "C", r.Next(3, 8), r.Next(10, 50 + lvlmod));
                }
                else if (r.Next(0, 5 + 1) == 1)
                {
                    drop = new Item("Orc Leather Armor", 0, r.Next(1, 1 + lvlmod), r.Next(1, 4 + lvlmod), 0, false, 1, 0, false, "Armor", true, "H", 0, 0);
                }
                else if (r.Next(0, 5 + 1) == 1)
                {
                    drop = new Item("Orc Arrows", 0, 0, r.Next(1, 1 + lvlmod), 0, true, r.Next(1, 100 + 1), 0, false, "Hand", true, "-", 0, 0);
                }
                rCreature = new Creature("Orc Archer", "a", Color.Green, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 4 + lvlmod), r.Next(1, 2 + lvlmod), "Default", 0, 0, 0, 0, r.Next(3, 8), r.Next(10, 50 + lvlmod), drop);
            }
            //Creatures after THIS only appear on later levels than 1
            if (lvlmod >= 2 & r.Next(1, 4 + 1) == 1)
            {
                Item drop = null;
                int mod = lvlmod - 2;
                if (r.Next(1, 2 + 1) == 1)
                {
                    drop = new Item("Fox Fur", 0, 0, r.Next(3, 3 + mod), 0, true, r.Next(1, 3), 0, false, "Hand", true, "|", 0, 0);
                }
                else
                {
                    drop = new Item("Fox Meat", 0, 0, 3, 0, true, r.Next(1, 3), r.Next(3, 3 + mod), false, "Hand", true, "K", 0, 0);
                }
                rCreature = new Creature("Fox", "f", Color.Crimson, r.Next(1, 1 + mod), r.Next(3, 3 + mod), 0, 2, r.Next(2, 2 + mod), 0, "Default", 0, 0, 0, 0, 0, 0, drop);
            }
            if (lvlmod == 5 & r.Next(1, 3 + 1) == 1)
            {
                Item drop = null;
                int mod = lvlmod - 5;
                rCreature = new Creature("Mosquitos", "m", Color.Gray, r.Next(15, 15 + mod), r.Next(1, 1 + mod), r.Next(3, 6 + mod), 3, r.Next(5, 5 + mod), 0, "Default", 0, 0, 0, 0, 0, 0, drop);
            }
            //First Truly Hard Enemy
            if (lvlmod == 4 & r.Next(1, 6 + 1) == 1)
            {
                Item drop = null;
                int mod = lvlmod - 4;
                if (r.Next(1, 2 + 1) == 1)
                {
                    drop = new Item("Giant Sword", r.Next(3, 6 + mod), 0, r.Next(9, 13), 0, true, 1, 0, false, "Hand", true, "/", 0, 0);
                }
                else
                {
                    drop = new Item("Giant Armor", 0, r.Next(3, 3 + mod), r.Next(7, 15 + mod), 0, true, 1, 3, false, "Hand", true, "M", 0, 0);
                }
                rCreature = new Creature("Giant", "G", Color.Green, r.Next(8, 10 + mod), r.Next(3, 6 + mod), r.Next(3, 3 + mod), 1, r.Next(10, 18 + mod), r.Next(12, 20 + mod), "Zombie", 0, 0, 0, 0, 0, 0, drop);
            }
            //LOL Troller - Special Rare Creature
            if (r.Next(1, 50 + 1) == 1)
            {
                rCreature = new Creature("LOL Troller", "t", Color.Red, 100, 100, 100, 8, 100, 100, "Zombie", 0, 0, 0, 0, 0, 0, new Item("Joke", 0, 0, 0, 0, false, 1, 0, false, "Hand", true, "j", 0, 0));
            }
            return rCreature;
        }
    }//End of Creature
}//End of namespace
