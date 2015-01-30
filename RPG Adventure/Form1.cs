using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG_Adventure
{
    public partial class Form1 : Form
    {
        private List<Entity> walls = new List<Entity>();
        private List<Entity> trees = new List<Entity>();
        private List<Merchant> merchants = new List<Merchant>();
        private List<Creature> creatures = new List<Creature>();
        private List<Door> doors = new List<Door>();
        private List<Chest> chests = new List<Chest>();
        private Player player = new Player();
        private List<Item> merchantI = new List<Item>();
        private Entity downstairs = new Entity(0, 0, ">", Color.LightGray);
        private Entity upstairs = new Entity(0, 0, "<", Color.LightGray);
        private Entity arrow = new Entity(0, 0, "-", Color.BurlyWood);
        private List<NPC> npcs = new List<NPC>();
        Random r = new Random();
        int width = 30;
        int height = 30;
        int dlevel = 0;
        int worldX;
        int worldY;
        int lvlmod;
        int random;
        bool inDungeon = false;
        bool firstTime = true;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (inDungeon == true)
            {
                dungeon();
            }
            else
            {
                overworld();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            messageBox.Text = "";
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            SkillPanel sp = new SkillPanel(player);
            sp.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory(player);
            inv.Show();
            game(0);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            firstTime = true;
            overworld();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Current_Quests cq = new Current_Quests(player);
            cq.Show();
        }
        private void outputBox_KeyUp(object sender, KeyEventArgs e)
        {
            int keypressed = (int)e.KeyCode;
            game(keypressed);
        }
        private void overworld()
        {
            //Set to None
            if (firstTime)
            {
                player.inventory = new List<Item>();
            }
            trees = new List<Entity>();
            doors = new List<Door>();
            creatures = new List<Creature>();
            chests = new List<Chest>();
            walls = new List<Entity>();
            merchants = new List<Merchant>();
            merchantI = new List<Item>();
            npcs = new List<NPC>();
            upstairs = new Entity(-2, 0, "<", Color.LightGray);
            downstairs = new Entity(-2, 0, ">", Color.LightGray);
            if (firstTime)
            {
                messageBox.Text = "";
                worldX = 0;
                worldY = 0;
            }
            //Setup
            if (worldX < 0)
            {
                lvlmod = worldX * -1;
            }
            else
            {
                lvlmod = worldX;
            }
            if (worldY < 0)
            {
                lvlmod += worldY * -1;
            }
            else
            {
                lvlmod += worldY;
            }
            //Overworld Generation
            //Buildings
            bool town = false;
            if (firstTime)
            {
                town = true;
            }
            if (r.Next(1, 8 + 1) == 1)
            {
                town = true;
            }
            int rooms = 0;
            int x;
            int y;
            int placeX;
            int placeY;
            int stage;
            int part;
            bool hole;
            if (town)
            {
                rooms = r.Next(3, 8 + 1);
            }
            else if (r.Next(1, 8 + 1) == 1)
            {
                rooms = r.Next(1, 2 + 1);
            }
            for (int i = 0; i < rooms; i++)
            {
                x = r.Next(7, width - 7 + 1);
                y = r.Next(7, height - 7 + 1);
                placeX = x - 1;
                placeY = y - 1;
                random = r.Next(4, 6 + 1);
                stage = 0;
                part = 0;
                hole = false;
                for (int t = 0; t < random + (random + 2 * (random - 1) + random - 2); t++)
                {
                    if (stage == 0)
                    {
                        if (part != random + 1)
                        {
                            placeX++;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 1;
                            part = 0;
                        }
                    }
                    if (stage == 1)
                    {
                        if (part != random)
                        {
                            placeY--;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 2;
                            part = 0;
                        }
                    }
                    if (stage == 2)
                    {
                        if (part != random)
                        {
                            placeX--;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 3;
                            part = 0;
                        }
                    }
                    if (stage == 3)
                    {
                        if (part != random - 1)
                        {
                            placeY++;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            if (hole != true & part == random - 2)
                            {
                                doors.Add(new Door(placeX, placeY, "O", Color.BurlyWood, false));
                            }
                            part++;
                        }
                        else
                        {
                            stage = 4;
                            part = 0;
                        }
                    }
                }
            }
            //Chests
            random = 0;
            if (r.Next(1, 4 + 1) == 1 | town)
            {
                random = r.Next(1, 5 + 1);
            }
            for (int i = 0; i < random; i++)
            {
            RetryChest:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryChest;
                    }
                }
                chests.Add(new Chest(placeX, placeY, "Œ", Color.BurlyWood, false));
            }
            //Creatures
            random = 0;
            if (town == false)
            {
                random = r.Next(3, 10 + 1);
            }
            else if (town)
            {
                random = r.Next(0, 2 + 1);
            }
            for (int i = 0; i < random; i++)
            {
            RetryCreature:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryCreature;
                    }
                }
                int l = r.Next(1, 4 + 1);
                if (l == 1)
                {
                    creatures.Add(new Creature("Lynx", "l", Color.Tan, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 1 + lvlmod), 0, "Default", placeX, placeY, placeX, placeY, 0, 0, new Item("Lynx Fur", 0, 0, 2, 0, true, 1, 0, false, "Hand", true, "|", 0, 0)));
                }
                else if (l == 2)
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
                    creatures.Add(new Creature("Orc", "o", Color.Green, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), 1, r.Next(1, 3 + lvlmod), r.Next(1, 2 + lvlmod), "Default", placeX, placeY, placeX, placeY, 0, 0, drop));
                }
                else if (l == 3)
                {
                    creatures.Add(new Creature("Zombie", "Z", Color.LightGreen, r.Next(1, 3 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), "Zombie", placeX, placeY, placeX, placeY, 0, 0, new Item("Zombie Flesh", 0, 0, 1, 0, true, 1, r.Next(1, 1 + lvlmod), false, "Hand", true, "K", 0, 0)));
                }
                else if (l == 4)
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
                    creatures.Add(new Creature("Orc Archer", "a", Color.Green, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 4 + lvlmod), r.Next(1, 2 + lvlmod), "Default", placeX, placeY, placeX, placeY, r.Next(3, 8), r.Next(10, 50 + lvlmod), drop));
                }
            }
            //Merchants
            random = 0;
            if (r.Next(1, 5 + 1) == 1 | town)
            {
                random = r.Next(1, 3 + 1);
            }
            for (int i = 0; i < random; i++)
            {
            RetryMerchant:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryMerchant;
                    }
                }
                merchantI = new List<Item>();
                int p = r.Next(1, 5 + 1);
                for (int g = 0; g < p; g++)
                {
                    Item rItem = randomItem(rItem = new Item("", 0, 0, 0, 0, false, 0, 0, false, "", false, "", 0, 0));
                    merchantI.Add(rItem);
                }
                string name = randomName(name = "");
                merchants.Add(new Merchant(placeX, placeY, "☻", Color.Wheat, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), name, r.Next(0, 1 + lvlmod), r.Next(0, 2 + lvlmod), merchantI));
            }
            //NPCs
            random = 0;
            if (town)
            {
                random = r.Next(5, 15 + 1);
            }
            for (int i = 0; i < random; i++)
            {
            RetryNPC:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryNPC;
                    }
                }
                bool quest;
                if (r.Next(1, 4 + 1) == 1)
                {
                    quest = true;
                }
                else
                {
                    quest = false;
                }
                string name = randomName(name = "");
                string type = "";
                NPC.randomType(type, r);
                npcs.Add(new NPC(placeX, placeY, placeX, placeY, "☺", Color.Wheat, name, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 1 + lvlmod), 1, r.Next(0, 2 + lvlmod), NPC.randomType(name, r), false, r.Next(1, 8 + 1), r.Next(10, 100 + 1), quest));
            }
            //Tree Placement
            random = r.Next(40, 80 + 1);
            for (int i = 0; i < random; i++)
            {
            RetryTree:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryTree;
                    }
                }
                if (r.Next(1, 2 + 1) == 1)
                {
                    trees.Add(new Entity(placeX, placeY, "♣", Color.ForestGreen));
                }
                else
                {
                    trees.Add(new Entity(placeX, placeY, "♠", Color.ForestGreen));
                }
            }
        //Stair Placement
            if (r.Next(1, 2 + 1) == 1)
            {
        RetryStair:
                downstairs.x = r.Next(0, width + 1);
                downstairs.y = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (downstairs.x == walls[t].x & downstairs.y == walls[t].y)
                    {
                        goto RetryStair;
                    }
                }
            }
        //Player Placement
        RetryPlayer:
            player.x = r.Next(0, width + 1);
            player.y = r.Next(0, height + 1);
            for (int t = 0; t < walls.Count; t++)
            {
                if (player.x == walls[t].x & player.y == walls[t].y)
                {
                    goto RetryPlayer;
                }
            }
            //End of Overworld Generation
            //Player Setup
            if (firstTime)
            {
                player.inventory.Add(new Item("Bread", 0, 0, 1, 0, true, 1, 2, false, "Hand", true, "o", 0, 0));
                player.quests = new List<Quest>();
                player.health = 8;
                player.maxhealth = 8;
                player.damage = 1;
                player.defence = 0;
                player.gold = 0;
                player.xp = 0;
                player.xpul = 5;
                player.skillp = 0;
                player.level = 1;
                player.lastX = player.x;
                player.lastY = player.y;
                player.look = "☺";
                player.rangeD = 0;
                player.rangedA = 0;
                player.rangedR = 0;
                player.archery = 0;
                player.sight = 5;
                player.theivery = 0;
                player.creaturesKilled = 0;
                player.itemsBought = 0;
                player.reputation = 0;
                player.creaturesKilled = 0;
                player.itemsBought = 0;
            }
            firstTime = false;
            draw();
        }//End of overworld
        private void dungeon()
        {
            //Set to None
            trees = new List<Entity>();
            doors = new List<Door>();
            creatures = new List<Creature>();
            chests = new List<Chest>();
            walls = new List<Entity>();
            merchants = new List<Merchant>();
            merchantI = new List<Item>();
            npcs = new List<NPC>();
            upstairs = new Entity(-2, 0, "<", Color.LightGray);
            downstairs = new Entity(-2, 0, ">", Color.LightGray);
            //Setup
            lvlmod = dlevel - 1;
            //Dungeon Generation
            //Rooms
            int rooms;
            int x;
            int y;
            int placeX;
            int placeY;
            int stage;
            int part;
            bool hole;
            rooms = r.Next(3, 8 + 1);
            for (int i = 0; i < rooms; i++)
            {
                x = r.Next(7, width - 7 + 1);
                y = r.Next(7, height - 7 + 1);
                placeX = x - 1;
                placeY = y - 1;
                random = r.Next(4, 6 + 1);
                stage = 0;
                part = 0;
                hole = false;
                for (int t = 0; t < random + (random + 2 * (random - 1) + random - 2); t++)
                {
                    if (stage == 0)
                    {
                        if (part != random + 1)
                        {
                            placeX++;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 1;
                            part = 0;
                        }
                    }
                    if (stage == 1)
                    {
                        if (part != random)
                        {
                            placeY--;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 2;
                            part = 0;
                        }
                    }
                    if (stage == 2)
                    {
                        if (part != random)
                        {
                            placeX--;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            part++;
                        }
                        else
                        {
                            stage = 3;
                            part = 0;
                        }
                    }
                    if (stage == 3)
                    {
                        if (part != random - 1)
                        {
                            placeY++;
                            if (r.Next(0, 8 + 1) != 1)
                            {
                                walls.Add(new Entity(placeX, placeY, "█", Color.Gray));
                            }
                            else if (r.Next(0, 2 + 1) != 1)
                            {
                                bool locked = false;
                                string door = "O";
                                if (r.Next(0, 2 + 1) == 1)
                                {
                                    locked = true;
                                    door = "H";
                                }
                                doors.Add(new Door(placeX, placeY, door, Color.BurlyWood, locked));
                                hole = true;
                            }
                            if (hole != true & part == random - 2)
                            {
                                doors.Add(new Door(placeX, placeY, "O", Color.BurlyWood, false));
                            }
                            part++;
                        }
                        else
                        {
                            stage = 4;
                            part = 0;
                        }
                    }
                }
            }
            //Chests
            random = r.Next(1, 5 + 1);
            for (int i = 0; i < random; i++)
            {
            RetryChest:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryChest;
                    }
                }
                chests.Add(new Chest(placeX, placeY, "Œ", Color.BurlyWood, false));
            }
            //Creatures
            random = r.Next(4, 15 + 1);
            for (int i = 0; i < random; i++)
            {
            RetryCreature:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryCreature;
                    }
                }
                int l = r.Next(1, 4 + 1);
                if (l == 1)
                {
                    creatures.Add(new Creature("Lynx", "l", Color.Tan, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 1 + lvlmod), 0, "Default", placeX, placeY, placeX, placeY, 0, 0, new Item("Lynx Fur", 0, 0, 2, 0, true, 1, 0, false, "Hand", true, "|", 0, 0)));
                }
                else if (l == 2)
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
                    creatures.Add(new Creature("Orc", "o", Color.Green, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), 1, r.Next(1, 3 + lvlmod), r.Next(1, 2 + lvlmod), "Default", placeX, placeY, placeX, placeY, 0, 0, drop));
                }
                else if (l == 3)
                {
                    creatures.Add(new Creature("Zombie", "Z", Color.LightGreen, r.Next(1, 3 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), "Zombie", placeX, placeY, placeX, placeY, 0, 0, new Item("Zombie Flesh", 0, 0, 1, 0, true, 1, r.Next(1, 1 + lvlmod), false, "Hand", true, "K", 0, 0)));
                }
                else if (l == 4)
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
                    creatures.Add(new Creature("Orc Archer", "a", Color.Green, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), r.Next(0, 0 + lvlmod), 1, r.Next(1, 4 + lvlmod), r.Next(1, 2 + lvlmod), "Default", placeX, placeY, placeX, placeY, r.Next(3, 8), r.Next(10, 50 + lvlmod), drop));
                }
            }
            //Merchants
            random = r.Next(0, 3 + 1);
            for (int i = 0; i < random; i++)
            {
            RetryMerchant:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryMerchant;
                    }
                }
                merchantI = new List<Item>();
                int p = r.Next(1, 5 + 1);
                for (int g = 0; g < p; g++)
                {
                    Item rItem = randomItem(rItem = new Item("", 0, 0, 0, 0, false, 0, 0, false, "", false, "", 0, 0));
                    merchantI.Add(rItem);
                }
                string name = randomName(name = "");
                merchants.Add(new Merchant(placeX, placeY, "☻", Color.Wheat, r.Next(1, 2 + lvlmod), r.Next(1, 1 + lvlmod), name, r.Next(0, 1 + lvlmod), r.Next(0, 2 + lvlmod), merchantI));
            }
            //Tree Placement
            random = r.Next(0, 5 + 1);
            for (int i = 0; i < random; i++)
            {
            RetryTree:
                placeX = r.Next(0, width + 1);
                placeY = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (placeX == walls[t].x & placeY == walls[t].y)
                    {
                        goto RetryTree;
                    }
                }
                if (r.Next(1, 2 + 1) == 1)
                {
                    trees.Add(new Entity(placeX, placeY, "♣", Color.ForestGreen));
                }
                else
                {
                    trees.Add(new Entity(placeX, placeY, "♠", Color.ForestGreen));
                }
            }
            //Up Stair Placement
            if (r.Next(1, 4 + 1) == 1)
            {
            RetryUpStair:
                upstairs.x = r.Next(0, width + 1);
                upstairs.y = r.Next(0, height + 1);
                for (int t = 0; t < walls.Count; t++)
                {
                    if (upstairs.x == walls[t].x & upstairs.y == walls[t].y)
                    {
                        goto RetryUpStair;
                    }
                }
            }
            //Down Stair Placement
        RetryDownStair:
            downstairs.x = r.Next(0, width + 1);
            downstairs.y = r.Next(0, height + 1);
            for (int t = 0; t < walls.Count; t++)
            {
                if (downstairs.x == walls[t].x & downstairs.y == walls[t].y)
                {
                    goto RetryDownStair;
                }
            }
        //Player Placement
        RetryPlayer:
            player.x = r.Next(0, width + 1);
            player.y = r.Next(0, height + 1);
            for (int t = 0; t < walls.Count; t++)
            {
                if (player.x == walls[t].x & player.y == walls[t].y)
                {
                    goto RetryPlayer;
                }
            }
            //End of Dungeon Generation
            draw();
        }//End of dungeon
        public void game(int keypressed)
        {
            Player.playerMovement(player, keypressed);
            Player.playerRangedAttack(creatures, player, arrow, walls, width, height, messageBox, keypressed, r);
            //Player Health Managment
            if (player.health > player.maxhealth)
            {
                player.health = player.maxhealth;
            }
            //Npcs still if no creatures
            if (creatures.Count == 0)
            {
                for (int t = 0; t < npcs.Count; t++)
                {
                    Creature blank = new Creature("", "", Color.Black, 0, 0, 0, 0, 0, 0, "", 0, 0, 0, 0, 0, 0, null);
                    NPC.npcMovement(npcs[t], walls, doors, r);
                    NPC.npcMeleeAttack(npcs[t], blank, player, messageBox, r);
                    NPC.npcRangedAttack(npcs[t], creatures, player, arrow, walls, width, height, messageBox, r);
                    NPC.npcDead(npcs[t]);
                }
            }
            for (int i = 0; i < creatures.Count; i++)
            {
                if (creatures[i].x == player.x & creatures[i].y == player.y)
                {
                    Player.playerMeleeAttack(creatures[i], player, messageBox, r);
                    break;
                }
            }
            //Creatures
            for (int i = 0; i < creatures.Count; i++)
            {
                //Npcs
                for (int t = 0; t < npcs.Count; t++)
                {
                    NPC.npcMovement(npcs[t], walls, doors, r);
                    NPC.npcMeleeAttack(npcs[t], creatures[i], player, messageBox, r);
                    NPC.npcRangedAttack(npcs[t], creatures, player, arrow, walls, width, height, messageBox, r);
                    NPC.npcDead(npcs[t]);
                }
                Creature.creatureDead(creatures[i]);
                Creature.creatureMovement(creatures[i], player, npcs, walls, doors, r);
                Creature.creatureRangedAttack(creatures[i], player, npcs, arrow, walls, width, height, messageBox, r);
                Creature.creatureMeleeAttack(creatures[i], player, npcs, messageBox, r);
                Creature.creatureDead(creatures[i]);
            }
            //84 = t
            if (keypressed == 84)
            {
                //Open Merchant Window
                for (int i = 0; i < merchants.Count; i++)
                {
                    if (player.x == merchants[i].x & player.y == merchants[i].y)
                    {
                        MerchantWindow mer = new MerchantWindow(merchants[i], player, messageBox);
                        mer.Show();
                    }
                    else if (Application.OpenForms.OfType<MerchantWindow>().Any() & !merchants.Exists(x => x.x == player.x & x.y == player.y))
                    {
                        Application.OpenForms.OfType<MerchantWindow>().First().Close();
                    }
                }
                //Open NPC Window
                for (int i = 0; i < npcs.Count; i++)
                {
                    if (player.x == npcs[i].x & player.y == npcs[i].y)
                    {
                        NPCWindow mer = new NPCWindow(npcs[i], player, messageBox, lvlmod);
                        mer.Show();
                    }
                }
            }
            //69 = e
            if (keypressed == 69)
            {
                Inventory inv = new Inventory(player);
                inv.Show();
            }
            //Player Health Don't Go Negative
            if (player.health < 0)
            {
                player.health = 0;
            }
            //Collision Detection With Walls
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].x == player.x & walls[i].y == player.y)
                {
                    player.x = player.lastX;
                    player.y = player.lastY;
                }
                if (inDungeon == true)
                {
                    if (player.x == width + 1)
                    {
                        player.x = player.lastX;
                    }
                    else if (player.x == -1)
                    {
                        player.x = player.lastX;
                    }
                    if (player.y == height + 1)
                    {
                        player.y = player.lastY;
                    }
                    else if (player.y == -1)
                    {
                        player.y = player.lastY;
                    }
                }
                for (int t = 0; t < creatures.Count; t++)
                {
                    if (creatures[t].x == width + 1)
                    {
                        creatures[t].x = creatures[t].lastX;
                    }
                    else if (creatures[t].x == -1)
                    {
                        creatures[t].x = creatures[t].lastX;
                    }
                    if (creatures[t].y == height + 1)
                    {
                        creatures[t].y = creatures[t].lastY;
                    }
                    else if (creatures[t].y == -1)
                    {
                        creatures[t].y = creatures[t].lastY;
                    }
                }
                for (int t = 0; t < npcs.Count; t++)
                {
                    if (npcs[t].x == width + 1)
                    {
                        npcs[t].x = npcs[t].lastX;
                    }
                    else if (npcs[t].x == -1)
                    {
                        npcs[t].x = npcs[t].lastX;
                    }
                    if (npcs[t].y == height + 1)
                    {
                        npcs[t].y = npcs[t].lastY;
                    }
                    else if (npcs[t].y == -1)
                    {
                        npcs[t].y = npcs[t].lastY;
                    } 
                }
            }
            //Creature Collisions
            for (int t = 0; t < creatures.Count; t++)
            {
                if (creatures[t].x == width + 1)
                {
                    creatures[t].x = creatures[t].lastX;
                }
                else if (creatures[t].x == -1)
                {
                    creatures[t].x = creatures[t].lastX;
                }
                if (creatures[t].y == height + 1)
                {
                    creatures[t].y = creatures[t].lastY;
                }
                else if (creatures[t].y == -1)
                {
                    creatures[t].y = creatures[t].lastY;
                }
                for (int l = 0; l < doors.Count; l++)
                {
                    if (doors[l].x == creatures[t].x & doors[l].y == creatures[t].y)
                    {
                        if (doors[l].locked == true)
                        {
                            creatures[t].x = creatures[t].lastX;
                            creatures[t].y = creatures[t].lastY;
                        }
                    }
                }
            }
            //Player Out of Map
            if (inDungeon == false)
            {
                if (player.x == width + 1)
                {
                    worldX++;
                    messageBox.Text = "You entered into area: " + worldX + "," + worldY + Environment.NewLine + messageBox.Text;
                    overworld();
                }
                else if (player.x == -1)
                {
                    worldX--;
                    messageBox.Text = "You entered into area: " + worldX + "," + worldY + Environment.NewLine + messageBox.Text;
                    overworld();
                }
                if (player.y == height + 1)
                {
                    worldY++;
                    messageBox.Text = "You entered into area: " + worldX + "," + worldY + Environment.NewLine + messageBox.Text;
                    overworld();
                }
                else if (player.y == -1)
                {
                    worldY--;
                    messageBox.Text = "You entered into area: " + worldX + "," + worldY + Environment.NewLine + messageBox.Text;
                    overworld();
                }
            }
            //To Next Level or Into Dungeon
            if (player.x == downstairs.x & player.y == downstairs.y)
            {
                if (dlevel == 0)
                {
                    messageBox.Text = "You entered into a dungeon!" + Environment.NewLine + messageBox.Text;
                    inDungeon = true;
                }
                else
                {
                    messageBox.Text = "You made it to level " + dlevel + "!" + Environment.NewLine + messageBox.Text;
                }
                dlevel++;
                dungeon();
            }
            //To Overworld
            if (player.x == upstairs.x & player.y == upstairs.y)
            {
                messageBox.Text = "You exited the dungeon!" + Environment.NewLine + messageBox.Text;
                inDungeon = false;
                dlevel = 0;
                overworld();
            }
            //Chests and Doors
            for (int i = 0; i < chests.Count; i++)
            {
                if (player.x == chests[i].x & player.y == chests[i].y)
                {
                    if (chests[i].empty != true)
                    {
                        int d = r.Next(1, 6 + 1);
                        string itemName = "";
                        if (d < 6)
                        {
                            Item rItem = randomItem(rItem = new Item("", 0, 0, 0, 0, false, 1, 0, false, "", false, "", 0, 0));
                            itemName = rItem.name;
                            player.inventory.Add(rItem);
                        }
                        if (d == 6)
                        {
                            int goldF = r.Next(3, 6 + lvlmod);
                            player.gold += goldF;
                            messageBox.Text = "You found " + goldF + " gold!" + Environment.NewLine + messageBox.Text;
                        }
                        else
                        {
                            messageBox.Text = "You found a " + itemName + "." + Environment.NewLine + messageBox.Text;
                        }
                        chests[i].empty = true;
                    }
                    else
                    {
                        messageBox.Text = "This chest is empty." + Environment.NewLine + messageBox.Text;
                    }
                }
            }
            for (int i = 0; i < doors.Count; i++)
            {
                if (player.x == doors[i].x & player.y == doors[i].y)
                {
                    if (doors[i].locked == true)
                    {
                        Item key = player.inventory.Find(x => x.name.Contains("Key"));
                        if (key != null)
                        {
                            doors[i].locked = false;
                            doors[i].look = "O";
                            player.inventory.Remove(key);
                            messageBox.Text = "You unlocked the door." + Environment.NewLine + messageBox.Text;
                        }
                        else
                        {
                            messageBox.Text = "This door is locked." + Environment.NewLine + messageBox.Text;
                            player.x = player.lastX;
                            player.y = player.lastY;
                        }
                    }
                }
            }
            //Player Level Up
            if (player.xp >= player.xpul)
            {
                player.xp -= player.xpul;
                player.xpul = player.xpul * 2;
                player.level++;
                player.skillp += 1;
                messageBox.Text = "You leveled up and recieved 1 skill point!" + Environment.NewLine + messageBox.Text;
            }
            //Player Reputation
            if (player.creaturesKilled == 10)
            {
                player.reputation++;
                player.creaturesKilled = 0;
                messageBox.Text = "You killed 10 enemies and recieved 1 reputation." + Environment.NewLine + messageBox.Text;
            }
            if (player.itemsBought == 10)
            {
                player.reputation++;
                player.itemsBought = 0;
                messageBox.Text = "You bought 10 items and recieved 1 reputation." + Environment.NewLine + messageBox.Text;
            }
            //Stat Update
            statBox.Text = "";
            statBox.Text = "  Player Stats" + Environment.NewLine + "Health: " + player.health + "/" + player.maxhealth + Environment.NewLine + "Damage: " + player.damage + Environment.NewLine + "Defence: " + player.defence + Environment.NewLine + "XP: " + player.xp + "/" + player.xpul + Environment.NewLine + "Level: " + player.level + Environment.NewLine + "Gold: " + player.gold + Environment.NewLine + "Reputation: " + player.reputation;
            draw();
        }//End of game
        //Draw the map on screen
        private void draw()
        {
            //Map Builder
            int sightminy = player.y + player.sight * -1;
            int sightminx = player.x + player.sight * -1;
            int x = sightminx, y = sightminy;
            Color color;
            string builder = "";
            outputBox.Text = "";
            while (y != player.sight + player.y + 1)
            {
                x = sightminx;
                while (x != player.sight + player.x + 1)
                {
                    builder = "·";
                    if (inDungeon)
                    {
                        color = Color.Gray;
                    }
                    else
                    {
                        color = Color.Coral;
                    }
                    for (int i = 0; i < trees.Count; i++)
                    {
                        if (trees[i].x == x & trees[i].y == y)
                        {
                            builder = trees[i].look;
                            color = trees[i].color;
                        }
                    }
                    for (int i = 0; i < doors.Count; i++)
                    {
                        if (doors[i].x == x & doors[i].y == y)
                        {
                            builder = doors[i].look;
                            color = doors[i].color;
                        }
                    }
                    for (int i = 0; i < chests.Count; i++)
                    {
                        if (chests[i].x == x & chests[i].y == y)
                        {
                            builder = chests[i].look;
                            color = chests[i].color;
                        }
                    }
                    for (int i = 0; i < walls.Count; i++)
                    {
                        if (walls[i].x == x & walls[i].y == y)
                        {
                            builder = walls[i].look;
                            color = walls[i].color;
                        }
                    }
                    if (downstairs.x == x & downstairs.y == y)
                    {
                        builder = downstairs.look;
                        color = downstairs.color;
                    }
                    if (upstairs.x == x & upstairs.y == y)
                    {
                        builder = upstairs.look;
                        color = upstairs.color;
                    }
                    for (int i = 0; i < npcs.Count; i++)
                    {
                        if (npcs[i].x == x & npcs[i].y == y)
                        {
                            builder = npcs[i].look;
                            color = npcs[i].color;
                        }
                    }
                    for (int i = 0; i < merchants.Count; i++)
                    {
                        if (merchants[i].x == x & merchants[i].y == y)
                        {
                            builder = merchants[i].look;
                            color = merchants[i].color;
                        }
                    }
                    for (int i = 0; i < creatures.Count; i++)
                    {
                        if (creatures[i].x == x & creatures[i].y == y)
                        {
                            builder = creatures[i].look;
                            color = creatures[i].color;
                        }
                    }
                    if (player.x == x & player.y == y)
                    {
                        builder = player.look;
                        color = player.color;
                    }
                    if (x < 0 | x > width)
                    {
                        builder = "█";
                        if (inDungeon)
                        {
                            color = Color.Black;
                        }
                        else
                        {
                            color = Color.DarkSlateGray;
                        }
                    }
                    if (y < 0 | y > width)
                    {
                        builder = "█";
                        if (inDungeon)
                        {
                            color = Color.Black;
                        }
                        else
                        {
                            color = Color.DarkSlateGray;
                        }
                    }
                    if (builder == null)
                    {
                        builder = ".";
                    }
                    outputBox.SelectionColor = color;
                    outputBox.AppendText(builder);
                    x++;
                }
                outputBox.AppendText(Environment.NewLine);
                y++;
            }
            if (player.health <= 0)
            {
                outputBox.SelectionColor = Color.White;
                outputBox.Text = "You Died!";
            }
        }//End of draw
        //Random Item Genorator
        private Item randomItem(Item rItemI)
        {
            string b = "";
            string l = "";
            //Select Item Type
            int d = r.Next(1, 6 + 1);
            //Armor
            if (d == 1)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                else if (d == 2)
                {
                    b = "Broken ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Leather";
                }
                else if (d == 2)
                {
                    b += "Gold";
                }
                else if (d == 3)
                {
                    b += "Iron";
                }
                else if (d == 4)
                {
                    b += "Chain";
                }
                else if (d == 5)
                {
                    b += "Dragon Scale";
                }
                else if (d == 6)
                {
                    b += "Strange";
                }
                //Sufix
                d = r.Next(1, 2 + 1);
                if (d == 1)
                {
                    b += " Armor";
                }
                else if (d == 2)
                {
                    b += " Armor Set";
                }
                //Look
                d = r.Next(1, 4 + 1);
                if (d == 1)
                {
                    l = "M";
                }
                else if (d == 2)
                {
                    l = "H";
                }
                else if (d == 3)
                {
                    l = "N";
                }
                else if (d == 4)
                {
                    l = "W";
                }
                rItemI = new Item(b, 0, r.Next(1, 2 + lvlmod), r.Next(1, 3 + lvlmod), r.Next(1, 4 + lvlmod), false, 1, 0, false, "Armor", true, l, 0, 0);
                d = 0;
            }
            //Melee Weapon
            if (d == 2)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                else if (d == 2)
                {
                    b = "Broken ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Wooden";
                }
                else if (d == 2)
                {
                    b += "Gold";
                }
                else if (d == 3)
                {
                    b += "Iron";
                }
                else if (d == 4)
                {
                    b += "Steel";
                }
                else if (d == 5)
                {
                    b += "Dragon Scale";
                }
                else if (d == 6)
                {
                    b += "Strange";
                }
                //Suffix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += " Axe";
                }
                else if (d == 2)
                {
                    b += " Sword";
                }
                else if (d == 2)
                {
                    b += " Mace";
                }
                else if (d == 3)
                {
                    b += " Pike";
                }
                else if (d == 4)
                {
                    b += " Spear";
                }
                else if (d == 5)
                {
                    b += " Dagger";
                }
                else if (d == 6)
                {
                    b += " Knife";
                }
                //Look
                d = r.Next(1, 4 + 1);
                if (d == 1)
                {
                    l = "/";
                }
                else if (d == 2)
                {
                    l = "|";
                }
                else if (d == 3)
                {
                    l = ")";
                }
                else if (d == 4)
                {
                    l = "!";
                }
                rItemI = new Item(b, r.Next(1, 2 + lvlmod), 0, r.Next(1, 2 + lvlmod), r.Next(1, 3 + lvlmod), false, 1, 0, false, "Hand", true, l, 0, 0);
                d = 0;
            }
            //Ranged Weapon
            if (d == 3)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                else if (d == 2)
                {
                    b = "Broken ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Wooden";
                }
                else if (d == 2)
                {
                    b += "Gold";
                }
                else if (d == 3)
                {
                    b += "Iron";
                }
                else if (d == 4)
                {
                    b += "Steel";
                }
                else if (d == 5)
                {
                    b += "Dragon Scale";
                }
                else if (d == 6)
                {
                    b += "Strange";
                }
                //Sufix
                d = r.Next(1, 3 + 1);
                if (d == 1)
                {
                    b += " Bow";
                }
                else if (d == 2)
                {
                    b += " Crossbow";
                }
                else if (d == 3)
                {
                    b += " Compound Bow";
                }
                //Look
                d = r.Next(1, 4 + 1);
                if (d == 1)
                {
                    l = "C";
                }
                else if (d == 2)
                {
                    l = "(";
                }
                else if (d == 3)
                {
                    l = "B";
                }
                else if (d == 4)
                {
                    l = "D";
                }
                rItemI = new Item(b, r.Next(1, 1 + lvlmod), 0, r.Next(1, 3 + lvlmod), r.Next(1, 4 + lvlmod), false, 1, 0, false, "Hand", false, l, r.Next(3, 8 + 1), r.Next(10, 100 + 1));
                d = 0;
            }
            //Food
            if (d == 4)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Tasteless ";
                }
                else if (d == 2)
                {
                    b += "Gross ";
                }
                else if (d == 3)
                {
                    b += "Delicious ";
                }
                else if (d == 4)
                {
                    b += "Fresh ";
                }
                //Sufix
                d = r.Next(1, 5 + 1);
                if (d == 1)
                {
                    b += "Carrots";
                }
                else if (d == 2)
                {
                    b += "Potato";
                }
                else if (d == 3)
                {
                    b += "Bread";
                }
                else if (d == 4)
                {
                    b += "Stew";
                }
                else if (d == 5)
                {
                    b += "Steak";
                }
                //Look
                d = r.Next(1, 4 + 1);
                if (d == 1)
                {
                    l = "u";
                }
                else if (d == 2)
                {
                    l = "o";
                }
                else if (d == 3)
                {
                    l = "q";
                }
                else if (d == 4)
                {
                    l = "0";
                }
                rItemI = new Item(b, 0, 0, r.Next(1, 1 + lvlmod), r.Next(1, 2 + lvlmod), true, 1, r.Next(1, 2 + lvlmod), false, "Hand", true, l, 0, 0);
                d = 0;
            }
            //Keys
            if (d == 5)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                if (d == 2)
                {
                    b = "Broken ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Wooden";
                }
                else if (d == 2)
                {
                    b += "Gold";
                }
                else if (d == 3)
                {
                    b += "Iron";
                }
                else if (d == 4)
                {
                    b += "Steel";
                }
                else if (d == 5)
                {
                    b += "Dragon Scale";
                }
                else if (d == 6)
                {
                    b += "Strange";
                }
                //Sufix
                b += " Key";
                //Look
                d = r.Next(1, 4 + 1);
                if (d == 1)
                {
                    l = "F";
                }
                else if (d == 2)
                {
                    l = "K";
                }
                else if (d == 3)
                {
                    l = "R";
                }
                else if (d == 4)
                {
                    l = "T";
                }
                rItemI = new Item(b, 0, 0, r.Next(1, 1 + lvlmod), r.Next(1, 2 + lvlmod), true, 1, 0, false, "Hand", true, l, 0, 0);
                d = 0;
            }
            //Arrows
            if (d == 6)
            {
                //Pre Prefix
                d = r.Next(1, 8 + 1);
                if (d == 1)
                {
                    b = "Charred ";
                }
                else if (d == 2)
                {
                    b = "Broken ";
                }
                //Prefix
                d = r.Next(1, 6 + 1);
                if (d == 1)
                {
                    b += "Wooden";
                }
                else if (d == 2)
                {
                    b += "Gold";
                }
                else if (d == 3)
                {
                    b += "Iron";
                }
                else if (d == 4)
                {
                    b += "Steel";
                }
                else if (d == 5)
                {
                    b += "Dragon Scale";
                }
                else if (d == 6)
                {
                    b += "Strange";
                }
                //Suffix
                b += " Arrows";
                //Look
                d = r.Next(1, 2 + 1);
                if (d == 1)
                {
                    l = "-";
                }
                else if (d == 2)
                {
                    l = "/";
                }
                rItemI = new Item(b, 0, 0, r.Next(1, 1 + lvlmod), r.Next(1, 1 + lvlmod), true, r.Next(1, 100 + 1), 0, false, "Hand", true, l, 0, 0);
                d = 0;
            }
            //Keep Sell Price Below Buy Price
            if (rItemI.sellprice > rItemI.buyprice)
            {
                rItemI.sellprice = rItemI.buyprice - 1;
            }
            return rItemI;
        }//End of randomItem
        private string randomName(string randomname)
        {
            int random = r.Next(1, 20 + 1);
            if (random == 1)
            {
                randomname = "Bob";
            }
            else if (random == 2)
            {
                randomname = "Lar";
            }
            else if (random == 3)
            {
                randomname = "Shimi";
            }
            else if (random == 4)
            {
                randomname = "Frodom";
            }
            else if (random == 5)
            {
                randomname = "Keka";
            }
            else if (random == 6)
            {
                randomname = "Westly";
            }
            else if (random == 7)
            {
                randomname = "Jan";
            }
            else if (random == 8)
            {
                randomname = "Mongar";
            }
            else if (random == 9)
            {
                randomname = "Slor";
            }
            else if (random == 10)
            {
                randomname = "Cmal";
            }
            else if (random == 11)
            {
                randomname = "Shmal";
            }
            else if (random == 12)
            {
                randomname = "Talke";
            }
            else if (random == 13)
            {
                randomname = "Pam";
            }
            else if (random == 14)
            {
                randomname = "Rae";
            }
            else if (random == 15)
            {
                randomname = "Oal";
            }
            else if (random == 16)
            {
                randomname = "Warq";
            }
            else if (random == 17)
            {
                randomname = "Bayr";
            }
            else if (random == 18)
            {
                randomname = "Haro";
            }
            else if (random == 19)
            {
                randomname = "Kaf";
            }
            else if (random == 20)
            {
                randomname = "Alk";
            }
            return randomname;
        }
    }//End of Form
}//End of Namespace
