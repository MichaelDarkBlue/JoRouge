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
    public partial class MerchantWindow : Form
    {
        int selected = 0;
        private List<Item> inv;
        private Merchant mer;
        private Player p;
        private System.Windows.Forms.TextBox messageBox;
        public MerchantWindow(Merchant inM, List<Item> inI, Player inP, System.Windows.Forms.TextBox inmessageBox)
        {
            InitializeComponent();
            inv = inI;
            mer = inM;
            p = inP;
            messageBox = inmessageBox;
            this.Text = mer.name + " the Merchant";
            if (p.reputation < 0)
            {
                messageBox.Text = mer.name + " the Merchant: \"I will never trade with you!\"" + Environment.NewLine + messageBox.Text;
            }
            draw(0);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (p.reputation >= 0)
            {
                if (p.gold >= mer.inventory[selected].buyprice)
                {
                    p.gold -= mer.inventory[selected].buyprice;
                    mer.gold += mer.inventory[selected].buyprice;
                    if ((inv.Exists(x => x == mer.inventory[selected] & x.stackable == true)))
                    {
                        for (int i = 0; i < inv.Count; i++)
                        {
                            if (inv[i] == mer.inventory[selected])
                            {
                                inv[i].count++;
                            }
                        }
                    }
                    else
                    {
                        inv.Add(mer.inventory[selected]);
                    }
                    p.itemsBought++;
                }
                else
                {
                    messageBox.Text = "You do not have enough gold." + Environment.NewLine + messageBox.Text;
                }
            }
            else
            {
                messageBox.Text = mer.name + " the Merchant: \"I will never trade with you!\"" + Environment.NewLine + messageBox.Text;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int random;
            random = r.Next(0, mer.watchfullness + 1);
            if (random < p.theivery)
            {
                messageBox.Text = "You stole a " + mer.inventory[selected].name + "!" + Environment.NewLine + messageBox.Text;
            }
            else
            {
                messageBox.Text = mer.name + " the Merchant: \"Hey! Stop that theif! He stole my " + mer.inventory[selected].name + "!\"" + Environment.NewLine + messageBox.Text;
                p.reputation--;
                random = r.Next(1, mer.damage + 1);
                if (p.defence > random)
                {
                    if (r.Next(0, p.defence) + 1 > random)
                    {
                        random = 0;
                    }
                }
                else
                {
                    random -= p.defence;
                    if (random <= 0)
                    {
                        random = 1;
                    }
                }
                p.health -= random;
                messageBox.Text = mer.name + " the Merchant hit you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
            }
            if ((inv.Exists(x => x == mer.inventory[selected] & x.stackable == true)))
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i] == mer.inventory[selected])
                    {
                        inv[i].count++;
                    }
                }
            }
            else
            {
                inv.Add(mer.inventory[selected]);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            p.reputation--;
            Random r = new Random();
            int random;
            random = r.Next(1, p.damage + 1);
            mer.health -= random;
            messageBox.Text = "You hit " + mer.name + " the Merchant for " + random + " damage!" + Environment.NewLine + messageBox.Text;
            random = r.Next(1, mer.damage + 1);
            if (p.defence > random)
            {
                if (r.Next(0, p.defence) + 1 > random)
                {
                    random = 0;
                }
            }
            else
            {
                random -= p.defence;
                if (random <= 0)
                {
                    random = 1;
                }
            }
            p.health -= random;
            messageBox.Text = mer.name + " the Merchant hit you for " + random + " damage!" + Environment.NewLine + messageBox.Text;
            if (mer.health <= 0)
            {
                string b;
                b = "You killed " + mer.name + " the Merchant";
                if (mer.gold > 0)
                {
                    b += " and found " + mer.gold + " gold";
                }
                b += ".";
                messageBox.Text = b + Environment.NewLine + messageBox.Text;
                mer.x = -10;
                mer.y = -10;
                Application.OpenForms.OfType<MerchantWindow>().First().Close();
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (p.reputation >= 0)
            {
                //38 = Up Arrow
                //40 = Down Arrow
                int keypressed = (int)e.KeyCode;
                draw(keypressed);
            }
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
            for (int i = 0; i < mer.inventory.Count; i++)
            {
                if (selected == i)
                {
                    textBox1.Text += "X " + mer.inventory[i].name;
                }
                else
                {
                    textBox1.Text += "- " + mer.inventory[i].name;
                }
                if (mer.inventory[i].name != "")
                {
                    textBox1.Text += ":";
                    textBox1.Text += " " + mer.inventory[i].look + ",";
                    if (mer.inventory[i].damage > 0)
                    {
                        textBox1.Text += " Damage: " + mer.inventory[i].damage + ",";
                    }
                    if (mer.inventory[i].defence > 0)
                    {
                        textBox1.Text += " Defence: " + mer.inventory[i].defence + ",";
                    }
                    if (mer.inventory[i].melee == true & mer.inventory[i].slot != "")
                    {
                        textBox1.Text += " Melee Weapon, ";
                    }
                    if (mer.inventory[i].melee == false & mer.inventory[i].slot != "")
                    {
                        textBox1.Text += " Ranged Weapon, ";
                    }
                    if (mer.inventory[i].range > 0)
                    {
                        textBox1.Text += " Range: " + mer.inventory[i].range + ",";
                    }
                    if (mer.inventory[i].accuracy > 0)
                    {
                        textBox1.Text += " Accuracy: " + mer.inventory[i].accuracy + "%,";
                    }
                    textBox1.Text += " Sell Price: " + mer.inventory[i].sellprice + ",";
                    if (mer.inventory[i].slot != "")
                    {
                        textBox1.Text += " Slot: " + mer.inventory[i].slot + ",";
                    }
                    if (mer.inventory[i].hrestored > 0)
                    {
                        textBox1.Text += " Health Restored: " + mer.inventory[i].hrestored + ",";
                    }
                    if (mer.inventory[i].count > 1)
                    {
                        textBox1.Text += " Amount: " + mer.inventory[i].count + ",";
                    }
                    textBox1.Text += " Buy Price: " + mer.inventory[i].buyprice;
                }
                textBox1.Text += Environment.NewLine;
            }
        }
    }
}
