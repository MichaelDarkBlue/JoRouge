using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_Adventure
{
    public class NPC : Object
    {
        public int health;
        public int damage;
        public int defence;
        public int gold;
        public string name;
        public string type;
        public bool hostile;
        public bool quest;
        public int range;
        public int rangedA;
        public int lastX;
        public int lastY;
        public int speed;
        public NPC(int xI, int yI, int lastXI, int lastYI, string lookI, Color colorI, string nameI, int healthI, int damageI, int defenceI, int speedI, int goldI, string typeI, bool hostileI, int rangeI, int rangedAI, bool questI) : base(xI, yI, lookI, colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            name = nameI;
            health = healthI;
            damage = damageI;
            defence = defenceI;
            gold = goldI;
            type = typeI;
            hostile = hostileI;
            quest = questI;
            range = rangeI;
            rangedA = rangedAI;
            lastX = lastXI;
            lastY = lastYI;
            speed = speedI;
        }
        public static string randomType(string type)
        {
            Random r = new Random();
            if (r.Next(1, 15 + 1) == 1)
            {
                type = "King";
            }
            else if (r.Next(1, 10 + 1) == 1)
            {
                type = "Knight";
            }
            else if (r.Next(1, 8 + 1) == 1)
            {
                type = "Noble";
            }
            else if (r.Next(1, 8 + 1) == 1)
            {
                type = "Blacksmith";
            }
            else
            {
                type = "Peasant";
            }
            return type;
        }//End of randomType
        public static void npcMovement(NPC npc, List<Object> walls, List<Door> doors)
        {
            Random r = new Random();
            for (int i = 0; i < npc.speed; i++)
            {
                if (r.Next(1, 3 + 1) == 1)
                {
                    if (r.Next(1, 2 + 1) == 1)
                    {
                        npc.x += r.Next(0, 1 + 1);
                        npc.x -= r.Next(0, 1 + 1);
                    }
                    else
                    {
                        npc.y += r.Next(0, 1 + 1);
                        npc.y -= r.Next(0, 1 + 1);
                    }
                }
                for (int t = 0; t < walls.Count; t++)
                {
                    if (walls[t].x == npc.x & walls[t].y == npc.y)
                    {
                        npc.x = npc.lastX;
                        npc.y = npc.lastY;
                    }
                }
                for (int t = 0; t < doors.Count; t++)
                {
                    if (doors[t].x == npc.x & doors[t].y == npc.y)
                    {
                        if (doors[t].locked == true)
                        {
                            npc.x = npc.lastX;
                            npc.y = npc.lastY;
                        }
                    }
                } 
            }
        }//End of npcMovement
        public static void npcRangedAttack(NPC npc,List<Creature> creatures, Player player, Object arrow, List<Object> walls, int width, int height, System.Windows.Forms.TextBox messageBox)
        {
            //Ranged Attack
            if (npc.range > 0)
            {
                Random r = new Random();
                int random;
                int range = npc.range;
                bool hit = false;
                bool hitc = false;
                bool hitp = false;
                int creaturehit = 0;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }   
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                hit = false;
                range = npc.range;
                arrow.y = npc.y;
                arrow.x = npc.x;
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
                    for (int k = 0; k < creatures.Count; k++)
                    {
                        if (arrow.x == creatures[k].x & arrow.y == creatures[k].y)
                        {
                            hit = true;
                            hitc = true;
                            creaturehit = k;
                        }
                    }
                    range--;
                }
                if (hitc == true)
                {
                    if (player.reputation < 0 & hitp == true)
                    {
                        if (r.Next(0, 100 + 1) <= npc.rangedA)
                        {
                            random = r.Next(1, npc.damage + 1);
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
                            messageBox.Text = npc.name + " the " + npc.type + " shot you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                        }
                        else
                        {
                            messageBox.Text = npc.name + " the " + npc.type + "'s arrow missed you!" + Environment.NewLine + messageBox.Text;
                        }
                    }
                    else if (hitc == true)
                    {
                        if (r.Next(0, 100 + 1) <= npc.rangedA)
                        {
                            random = r.Next(1, npc.damage + 1);
                            if (creatures[creaturehit].defence > random)
                            {
                                if (r.Next(0, creatures[creaturehit].defence) + 1 > random)
                                {
                                    random = 0;
                                }
                            }
                            else
                            {
                                random -= creatures[creaturehit].defence;
                                if (random <= 0)
                                {
                                    random = 1;
                                }
                            }
                            creatures[creaturehit].health -= random;
                        }
                    }
                }
            }
        }//End of npcRangedAttack
        public static void npcMeleeAttack(NPC npc, Creature creature, Player player, System.Windows.Forms.TextBox messageBox)
        {
            if (npc.range <= 0)
            {
                Random r = new Random();
                int random;
                //Melee Attack against player
                if (npc.hostile == true & player.reputation < 0)
                {
                    if (player.x == npc.x & player.y == npc.y)
                    {
                        random = r.Next(1, npc.damage + 1);
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
                        messageBox.Text = npc.name + " the " + npc.type + " hit you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                    }
                }
                //Melee Attack against creature
                if (creature.x == npc.x & creature.y == npc.y)
                {
                    random = r.Next(1, npc.damage + 1);
                    if (creature.defence > random)
                    {
                        if (r.Next(0, creature.defence) + 1 > random)
                        {
                            random = 0;
                        }
                    }
                    else
                    {
                        random -= creature.defence;
                        if (random <= 0)
                        {
                            random = 1;
                        }
                    }
                    creature.health -= random;
                }
            }
        }//End of npcMeleeAttack
        public static void npcDead(NPC npc)
        {
            //Creature Dead Area
            if (npc.health <= 0)
            {
                npc.x = -20;
                npc.y = -20;
            }
        }//End of creatureDead
    }//End of NPC
}//End of namespace
