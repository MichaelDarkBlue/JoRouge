﻿using System;
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
    public class Object
    {
        public int x;
        public int y;
        public string look;
        public Color color = Color.White;
        public Object(int xI,int yI,string lookI,Color colorI)
        {
            x = xI;
            y = yI;
            look = lookI;
            if (colorI != null)
            {
                color = colorI;
            }
        }
        public Object()
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
    public class Door : Object
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
    public class Chest : Object
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
    public class Merchant : Object
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
}
