using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RPG_Adventure
{
    //public class myGame
    //{
    //    public Player player;
    //    public Walls walls[];
    //    public Creature creaturs[];

    //}
    public class Entity
    {
        public int x;
        public int y;
        public string look;
        public Color color = Color.White;
        public Entity(int xI,int yI,string lookI,Color colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            if (colorI != null)
            {
                color = colorI;
            }
        }
        public Entity()
        { 
        }
    }
    public class Item
    {
        public string name;
        public int damage;
        public int defence;
        public int sellprice;
        public int hrestored;
        public bool equiped;
        public string slot;
        public bool melee;
        public string look;
        public int range;
        public int buyprice;
        public int accuracy;
        public bool stackable;
        public int count;
        public Item(string nameI,int damageI,int defenceI,int sellpriceI,int buypriceI,bool stackableI,int countI,int hrestoredI,bool equipedI,
                    string slotI,bool meleeI,string lookI,int rangeI, int accuracyI)
        {
            name = nameI;
            damage = damageI;
            defence = defenceI;
            sellprice = sellpriceI;
            buyprice = buypriceI;
            hrestored = hrestoredI;
            equiped = equipedI;
            slot = slotI;
            melee = meleeI;
            look = lookI;
            range = rangeI;
            accuracy = accuracyI;
            stackable = stackableI;
            count = countI;
        }
    }
    public class Door : Entity
    {
        public bool locked;
        public Door(int xI, int yI, string lookI, Color colorI, bool lockedI)
            : base(xI, yI, lookI, colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            locked = lockedI;
        }
    }
    public class Chest : Entity
    {
        public bool empty;
        public Chest(int xI, int yI, string lookI, Color colorI, bool emptyI)
            : base(xI, yI, lookI, colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            empty = emptyI;
        }
    }
    public class Merchant : Entity
    {
        public List<Item> inventory;
        public int watchfullness;
        public int health;
        public int damage;
        public int gold;
        public string name;
        public Merchant(int xI, int yI, string lookI, Color colorI, int healthI, int damageI, string nameI, int watchfullnessI, int goldI, List<Item> inventoryI)
            : base(xI, yI, lookI, colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            health = healthI;
            damage = damageI;
            watchfullness = watchfullnessI;
            inventory = inventoryI;
            gold = goldI;
            name = nameI;
        }
    }
    public class Quest
    {
        public string type;
        public string objective;
        public int amount;
        public string npcname;
        public int rgold;
        public int rreputation;
        public int rxp;
        public int sofar;
        public Quest(string typeI, string objectiveI, int amountI, string npcnameI, int rgoldI, int rreputationI, int rxpI, int sofarI)
        {
            type = typeI;
            objective = objectiveI;
            amount = amountI;
            npcname = npcnameI;
            rgold = rgoldI;
            rreputation = rreputationI;
            sofar = sofarI;
            rxp = rxpI;
        }
        public static Quest randomQuest(out Quest rQuest, int lvlmod, Random r)
        {
            int random = r.Next(1, 3 + 1);
            string objective = "";
            if (random == 1)
            {
                objective = "Orc";
            }
            else if (random == 2)
            {
                objective = "Orc Archer";
            }
            else if (random == 3)
            {
                objective = "Lynx";
            }
            rQuest = new Quest("Kill", objective, r.Next(1, 15), "", r.Next(8 + lvlmod, 14 + lvlmod), r.Next(1, 5), r.Next(15 + lvlmod, 30 + lvlmod), 0);
            return rQuest;
        }
    }
}
