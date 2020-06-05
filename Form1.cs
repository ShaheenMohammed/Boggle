using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Boggle
{
    public partial class Form1 : Form
    {
        string inputtxt = "";
        
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Initializes dice, tiles and random variable for a new game.
        /// </summary>
        /// <improvements>
        /// Find a better way to implement dice and tiles 
        /// </improvements>
        private void reset()
        {
            Random r = new Random();
            string[,] Dice = new string[,]
            {
                {"A","E","A","N","E","G" },
                {"A","H","S","P","C","O" },
                {"A","S","P","F","F","K" },
                {"O","B","J","O","A","B" },
                {"I","O","T","M","U","C" },
                {"R","Y","V","D","E","L" },
                {"L","R","E","I","X","D" },
                {"E","I","U","N","E","S" },
                {"W","N","G","E","E","H" },
                {"L","N","H","N","R","Z" },
                {"T","S","T","I","Y","D" },
                {"O","W","T","O","A","T" },
                {"E","R","T","T","Y","L" },
                {"T","O","E","S","S","I" },
                {"T","E","R","W","H","V" },
                {"N","U","I","H","M","Qu" }
            };
            Label[] TileArray = new Label[16]
               {
                 Tile1,Tile2,Tile3,Tile4,
                 Tile5,Tile6,Tile7,Tile8,
                 Tile9,Tile10,Tile11,Tile12,
                 Tile13,Tile14,Tile15,Tile16
               };

            for (int count = 0; count < 16; count++)
                TileArray[count].Text = Dice[count, r.Next(6)];
            
        }

        /// <summary>
        /// Resets tile color
        /// </summary>     
        /// <improvements>
        /// Find a way to initialize tiles once throughout the game
        /// </improvements>
        private void TileColorReset()
        {
            Label[] TileArray = new Label[16]
               {
                 Tile1,Tile2,Tile3,Tile4,
                 Tile5,Tile6,Tile7,Tile8,
                 Tile9,Tile10,Tile11,Tile12,
                 Tile13,Tile14,Tile15,Tile16
               };

            for (int count = 0; count < 16; count++)
                TileArray[count].BackColor = Color.White;
        }

        /// <summary>
        /// <param name="inputtxt">used to decide which file method uses to check if user input is right</param>
        /// </summary>
        /// <improvements>
        /// Refactor check method initializing only one StreamReader and getting rid of switch method.
        /// </improvements>
        private bool Check(string inputtxt)
        {
            bool Checker = false;
          
            StreamReader Dictionary3 = new StreamReader(File.OpenRead("3.txt"));
            StreamReader Dictionary4 = new StreamReader(File.OpenRead("4.txt"));
            StreamReader Dictionary5 = new StreamReader(File.OpenRead("5.txt"));
            StreamReader Dictionary6 = new StreamReader(File.OpenRead("6.txt"));
            StreamReader Dictionary7 = new StreamReader(File.OpenRead("7.txt"));
            StreamReader Dictionary8 = new StreamReader(File.OpenRead("8.txt"));
            StreamReader Dictionary9 = new StreamReader(File.OpenRead("9.txt"));
            int Length = inputtxt.Length;
            if (Length > 9)
                Length = 9;
            if (Length < 3 && Length > 1)
                Length = 3;

            switch (Length)
	            {
                    case 3:

                    
                       while (!Dictionary3.EndOfStream)
                       {
                        if (String.Compare(inputtxt, Dictionary3.ReadLine()) == 0)
                            Checker = true; 
                       }
                          
                        break;
                    case 4:
                         while(!Dictionary4.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary4.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;
                    case 5:
                         while(!Dictionary5.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary5.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;

                    case 6:
                         while(!Dictionary6.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary6.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;

                    case 7:
                        while(!Dictionary7.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary7.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;
                    case 8:
                        while(!Dictionary8.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary8.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;
                    case 9:
                         while(!Dictionary9.EndOfStream)
                       {
                           if (String.Compare(inputtxt, Dictionary9.ReadLine()) == 0)
                            Checker=true;   
                       }
                          

                        break;

                    default:
                        MessageBox.Show("Word to be two or more letters.");
                        
                       

                        break;
		           
	            }
            return Checker;


        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {

            TileColorReset();
            

            if (Check(inputtxt) == false && inputtxt.Length > 1)
            {
                MessageBox.Show("Not a Word");
                

            }
            else if (inputtxt.Length<2)
                MessageBox.Show("Words Consist of 2 or more characters");

            else
                ScoreBox.Items.Add(Outputtxt.Text);
            

            
            inputtxt = "";
            Outputtxt.Text=inputtxt;

        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            TileColorReset();
            reset();
            ScoreBox.Items.Clear();
            Outputtxt.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel.BackColor == Color.White)
            {
                clickedLabel.BackColor = Color.Yellow;

                if (clickedLabel.BackColor == Color.Yellow)
                {
                       inputtxt += clickedLabel.Text;
                       Outputtxt.Text = inputtxt;

                }
            }
           

                
            




        }
    }
}
