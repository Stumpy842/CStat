using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CStat
{
    /// <summary>
    /// Calculate cstat/flags values for Mapster32/EDuke32
    /// </summary>
    public partial class Form1 : Form
    {
        private bool act = false;
        private int entryMode;
        private int statCode;
        private readonly string AppName = Assembly.GetEntryAssembly()!.GetName().Name!;
        private readonly string AppVersion = Assembly.GetEntryAssembly()!.GetName().Version!.ToString();
        private readonly Regex rHex = new Regex("^0x", RegexOptions.IgnoreCase);
        private readonly Regex rBin = new Regex("^0b", RegexOptions.IgnoreCase);
        private readonly Regex rSpace = new Regex(@"\s", RegexOptions.IgnoreCase);
        private readonly String[] Base = { "decimal", "hex", "binary" };
        private readonly String[] Limits = { "65536 decimal", "10000 hex", "1 0000 0000 0000 0000 binary" };

        private readonly String[] sLabel = {"BLOCK", "TRANSLUCENT", "XFLIP", "YFLIP",
            "WALL", "FLOOR", "ONE_SIDED", "YCENTER", "BLOCK_HITSCAN", "TRANSLUCENT_INVERT", "(undefined)",
            "NOSHADE", "(unused)", "(undefined)", "(undefined)", "INVISIBLE"};

        private readonly String[] sDesc = {"Make sprite blockable", "Make sprite transparent",
            "Flip sprite around x-axis", "Flip sprite around y-axis", "Draw sprite as vertically flat (wall aligned)",
            "Draw sprite as horizontally flat (floor aligned)", "Make sprite one sided", "Real centered centering (half submerged)",
            "Make sprite able to be hit with weapons", "Second transparency level (combine with cstat 2)",
            "Sprite will take priority being drawn over other sprites (Polymost)", "Sprite will not be forced to take shade of sector " +
            "(EDuke32 extension)", "(reserved) (used by Shadow Warrior, Blood)", "Sprite will not cast a Polymer shadow (EDuke32)",
            "Sprite will be invisible but still cast a Polymer shadow (EDuke32)", "Invisible (do not render, skip EVENT_ANIMATESPRITES)"};

        private readonly String[] sKey = { "B", "T", "F", "F", "R", "R", "1", "C", "H", "T", "", "N", "", "", "", "'I" };

        private readonly String[] wLabel = {"BLOCK", "BOTTOM_SWAP", "ALIGN_BOTTOM", "XFLIP",
            "MASKED", "1WAY", "BLOCK_HITSCAN", "TRANSLUCENT", "YFLIP", "TRANS_FLIP", "YAX_UPWALL",
            "YAX_DOWNWALL", "ROTATE_90", "(unused)", "BLOCK_ACTOR", "WARP_HITSCAN"};

        private readonly String[] wDesc = { "Make wall blockable", "Make bottoms of invisible walls swapped",
            "Align picture on bottom", "Flip wall around x-axis", "Make wall masking, two-sided", "Make wall masking, one-sided",
            "Make wall able to be hit by weapons", "Make wall transparent", "Flip wall around y-axis",
            "Second transparency level (combine with cstat 128)", "(YAX - EDuke32 extension)", "(YAX - EDuke32 extension)",
            "Rotate texture by 90 degrees counter-clockwise (EDuke32 extension)", "(reserved)",
            "(used by Shadow Warrior, Blood) (temp use by editor)", "(used by Shadow Warrior, Blood)"};

        private readonly String[] wKey = { "B", "2", "O", "F", "M", "1", "H", "T", "F", "T", "", "", "", "", "", "" };

        private readonly String[] cLabel = { "PARALLAX", "GROUDRAW", "SWAP_XY", "DOUBLE_SMOOSH", "X_FLIP", "Y-FLIP",
            "RELATIVITY", "MASKED_FLOOR", "TRANSLUCENCE", "BLOCK", "YAX'ED", "HITSCAN", "(undefined)", "(undefined)", "(undefined)",
            "(undefined)"};

        private readonly String[] cDesc = {"Enable/disable parallax", "Groudraw (abandoned height mapping feature)",
            "Swap x & y axes", "Toggle ceiling/floor texture expansion", "Flip the current object around x-axis",
            "Flip the current object around y-axis", "Align texture to first wall of sector",
            "Cycles translucence for ceilings/floors for ROR (bits 8-7)", "01=masked  10=transluscent masked  " +
            "11=reverse transluscent masked", "Blocking ceiling/floor", "YAX'ed ceiling/floor", "Hitscan-sensitive ceiling/floor",
            "(reserved)", "(reserved)", "(reserved)", "(reserved)"};

        private readonly String[] cKey = { "P", "", "F", "E", "F", "F", "R", "T", "T", "", "", "", "", "", "", "" };
        
        /// <summary>
        /// Calculate cstat/flags for Mapster32 or EDuke32 - main form
        /// </summary>
        public Form1()
        {
            int entryMode = 0;
            InitializeComponent();
            btClear.Enabled = false;
            SetPretext(entryMode);
            InitLV();
            rtbInfo.Text = "Information from https://wiki.eduke32.com/wiki/Cstat_(sprite)," +
                " https://wiki.eduke32.com/wiki/Cstat_(wall)" + Environment.NewLine +
                "and https://voidpoint.io/terminx/eduke32/-/blob/master/source/build/include/buildtypes.h";

            aboutToolStripMenuItem.Text = "&About " + AppName;
        }

        private void InitLV()
        {
            int n;
            ListViewItem item;
            LV.BeginUpdate();
            LV.Items.Clear();
            for (int c = 0; c < 16; c++)
            {
                item = new ListViewItem();
                item.SubItems.Add(c.ToString());
                n = 1 << c;
                item.SubItems.Add(n.ToString("X"));
                item.SubItems.Add(n.ToString());
                if (rbSprite.Checked)
                {
                    item.SubItems.Add(sLabel[c]);
                    item.SubItems.Add(sDesc[c]);
                    item.SubItems.Add(sKey[c]);
                }
                else if (rbWall.Checked)
                {
                    item.SubItems.Add(wLabel[c]);
                    item.SubItems.Add(wDesc[c]);
                    item.SubItems.Add(wKey[c]);
                }
                else
                {
                    item.SubItems.Add(cLabel[c]);
                    item.SubItems.Add(cDesc[c]);
                    item.SubItems.Add(cKey[c]);
                }
                LV.Items.Add(item);
            }
            LV.EndUpdate();
        }

        private void UpdateLV()
        {
            ListViewItem item;
            LV.BeginUpdate();
            for (int c = 0; c < 16; c++)
            {
                item = LV.Items[c];
                if (rbSprite.Checked)
                {
                    item.SubItems[4].Text = sLabel[c];
                    item.SubItems[5].Text = sDesc[c];
                    item.SubItems[6].Text = sKey[c];
                }
                else if (rbWall.Checked)
                {
                    item.SubItems[4].Text = wLabel[c];
                    item.SubItems[5].Text = wDesc[c];
                    item.SubItems[6].Text = wKey[c];
                }
                else
                {
                    item.SubItems[4].Text = cLabel[c];
                    item.SubItems[5].Text = cDesc[c];
                    item.SubItems[6].Text = cKey[c];
                }
                LV.Items[c] = item;
            }
            LV.EndUpdate();
        }

        private void setText(int sc)
        {
            string PadBinary(string s)
            {
                string Reverse(string r)
                {
                    char[] chars = r.ToCharArray();
                    Array.Reverse(chars);
                    return new string(chars);
                }

                string t = "";
                string b = Reverse(s);
                for (int c = 0; c < b.Length; c++)
                {
                    if ((c > 0) && (c % 4 == 0)) t += " ";
                    t += b[c];
                }
                return Reverse(t);
            }

            switch (entryMode)
            {
                case 0: tbValue.Text = sc.ToString(); break;
                case 1: tbValue.Text = sc.ToString("X"); break;
                case 2: tbValue.Text = PadBinary(sc.ToString("B")); break;
            }
        }

        private void btCalc_Click(object sender, EventArgs e)
        {
            enableClear();
            statCode = 0;
            for (int c = 0; c < 16; c++)
            {
                if (LV.Items[c].Checked)
                {
                    statCode += 1 << c;
                    LV.Items[c].Selected = true;
                }
                else
                { LV.Items[c].Selected = false; }
            }
            setText(statCode);
        }

        private void SetPretext(int em)
        {
            tbValue.PlaceholderText = "Enter a " + Base[em] + " number";
        }


        private void rbChanged()
        {
            entryMode = SetEntryMode();
            if (tbValue.Text != "") setText(statCode);

            SetPretext(entryMode);
        }

        private void rbDecimal_CheckedChanged(object sender, EventArgs e)
        {
            rbChanged();
        }

        private void rbHex_CheckedChanged(object sender, EventArgs e)
        {
            rbChanged();
        }

        private void rbBinary_CheckedChanged(object sender, EventArgs e)
        {
            rbChanged();
        }

        private int SetEntryMode()
        {
            int r;
            if (rbDecimal.Checked) r = 0;
            else if (rbHex.Checked) r = 1;
            else r = 2;
            return r;
        }

        private void clrChecked()
        {
            btClear.Enabled = false;
            foreach (ListViewItem i in LV.CheckedItems)
            {
                i.Checked = false;
                i.Selected = false;
            }
        }

        private long ParseText(string t)
        {
            long sc = 0;
            switch (entryMode)
            {
                case 0: // decimal
                    {
                        if (!long.TryParse(t, NumberStyles.Integer,
                                CultureInfo.InvariantCulture, out sc))
                            sc = -1;
                    }
                    break;
                case 1: // hex
                    {
                        if (!long.TryParse(t, NumberStyles.HexNumber,
                                CultureInfo.InvariantCulture, out sc))
                            sc = -2;
                    }
                    break;
                case 2: // binary
                    {
                        if (!long.TryParse(t, NumberStyles.BinaryNumber,
                                CultureInfo.InvariantCulture, out sc))
                            sc = -3;
                    }
                    break;
            }
            return sc;
        }


        private void DoCalc()
        {

            string txt = tbValue.Text;
            switch (entryMode)
            {
                case 0: txt = txt.Trim(); break;
                case 1: txt = rHex.Replace(txt, string.Empty); break;
                case 2: txt = rBin.Replace(rSpace.Replace(txt, string.Empty), string.Empty); break;
            }

            if (String.IsNullOrEmpty(txt))
            {
                MessageBox.Show("Please enter a " + Base[entryMode] + " number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long pt = (ParseText(txt));
            if (pt < 0)
            {
                MessageBox.Show("Invalid or too large " + Base[entryMode] + " number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbValue.Clear();
                clrChecked();
                statCode = 0;
                return;
            }

            // process pt and display results
            statCode = (int)(pt % 65536);
            if (statCode != pt)
            {
                MessageBox.Show(txt + " too large" + Environment.NewLine + "Must be less than " + Limits[entryMode], "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btClear_Click(this, EventArgs.Empty);
                return;
            }
            int a; bool b;
            for (int c = 0; c < 16; c++)
            {
                a = 1 << c;
                b = ((statCode & a) == a);
                LV.Items[c].Checked = b;
                LV.Items[c].Selected = b;
            }
            enableClear();
        }

        private void tbValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DoCalc();
            }
        }

        private void rbSprite_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLV();
        }

        private void rbWall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLV();
        }

        private void rbCeiling_CheckedChanged(object sender, EventArgs e)
        {
            UpdateLV();
        }

        private void enableClear()
        {
            btClear.Enabled = (LV.CheckedItems.Count > 0);
        }

        // Event raised from RichTextBox when user clicks on a link
        private void rtbInfo_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            bool IsHttpURL(string u)
            { return ((!string.IsNullOrWhiteSpace(u)) && (u.StartsWith("http", StringComparison.CurrentCultureIgnoreCase))); }

            string url = e.LinkText!;
            if (IsHttpURL(url))
            { using Process p = Process.Start(new ProcessStartInfo(url) { UseShellExecute = true })!; }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbValue.Clear();
            clrChecked();
            statCode = 0;
        }

        private void tbValue_Enter(object sender, EventArgs e)
        {
            tbValue.SelectAll();
        }

        private void tbValue_MouseClick(object sender, MouseEventArgs e)
        {
            if (!act)
                tbValue.SelectAll();
            act = true;
        }

        private void tbValue_MouseEnter(object sender, EventArgs e)
        {
            act = tbValue.Focused;
        }

        private void LV_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            enableClear();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string s = AppName + " v" + AppVersion + " by Steven J Stover" + Environment.NewLine +
                "Copyright 2024, licensed under GPL v2.0";
            MessageBox.Show(s, "About " + AppName);
        }

        /// <summary>
        /// CStat Help form instantiation
        /// </summary>
        public Form Frm = null!;
        bool isFrmOpen = false;
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (isFrmOpen)
            {
                if (Frm.WindowState == FormWindowState.Minimized)
                    Frm.WindowState = FormWindowState.Normal;
                else
                    Frm.Focus();
            }
            else
            {
                Frm = new Form2();
                isFrmOpen = true;
                Frm.FormClosed += new FormClosedEventHandler(Frm_FormClosed!);
                Frm.Show();
            }

        }
        void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFrmOpen = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
