using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiscaleModelling
{
    public partial class Form1 : Form
    {
        Structure structure;
        Random rand = new Random();
        bool isProcessing = false;
        bool wasProcessed = false;
        bool boundaryColoringDone = false;
        Thread thread;
        List<Color> CAList = new List<Color>();
        List<Color> BoundaryList = new List<Color>();
        Color colorToOmit = new Color();

        public Form1()
        {
            InitializeComponent();
            growthButton.Enabled = false;
            generateButton.Enabled = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        class Structure
        {
            Cell[,] prevCells, currentCells;
            int structWidth, structHeight;

            public Structure(int widthUpDown, int heightUpDown)
            {
                structWidth = widthUpDown;
                structHeight = heightUpDown;

                prevCells = new Cell[structWidth, structHeight];
                currentCells = new Cell[structWidth, structHeight];

                for (int i = 0; i < structWidth; i++)
                {
                    for (int j = 0; j < structHeight; j++)
                    {
                        prevCells[i, j] = new Cell(i, j);
                        currentCells[i, j] = new Cell(i, j);
                    }
                }

            }

            public Cell[,] PrevCells { get => prevCells; set => prevCells = value; }
            public Cell[,] CurrentCells { get => currentCells; set => currentCells = value; }
            public int StructHeight { get => structHeight; set => structHeight = value; }
            public int StructWidth { get => structWidth; set => structWidth = value; }

            public Bitmap setColor(int structureBoxWidth, int structureBoxHeight)
            {
                float cellWidth = (float)structureBoxWidth / (float)structWidth;
                float cellHeight = (float)structureBoxHeight / (float)structHeight;
                float minCellSize = Math.Min(cellWidth, cellHeight);
                Bitmap bm = new Bitmap(Convert.ToInt32(structWidth * minCellSize), Convert.ToInt32(structHeight * minCellSize));

                using (Graphics g = Graphics.FromImage(bm))
                {
                    for (int i = 0; i < structWidth; i++)
                    {
                        for (int j = 0; j < structHeight; j++)
                        {
                            g.FillRectangle(new SolidBrush(prevCells[i, j].Color), minCellSize * prevCells[i, j].X, minCellSize * prevCells[i, j].Y, minCellSize, minCellSize);
                        }
                    }
                }
                return bm;
            }
        }

        class Cell
        {
            int x, y = 0;
            Color color;


            public Cell()
            {
                this.x = 0;
                this.y = 0;
                this.color = Color.FromArgb(255, 255, 255);
            } 

            public Cell(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.color = Color.FromArgb(255, 255, 255);
            }

            public Cell(int x, int y, Color color)
            {
                this.x = x;
                this.y = y;
                this.color = color;
            }

            public Color Color { get => color; set => color = value; }
            public int X { get => x; set => x = value; }
            public int Y { get => y; set => y = value; }
        }


        private void refreshStructureBox()
        {
            structureBox.Image = structure.setColor(structureBox.Width, structureBox.Height);
        }



        private void setRandomColor(Cell cell)
        {
            int r, g, b, wsp;
            do
            {
                wsp = rand.Next(1000);
                r = rand.Next(0, (256 + wsp) + 1) % 256;
                g = rand.Next(0, (512 + wsp) + 1) % 256;
                b = rand.Next(0, (1024 + wsp) + 1) % 256;
            } while (Color.FromArgb(r, g, b).Equals(Color.FromArgb(255, 255, 255)) || Color.FromArgb(r, g, b).Equals(Color.FromArgb(0, 0, 0)) || CAList.Contains(Color.FromArgb(r, g, b)));

            cell.Color = Color.FromArgb(r, g, b);
        }

        private void structureBox_Click(object sender, EventArgs e)  
        {
            if (wasProcessed)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                int X = me.X * (int)widthUpDown.Value / structureBox.Width;
                int Y = me.Y * (int)heightUpDown.Value / structureBox.Height;

                MessageBox.Show(string.Format("Selected {0}", structure.CurrentCells[X, Y].Color.ToString()));
            
                BoundaryList.Add(structure.CurrentCells[X, Y].Color);
            }
        }

        void growthMoore()
        {
            int wUpDown = (int)widthUpDown.Value;
            int hUpDown = (int)heightUpDown.Value;
            do
            {
                methodMoore(wUpDown, hUpDown);
                refreshStructureBox();
                Thread.Sleep(1);
            } while (isProcessing);
            wasProcessed = true;

        }

        //Generate space

        private void setButton_Click(object sender, EventArgs e)
        {
            int wUpDown = (int)widthUpDown.Value;
            int hUpDown = (int)heightUpDown.Value;
            structure = new Structure(wUpDown, hUpDown);
            refreshStructureBox();
            generateButton.Enabled = true;
            wasProcessed = false;
            BoundaryList.Clear();
            isProcessing = false;
        }

        // Generate grains
        private void generateButton_Click(object sender, EventArgs e)
        {

                int wUpDown = (int)widthUpDown.Value;
                int hUpDown = (int)heightUpDown.Value;
                int numOfGrains = (int)grainsUpDown.Value;

                for (int i = 0; i < numOfGrains; i++)
                {
                    int randX = rand.Next(wUpDown);
                    int randY = rand.Next(hUpDown);
                    if (structure.CurrentCells[randX, randY].Color.Equals(Color.FromArgb(255, 255, 255)))
                        setRandomColor(structure.CurrentCells[randX, randY]);
                    else
                        i--;
                }
                bool allNotWhite = true;

                for (int i = 0; i < structure.StructWidth; i++)
                {
                    for (int j = 0; j < structure.StructHeight; j++)
                    {
                        structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                        if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                            allNotWhite = false;
                    }
                }
                if (allNotWhite)
               isProcessing = false;
                refreshStructureBox();
                growthButton.Enabled = true;
            

        }

        private void growthButton_Click(object sender, EventArgs e)
        {
            isProcessing = true;

            string choose = textBox1.Text;
            if (choose == "Moore")
            {
                thread = new Thread(new ThreadStart(growthMoore));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void boundariesColoringButton_Click(object sender, EventArgs e)
        {
            int gbSize = int.Parse(textBox2.Text);
            int wUpDown = (int)widthUpDown.Value;
            int hUpDown = (int)heightUpDown.Value;
            int iprev, inext, jprev, jnext = 0;


            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    if (i == 0)
                        iprev = wUpDown - 1;
                    else
                        iprev = i - 1;

                    if (i == wUpDown - 1)
                        inext = 0;
                    else
                        inext = i + 1;

                    if (j == 0)
                        jprev = hUpDown - 1;
                    else
                        jprev = j - 1;

                    if (j == hUpDown - 1)
                        jnext = 0;
                    else
                        jnext = j + 1;

                    int coordinateXPlusGbSize = i + gbSize;
                    int coordinateYPlusGbSize = j + gbSize;

                    Color color = structure.CurrentCells[i, j].Color;

                    if (BoundaryList.Count == 0)
                    {
                        if (wasProcessed && color != Color.FromArgb(0, 0, 0))
                        {
                            if (structure.CurrentCells[iprev, jprev].Color != color && structure.CurrentCells[iprev, jprev].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[iprev, j].Color != color && structure.CurrentCells[iprev, j].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[iprev, jnext].Color != color && structure.CurrentCells[iprev, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[i, jnext].Color != color && structure.CurrentCells[i, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, jnext].Color != color && structure.CurrentCells[inext, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, j].Color != color && structure.CurrentCells[inext, j].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, jprev].Color != color && structure.CurrentCells[inext, jprev].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[i, jprev].Color != color && structure.CurrentCells[i, jprev].Color != Color.FromArgb(0, 0, 0))
                            {
                                if (coordinateXPlusGbSize < wUpDown && coordinateYPlusGbSize < hUpDown)
                                    for (int k = i; k < coordinateXPlusGbSize; k++)
                                    {
                                        for (int l = j; l < coordinateYPlusGbSize; l++)
                                        {
                                            structure.CurrentCells[k, l].Color = Color.FromArgb(0, 0, 0);
                                        }
                                    }
                            }
                        }
                    }
                    else
                    {
                        if (wasProcessed && color != Color.FromArgb(0, 0, 0) && BoundaryList.Contains(color))
                        {
                            if (structure.CurrentCells[iprev, jprev].Color != color && structure.CurrentCells[iprev, jprev].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[iprev, j].Color != color && structure.CurrentCells[iprev, j].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[iprev, jnext].Color != color && structure.CurrentCells[iprev, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[i, jnext].Color != color && structure.CurrentCells[i, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, jnext].Color != color && structure.CurrentCells[inext, jnext].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, j].Color != color && structure.CurrentCells[inext, j].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[inext, jprev].Color != color && structure.CurrentCells[inext, jprev].Color != Color.FromArgb(0, 0, 0) ||
                                structure.CurrentCells[i, jprev].Color != color && structure.CurrentCells[i, jprev].Color != Color.FromArgb(0, 0, 0))
                            {
                                if (coordinateXPlusGbSize < wUpDown && coordinateYPlusGbSize < hUpDown)
                                    for (int k = i; k < coordinateXPlusGbSize; k++)
                                    {
                                        for (int l = j; l < coordinateYPlusGbSize; l++)
                                        {
                                            structure.CurrentCells[k, l].Color = Color.FromArgb(0, 0, 0);
                                        }
                                    }
                            }
                        }
                    }
                }
            }

            bool allNotWhite = true;

            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                    if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                        allNotWhite = false;
                }
            }
            if (allNotWhite)
                isProcessing = false;
            refreshStructureBox();
            growthButton.Enabled = true;
            boundaryColoringDone = true;
        }

        private void ClearGrainsButton_Click(object sender, EventArgs e)
        {
            int numOfWhite = 0;
            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    if (structure.CurrentCells[i, j].Color != Color.FromArgb(0, 0, 0))
                    {
                        structure.CurrentCells[i, j].Color = Color.FromArgb(255, 255, 255);
                        numOfWhite++;
                    }
                }
            }
            bool allNotWhite = true;

            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                    if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                        allNotWhite = false;
                }
            }
            if (allNotWhite)
                isProcessing = false;
            refreshStructureBox();

            double gbPercent = (double)(structure.CurrentCells.Length - numOfWhite) / (double)structure.CurrentCells.Length * 100.0;
            gbPercent = Math.Round(gbPercent, 2);
        }



        public void methodMoore(int wUpDown, int hUpDown)
        {
            int iprev, inext, jprev, jnext = 0;

            for (int i = 0; i < wUpDown; i++)
            {
                if (i == 0)
                    iprev = wUpDown - 1;
                else
                    iprev = i - 1;

                if (i == wUpDown - 1)
                    inext = 0;
                else
                    inext = i + 1;

                for (int j = 0; j < hUpDown; j++)
                {
                
                    if (!structure.CurrentCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.CurrentCells[i, j].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[i, j].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[i, j].Color))
                    {

                        if (j == 0)
                            jprev = hUpDown - 1;
                        else
                            jprev = j - 1;

                        if (j == hUpDown - 1)
                            jnext = 0;
                        else
                            jnext = j + 1;

                        changeMooreColor(iprev, jprev, wUpDown, hUpDown);
                        changeMooreColor(iprev, j, wUpDown, hUpDown);
                        changeMooreColor(iprev, jnext, wUpDown, hUpDown);
                        changeMooreColor(i, jnext, wUpDown, hUpDown);
                        changeMooreColor(inext, jnext, wUpDown, hUpDown);
                        changeMooreColor(inext, j, wUpDown, hUpDown);
                        changeMooreColor(inext, jprev, wUpDown, hUpDown);
                        changeMooreColor(i, jprev, wUpDown, hUpDown);
                    }
                }
            }
            bool allNotWhite = true;

            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                    if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                        allNotWhite = false;
                }
            }
            if (allNotWhite)
                isProcessing = false;
        }

        void changeMooreColor(int x, int y, int wUpDown, int hUpDown)
        {
            if (structure.CurrentCells[x, y].Color.Equals(Color.FromArgb(255, 255, 255)))
            {
                int xprev, xnext, yprev, ynext = 0;
                Dictionary<Color, int> matchColor = new Dictionary<Color, int>();
                List<Color> neighbours = new List<Color>();

                if (x == 0)
                    xprev = wUpDown - 1;
                else
                    xprev = x - 1;

                if (x == wUpDown - 1)
                    xnext = 0;
                else
                    xnext = x + 1;

                if (y == 0)
                    yprev = hUpDown - 1;
                else
                    yprev = y - 1;

                if (y == hUpDown - 1)
                    ynext = 0;
                else
                    ynext = y + 1;

                if (!structure.PrevCells[xprev, y].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xprev, y].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xprev, y].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xprev, y].Color))
                {
                    neighbours.Add(structure.PrevCells[xprev, y].Color);
                }

                if (!structure.PrevCells[xprev, yprev].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xprev, yprev].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xprev, yprev].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xprev, yprev].Color))
                {
                    neighbours.Add(structure.PrevCells[xprev, yprev].Color);
                }

                if (!structure.PrevCells[x, yprev].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[x, yprev].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[x, yprev].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[x, yprev].Color))
                {
                    neighbours.Add(structure.PrevCells[x, yprev].Color);
                }

                if (!structure.PrevCells[xnext, yprev].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xnext, yprev].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xnext, yprev].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xnext, yprev].Color))
                {
                    neighbours.Add(structure.PrevCells[xnext, yprev].Color);
                }

                if (!structure.PrevCells[xnext, y].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xnext, y].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xnext, y].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xnext, y].Color))
                {
                    neighbours.Add(structure.PrevCells[xnext, y].Color);
                }

                if (!structure.PrevCells[xnext, ynext].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xnext, ynext].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xnext, ynext].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xnext, ynext].Color))
                {
                    neighbours.Add(structure.PrevCells[xnext, ynext].Color);
                }

                if (!structure.PrevCells[x, ynext].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[x, ynext].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[x, ynext].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[x, ynext].Color))
                {
                    neighbours.Add(structure.PrevCells[x, ynext].Color);
                }

                if (!structure.PrevCells[xprev, ynext].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[xprev, ynext].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[xprev, ynext].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[xprev, ynext].Color))
                {
                    neighbours.Add(structure.PrevCells[xprev, ynext].Color);
                }
 
                if (!structure.PrevCells[x, y].Color.Equals(Color.FromArgb(255, 255, 255)) && !structure.PrevCells[x, y].Color.Equals(Color.FromArgb(0, 0, 0)) && !structure.CurrentCells[x, y].Color.Equals(colorToOmit) && !CAList.Contains(structure.CurrentCells[x, y].Color))
                {
                    neighbours.Add(structure.PrevCells[x, y].Color);
                }
              
                foreach (Color color in neighbours)
                {
                    if (!matchColor.ContainsKey(color))
                        matchColor.Add(color, 1);
                    else
                        matchColor[color] = matchColor[color] + 1;
                }

                Color maxKey = getMaxKey(matchColor);
                if (matchColor.Count != 0 && !structure.CurrentCells[x, y].Color.Equals(Color.FromArgb(0, 0, 0)))
                {
                    structure.CurrentCells[x, y].Color = maxKey;
                }
            }
        }

        Color getMaxKey(Dictionary<Color, int> map)
        {
            int max = 0;

            foreach (var item in map)  // item - kolor i ilosc jego wystapien
            {
                if (item.Value > max)  //  szuka koloru, ktory wystapil najwiecej razy (item.Value - ilość wystąpień)
                    max = item.Value;
            }
            Color maxKey = map.FirstOrDefault(x => x.Value == max).Key;  //zwraca kolor(klucz), który wystąpił najwięcej razy

            return maxKey;
        }

        //Import Export txt 

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog sfd = new OpenFileDialog();
            sfd.ShowDialog();
            string FilePath = sfd.FileName;

            string[] linesToRead = System.IO.File.ReadAllLines(FilePath);
            string[] imageToRead = new string[linesToRead.Length - 1];
            Array.Copy(linesToRead, 1, imageToRead, 0, linesToRead.Length - 1);
            string[] dimensions = linesToRead[0].Split(',');
            widthUpDown.Value = Convert.ToDecimal(dimensions[0]);
            heightUpDown.Value = Convert.ToDecimal(dimensions[1]);
            structure = new Structure(Convert.ToInt32(dimensions[0]), Convert.ToInt32(dimensions[0]));
            foreach (string line in imageToRead)
            {
                string[] values = line.Split(',');
                Color color = Color.FromArgb(Convert.ToInt32(values[2]), Convert.ToInt32(values[3]), Convert.ToInt32(values[4]));
                structure.PrevCells[Convert.ToInt32(values[0]), Convert.ToInt32(values[1])].Color = color;
            }
            refreshStructureBox();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "Grains_id",
                Filter = "Text (*.txt)|*.txt"
            };
            sfd.ShowDialog();
            string FilePath = sfd.FileName;


            List<string> linesToWrite = new List<string>();
            linesToWrite.Add(structure.StructWidth + "," + structure.StructHeight);
            for (int i = 0; i < structure.StructWidth; i++)
            {
                for (int j = 0; j < structure.StructHeight; j++)
                {
                    StringBuilder line = new StringBuilder();
                    line.Append(structure.PrevCells[i, j].X);
                    line.Append(",");
                    line.Append(structure.PrevCells[i, j].Y);
                    line.Append(",");
                    line.Append(structure.PrevCells[i, j].Color.R);
                    line.Append(",");
                    line.Append(structure.PrevCells[i, j].Color.G);
                    line.Append(",");
                    line.Append(structure.PrevCells[i, j].Color.B);
                    linesToWrite.Add(line.ToString());
                }
            }
            System.IO.File.WriteAllLines(@FilePath, linesToWrite.ToArray());
        }
        //Export import bitmap
        private void savePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                FileName = "Bitmap",
                Filter = "Bitmap (*.bmp)|*.bmp"
            };
            sfd.ShowDialog();
            string FilePath = sfd.FileName;

            Bitmap bm = structure.setColor(structureBox.Width, structureBox.Height);
            bm.Save(FilePath, ImageFormat.Bmp);
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.ShowDialog();
            string FilePath = sfd.FileName;
            Bitmap bm = new Bitmap(FilePath);
            structureBox.Image = bm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = false;
                int wUpDown = (int)widthUpDown.Value;
                int hUpDown = (int)heightUpDown.Value;
                int numOfInclusions = int.Parse(textBox3.Text);
                int r = int.Parse(textBox4.Text);
                int x, y, a, b, c, d, xprev, xnext, yprev, ynext = 0;

                for (int i = 0; i < numOfInclusions; i++)
                {
                    do
                    {
                        x = rand.Next(wUpDown);
                        y = rand.Next(hUpDown);
                        a = x + r;
                        b = y + r;
                        c = x - r;
                        d = y - r;

                    } while (a > wUpDown - 1 || b > hUpDown - 1 || c <= 0 || d <= 0);

                    if (x == 0)
                        xprev = wUpDown - 1;
                    else
                        xprev = x - 1;

                    if (x == wUpDown - 1)
                        xnext = 0;
                    else
                        xnext = x + 1;

                    if (y == 0)
                        yprev = hUpDown - 1;
                    else
                        yprev = y - 1;

                    if (y == hUpDown - 1)
                        ynext = 0;
                    else
                        ynext = y + 1;

                    Color color = structure.CurrentCells[x, y].Color;

                    if (wasProcessed)
                    {
                        if (structure.CurrentCells[xprev, yprev].Color != color || structure.CurrentCells[xprev, y].Color != color || structure.CurrentCells[xprev, ynext].Color != color || structure.CurrentCells[x, ynext].Color != color
                            || structure.CurrentCells[xnext, ynext].Color != color || structure.CurrentCells[xnext, y].Color != color || structure.CurrentCells[xnext, yprev].Color != color || structure.CurrentCells[x, yprev].Color != color)
                        {
                            for (int j = r; j > 0; j--)
                            {
                                r = j;
                                for (int k = 0; k < 360; k += 1)
                                {
                                    double angle = k * System.Math.PI / 180;
                                    int xx = (int)(x + r * System.Math.Cos(angle));
                                    int yy = (int)(y + r * System.Math.Sin(angle));

                                    structure.CurrentCells[xx, yy].Color = Color.FromArgb(0, 0, 0);
                                }
                            }
                            r = int.Parse(textBox4.Text);
                        }
                        else
                            i--;
                    }
                    else
                    {
                        for (int j = r; j > 0; j--)
                        {
                            r = j;
                            for (int k = 0; k < 360; k += 1)
                            {
                                double angle = k * System.Math.PI / 180;
                                int xx = (int)(x + r * System.Math.Cos(angle));
                                int yy = (int)(y + r * System.Math.Sin(angle));

                                structure.CurrentCells[xx, yy].Color = Color.FromArgb(0, 0, 0);
                            }
                        }
                        r = int.Parse(textBox4.Text);
                    }
                }

                bool allNotWhite = true;

                for (int i = 0; i < structure.StructWidth; i++)
                {
                    for (int j = 0; j < structure.StructHeight; j++)
                    {
                        structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                        if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                            allNotWhite = false;
                    }
                }
                if (allNotWhite)
                    isProcessing = false;
                refreshStructureBox();
            }

            else if (checkBox2.Checked)
            {
                checkBox1.Enabled = false;
                int wUpDown = (int)widthUpDown.Value;
                int hUpDown = (int)heightUpDown.Value;
                int numOfInclusions = int.Parse(textBox3.Text);
                int d = int.Parse(textBox4.Text);
                int sizeOfInclusions = (int)Math.Round(d / 1.414);
                int xprev, xnext, yprev, ynext = 0;


                for (int i = 0; i < numOfInclusions; i++)
                {
                    int x = rand.Next(wUpDown);
                    int y = rand.Next(hUpDown);
                    int a = x + sizeOfInclusions;
                    int b = y + sizeOfInclusions;

                    if (x == 0)
                        xprev = wUpDown - 1;
                    else
                        xprev = x - 1;

                    if (x == wUpDown - 1)
                        xnext = 0;
                    else
                        xnext = x + 1;

                    if (y == 0)
                        yprev = hUpDown - 1;
                    else
                        yprev = y - 1;

                    if (y == hUpDown - 1)
                        ynext = 0;
                    else
                        ynext = y + 1;

                    Color color = structure.CurrentCells[x, y].Color;
                    if (wasProcessed)
                    {
                        if (structure.CurrentCells[xprev, yprev].Color != color || structure.CurrentCells[xprev, y].Color != color || structure.CurrentCells[xprev, ynext].Color != color || structure.CurrentCells[x, ynext].Color != color
                            || structure.CurrentCells[xnext, ynext].Color != color || structure.CurrentCells[xnext, y].Color != color || structure.CurrentCells[xnext, yprev].Color != color || structure.CurrentCells[x, yprev].Color != color)
                        {
                            if (a < wUpDown && b < hUpDown)
                            {
                                for (int j = x; j < a; j++)
                                {
                                    for (int k = y; k < b; k++)
                                    {
                                        structure.CurrentCells[j, k].Color = Color.FromArgb(0, 0, 0);
                                    }
                                }
                            }
                            else
                            {
                                for (int j = a; j > x; j--)
                                {
                                    for (int k = b; k < y; k--)
                                    {
                                        structure.CurrentCells[j, k].Color = Color.FromArgb(0, 0, 0);
                                    }
                                }

                            }
                        }
                        else
                            i--;
                    }
                    else
                    {
                        if (a < wUpDown && b < hUpDown)
                        {
                            for (int j = x; j < a; j++)
                            {
                                for (int k = y; k < b; k++)
                                {
                                    structure.CurrentCells[j, k].Color = Color.FromArgb(0, 0, 0);
                                }
                            }
                        }
                        else
                        {
                            for (int j = a; j > x; j--)
                            {
                                for (int k = b; k < y; k--)
                                {
                                    structure.CurrentCells[j, k].Color = Color.FromArgb(0, 0, 0);
                                }
                            }
                        }
                    }
                }
                bool allNotWhite = true;

                for (int i = 0; i < structure.StructWidth; i++)
                {
                    for (int j = 0; j < structure.StructHeight; j++)
                    {
                        structure.PrevCells[i, j].Color = structure.CurrentCells[i, j].Color;
                        if (structure.PrevCells[i, j].Color.Equals(Color.FromArgb(255, 255, 255)))
                            allNotWhite = false;
                    }
                }
                if (allNotWhite)
                    isProcessing = false;
                refreshStructureBox();
                growthButton.Enabled = true;
            }
        }
    }
}
