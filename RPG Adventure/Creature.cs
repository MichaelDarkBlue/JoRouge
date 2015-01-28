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
        public static void creatureMovement(Creature creature, Player player, List<NPC> npcs, List<Entity> walls, List<Door> doors)
        {
            Random r = new Random();
            creature.lastX = creature.x;
            creature.lastY = creature.y;
            int moveX = 0, moveY = 0;
            Creature.closestEnemy(creature, player, npcs, out moveX, out moveY);
            for (int i = 0; i < creature.speed; i++)
            {
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
                    if (walls[i].x == creature.x & walls[i].y == creature.y)
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
        public static void creatureRangedAttack(Creature creature, Player player, List<NPC> npcs, Entity arrow, List<Entity> walls, int width, int height, System.Windows.Forms.TextBox messageBox)
        {
            //Ranged Attack
            if (creature.range > 0)
            {
                Random r = new Random();
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
                if (hitnpc == true)
                {
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
                    }
                    else if (hitnpc == true)
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
        public static void creatureMeleeAttack(Creature creature, Player player, List<NPC> npcs, System.Windows.Forms.TextBox messageBox)
        {
            if (creature.range <= 0)
            {
                Random r = new Random();
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
    }//End of Creature
}//End of namespace
