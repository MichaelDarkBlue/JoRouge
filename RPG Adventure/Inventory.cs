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
    public partial class Inventory : Form
    {
        int selected = 0;
        private List<Item> inv;
        private Player p;
        private Form1 mainform = new Form1();
        public Inventory(List<Item> inI, Player inP)
        {
            InitializeComponent();
            inv = inI;
            p = inP;
            draw(0);
            //inv.Add(new Item("Block"));
            //inv[0].damage = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (inv[selected].equiped == false & !(inv.Exists(x => x.slot == inv[selected].slot & x.equiped == true)))
            {
                inv[selected].equiped = true;
                if (inv[selected].melee == true)
                {
                    p.damage += inv[selected].damage;
                    p.defence += inv[selected].defence;
                    p.rangeD += inv[selected].damage;
                    p.rangedR += inv[selected].range;
                    p.rangedA += inv[selected].accuracy;
                }
                else
                {
                    p.rangeD += inv[selected].damage;
                    p.rangedR += inv[selected].range;
                    p.rangedA += inv[selected].accuracy;
                    p.ranged = true;
                }
                mainform.game(0);
                draw(0);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (inv[selected].equiped == true)
            {
                inv[selected].equiped = false;
                if (inv[selected].melee == true)
                {
                    p.damage -= inv[selected].damage;
                    p.defence -= inv[selected].defence;
                    p.rangeD -= inv[selected].damage;
                    p.rangedR -= inv[selected].range;
                    p.rangedA -= inv[selected].accuracy;
                }
                else
                {
                    p.rangeD -= inv[selected].damage;
                    p.rangedR -= inv[selected].range;
                    p.rangedA -= inv[selected].accuracy;
                    p.ranged = false;
                }
                mainform.game(0);
                draw(0);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (inv[selected].hrestored > 0 & inv[selected].equiped == false)
            {
                p.health += inv[selected].hrestored;
                if (inv[selected].count > 1)
                {
                    inv[selected].count--;
                }
                else
                {
                    inv.Remove(inv[selected]);
                }
                mainform.game(0);
                draw(0);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<MerchantWindow>().Any() & inv[selected].equiped == false)
            {
                p.gold += inv[selected].sellprice;
                if (!inv[selected].name.Contains("Arrows"))
                {
                    if (inv[selected].count > 1)
                    {
                        inv[selected].count--;
                    }
                    else
                    {
                        inv.Remove(inv[selected]);
                    }
                }
                else
                {
                    inv.Remove(inv[selected]);
                }
                mainform.game(0);
                draw(0);
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //38 = Up Arrow
            //40 = Down Arrow
            int keypressed = (int)e.KeyCode;
            draw(keypressed);
        }
        private void draw(int keypressed)
        {
            if (keypressed == 38)
            {
                selected--;
            }
            if (keypressed == 40)
            {
                selected++;
            }
            textBox1.Text = "";
            for (int i = 0; i < inv.Count; i++)
            {
                if (selected == i)
                {
                    textBox1.Text += "X " + inv[i].name;
                }
                else
                {
                    textBox1.Text += "- " + inv[i].name;
                }
                if (inv[i].name != "")
                {
                    textBox1.Text += ":";
                    textBox1.Text += " " + inv[i].look + ",";
                    if (inv[i].damage > 0)
                    {
                        textBox1.Text += " Damage: " + inv[i].damage + ",";
                    }
                    if (inv[i].defence > 0)
                    {
                        textBox1.Text += " Defence: " + inv[i].defence + ",";
                    }
                    if (inv[i].melee == true & inv[i].slot != "")
                    {
                        textBox1.Text += " Melee Weapon, ";
                    }
                    if (inv[i].melee == false & inv[i].slot != "")
                    {
                        textBox1.Text += " Ranged Weapon, ";
                    }
                    if (inv[i].range > 0)
                    {
                        textBox1.Text += " Range: " + inv[i].range + ",";
                    }
                    if (inv[i].accuracy > 0)
                    {
                        textBox1.Text += " Accuracy: " + inv[i].accuracy + "%,";
                    }
                    textBox1.Text += " Sell Price: " + inv[i].sellprice + ",";
                    textBox1.Text += " Equiped: " + inv[i].equiped + ",";
                    if (inv[i].slot != "")
                    {
                        textBox1.Text += " Slot: " + inv[i].slot + ",";
                    }
                    if (inv[i].hrestored > 0)
                    {
                        textBox1.Text += " Health Restored: " + inv[i].hrestored + ",";
                    }
                    if (inv[i].count > 1)
                    {
                        textBox1.Text += " Amount: " + inv[i].count;
                    }
                }
                textBox1.Text += Environment.NewLine;
            }
        }//End of draw
    }//End of form
}//End of namespace
