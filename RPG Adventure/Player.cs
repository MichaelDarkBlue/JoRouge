using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_Adventure
{
    public class Player : Entity
    {
        public int gold;
        public int health = 8;
        public int maxhealth = 8;
        public int damage = 1;
        public int defence;
        public int xp;
        public int xpul = 5;
        public int level = 1;
        public int lastX;
        public int lastY;
        public int skillp;
        public int rangeD;
        public int rangedR;
        public int rangedA;
        public int archery;
        public bool ranged;
        public int sight;
        public int reputation;
        public int theivery;
        public int creaturesKilled;
        public int itemsBought;
        public List<Item> inventory = new List<Item>();
        public Player()
            : base()
        {
        }
        public static void playerMovement(Player player, int keypressed)
        {
            //Player Movement
            //W = 87
            //A = 65
            //S = 83
            //D = 68
            //Arrow Up = 38
            //Arrow Down = 40
            //Arrow Right = 39
            //Arrow Left = 37
            //Numpad 7 = 103
            //Numpad 8 = 104
            //Numpad 9 = 105
            //Numpad 4 = 100
            //Numpad 5 = 101
            //Numpad 6 = 102
            //Numpad 1 = 97
            //Numpad 2 = 98
            //Numpad 3 = 99
            player.lastY = player.y;
            player.lastX = player.x;
            if (keypressed == 68)
            {
                player.x++;
            }
            if (keypressed == 65)
            {
                player.x--;
            }
            if (keypressed == 83)
            {
                player.y++;
            }
            if (keypressed == 87)
            {
                player.y--;
            }
        }
        public static void playerMeleeAttack(Creature creature, Player player, System.Windows.Forms.TextBox messageBox)
        {
            if (creature.x == player.x & creature.y == player.y)
            {
                Random r = new Random();
                int random;
                random = r.Next(1, player.damage + 1);
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
                messageBox.Text = "You hit " + creature.name + " for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                if (creature.health <= 0)
                {
                    player.creaturesKilled++;
                    string build;
                    build = "";
                    build = "You killed " + creature.name;
                    if (creature.xp > 0 | creature.gold > 0)
                    {
                        build += " and found ";
                        if (creature.xp > 0)
                        {
                            build += creature.xp + " xp";
                            player.xp += creature.xp;
                        }
                        if (creature.xp > 0 & creature.gold > 0)
                        {
                            build += " and ";
                        }
                        if (creature.gold > 0)
                        {
                            build += creature.gold + " gold";
                            player.gold += creature.gold;
                        }
                        random = r.Next(0, 2 + 1);
                        if (creature.drop != null & random == 1)
                        {
                            if (creature.xp > 0 | creature.gold > 0)
                            {
                                build += " and ";
                            }
                            build += "a " + creature.drop.name;
                            if ((player.inventory.Exists(x => x == creature.drop & x.stackable == true)))
                            {
                                for (int i = 0; i < player.inventory.Count; i++)
                                {
                                    if (player.inventory[i] == creature.drop)
                                    {
                                        player.inventory[i].count++;
                                    }
                                }
                            }
                            else
                            {
                                player.inventory.Add(creature.drop);
                            }
                        }
                    }
                    build += ".";
                    messageBox.Text = build + Environment.NewLine + messageBox.Text;
                    build = "";
                }
            }
        }//End of playerAttack
        public static void playerRangedAttack(List<Creature> creatures, Player player, Entity arrow, List<Entity> walls, int width, int height, System.Windows.Forms.TextBox messageBox, int keypressed)
        {
            //Player Ranged Weapons
            if (player.ranged == true)
            {
                for (int i = 0; i < player.inventory.Count; i++)
                {
                    if (player.inventory[i].name.Contains("Arrow"))
                    {
                        if (player.inventory[i].count > 1)
                        {
                            player.inventory[i].count--;
                        }
                        else
                        {
                            player.inventory.Remove(player.inventory[i]);
                        }
                        goto Done;
                    }
                }
            Done:
                int random;
                Random r = new Random();
                int creaturehit = 0;
                int range = player.rangedR;
                bool hit = false;
                bool hitc = false;
                if (keypressed == 104)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.y = player.y;
                        arrow.x = player.x;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 103)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.x = player.x;
                        arrow.y = player.y;
                        while (hit == false & range > 0)
                        {
                            arrow.x--;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 105)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.x = player.x;
                        arrow.y = player.y;
                        while (hit == false & range > 0)
                        {
                            arrow.x++;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 98)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.y = player.y;
                        arrow.x = player.x;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 100)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.y = player.y;
                        arrow.x = player.x;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 102)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.x = player.x;
                        arrow.y = player.y;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 97)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.x = player.x;
                        arrow.y = player.y;
                        while (hit == false & range > 0)
                        {
                            arrow.x--;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (keypressed == 99)
                {
                    if (player.inventory.Exists(x => x.name.Contains("Arrow")))
                    {
                        arrow.x = player.x;
                        arrow.y = player.y;
                        while (hit == false & range > 0)
                        {
                            arrow.x++;
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
                            for (int i = 0; i < walls.Count; i++)
                            {
                                if (arrow.x == walls[i].x & arrow.y == walls[i].y)
                                {
                                    hit = true;
                                }
                            }
                            for (int i = 0; i < creatures.Count; i++)
                            {
                                if (arrow.x == creatures[i].x & arrow.y == creatures[i].y)
                                {
                                    creaturehit = i;
                                    hit = true;
                                    hitc = true;
                                }
                            }
                            range--;
                        }
                    }
                    else
                    {
                        messageBox.Text = "You do not have any arrows." + Environment.NewLine + messageBox.Text;
                    }
                }
                if (hitc == true)
                {
                    if (r.Next(0, 100 + 1) <= player.rangedA)
                    {
                        random = r.Next(1, player.rangeD + 1);
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
                        messageBox.Text = "You shot " + creatures[creaturehit].name + " for " + random + " damage!" + Environment.NewLine + messageBox.Text;
                        if (creatures[creaturehit].health <= 0)
                        {
                            player.creaturesKilled++;
                            string build;
                            build = "";
                            build = "You killed " + creatures[creaturehit].name;
                            if (creatures[creaturehit].xp > 0 | creatures[creaturehit].gold > 0)
                            {
                                build += " and found ";
                                if (creatures[creaturehit].xp > 0)
                                {
                                    build += creatures[creaturehit].xp + " xp";
                                    player.xp += creatures[creaturehit].xp;
                                }
                                if (creatures[creaturehit].xp > 0 & creatures[creaturehit].gold > 0)
                                {
                                    build += " and ";
                                }
                                if (creatures[creaturehit].gold > 0)
                                {
                                    build += creatures[creaturehit].gold + " gold";
                                    player.gold += creatures[creaturehit].gold;
                                }
                                random = r.Next(0, 2 + 1);
                                if (creatures[creaturehit].drop != null & random == 1)
                                {
                                    if (creatures[creaturehit].xp > 0 | creatures[creaturehit].gold > 0)
                                    {
                                        build += " and ";
                                    }
                                    build += "a " + creatures[creaturehit].drop.name;
                                    player.inventory.Add(creatures[creaturehit].drop);
                                }
                            }
                            build += ".";
                            messageBox.Text = build + Environment.NewLine + messageBox.Text;
                            build = "";
                        }
                    }
                    else
                    {
                        messageBox.Text = "Your arrow missed " + creatures[creaturehit].name + "!" + Environment.NewLine + messageBox.Text;
                    }
                }
            }
        }//End of playerRangedAttack
    }//End of Player
}//End of namespace
