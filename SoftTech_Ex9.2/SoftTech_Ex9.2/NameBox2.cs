﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftTech_Ex9._2
{
    public partial class NameBox2: UserControl
    {
        string nameShort;

       public void  empty()
        {
             textBox1.Text = "";
        }

        public void fill(string text)
        {
            textBox1.Text = text;
        }

        public string whole_name()
        {
            return textBox1.Text;
        }
        public override string Text
        {
            get
            {
                return nameShort;
            }
        }
        public void set_Focus()
        {
            textBox1.Focus();
        }
        public bool Focused_()
        {
            if (textBox1.Focused == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void color(Color color)
        {
            textBox1.ForeColor = color;
        }

        public void font(Font font)
        {
            textBox1.Font = font;
        }
        public NameBox2()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Enabled = true;
            if (e.KeyChar >= 'а' && e.KeyChar <= 'я' || e.KeyChar >= 'А' && e.KeyChar <= 'Я' || e.KeyChar == (char)Keys.Back
                || e.KeyChar == (char)Keys.Enter)
            {
                if (textBox1.Text.Length == 15 && e.KeyChar != (char)Keys.Back)
                {
                    MessageBox.Show("Името е до 15 букви!", "Грешка");
                    e.Handled = true;
                }
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show("Въвеждайте само кирилица!", "Грешка", buttons);
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int TextL = textBox1.Text.Length;
            int pos = textBox1.SelectionStart;
            if (TextL > 0)
            {
                string TextFirst = textBox1.Text.Substring(0, 1);
                string TextEnd = textBox1.Text.Substring(1, TextL - 1);
                textBox1.Text = TextFirst.ToUpper() + TextEnd.ToLower();
                textBox1.SelectionStart = pos;

                nameShort = TextFirst;
            }
        }
    }
}
