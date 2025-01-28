using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChessLogicLib;
using Chess.Properties;
using System.Runtime.InteropServices;

namespace ChessUserControls
{
    public partial class ChessBoard : UserControl
    {
        PictureBox[,] pictureBoxArray = new PictureBox[8, 8];
        Game_board board = new Game_board();
        public List<Tuple<int, int>> positions = new List<Tuple<int, int>>();

        public Point first_click; 
        public bool isDragging = false;

        public ChessBoard()
        {
            InitializeComponent();
            create_empty_controls_board();
            set_the_images_on_control_board();
        }
        public void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Tuple<int, int> position = save_position(pictureBox);          
            positions.Add(position);
            first_click = e.Location;
            if(positions.Count == 2) handle_player_move();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = Math.Abs(e.X - first_click.X);
                int dy = Math.Abs(e.Y - first_click.Y);
                if (dx > SystemInformation.DragSize.Width || dy > SystemInformation.DragSize.Height) isDragging = true;
            }
        }
        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (positions.Count < 2) 
                // bo inaczej klikniecie na pierwszą figure i przesuniecie drugiej jakbyś zrezygnowal z ruchu pierwsza
                //wyrzuca out of range -> mousedown sie nie uruchamia wiec pozycje nie sa resetowane
                //jak przy click1->click2 wiec count =3
            {
                if (isDragging && positions.Count == 1) //positions.count = 1 bo dalej handle...() wymaga 2 argumentow z position
                {
                    Point cursorPosition = tableLayoutPanel1.PointToClient(Cursor.Position);
                    Control targetControl = tableLayoutPanel1.GetChildAtPoint(cursorPosition);
                    if (targetControl is PictureBox pictureBox)
                    {
                        Tuple<int, int> position = save_position(pictureBox);
                        positions.Add(position);
                        handle_player_move();
                    }
                }
            }
            else
            {
                positions.Clear(); // jak rezygnuje z ruchu to clear pozycji 
            }
        }

        public void handle_player_move()
        {
            if (board.player_turn(positions[0].Item1, positions[0].Item2, positions[1].Item1, positions[1].Item2))
            {
                update_image(positions[0], positions[1]);             
                if (board.search_for_checkmate_by_enemy()) MessageBox.Show("Game over! Checkmate.");
            }
            positions.Clear();
            isDragging = false;
        }

        public void update_image(Tuple<int, int> pos1, Tuple<int, int> pos2)
        {
            Image start_image = pictureBoxArray[pos1.Item1, pos1.Item2].Image;
            pictureBoxArray[pos2.Item1, pos2.Item2].Image = start_image;
            pictureBoxArray[pos1.Item1, pos1.Item2].Image = null;
        }

        public Tuple<int, int> save_position(PictureBox picturebox)
        {
            // pictureboxy maja nazwy 1_1 1_2 etc. bo kontrolka podzielona na 8x8 pictureboxów
            // wiec pozycje x,y wyjete z nazwy okreslajacej pozycje w tabeli 8x8
            string[] name = picturebox.Name.Split('_');
            int x = int.Parse(name[0].Substring(10));  
            int y = int.Parse(name[1]);

            return Tuple.Create(x, y);
        }


        public PictureBox create_square_picturebox(int x_cord, int y_cord)
        {
            PictureBox picturebox = new PictureBox();
            picturebox.Name = "PictureBox" + x_cord + "_" + y_cord;
            picturebox.Dock = DockStyle.Fill;
            picturebox.SizeMode = PictureBoxSizeMode.Zoom;

            picturebox.MouseDown += PictureBox_MouseDown;
            picturebox.MouseMove += PictureBox_MouseMove;
            picturebox.MouseUp += PictureBox_MouseUp;
            return picturebox;
        }

        public void create_empty_controls_board()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    pictureBoxArray[x, y] = create_square_picturebox(x, y);

                    if (y % 2 == 0)
                    {
                        if (x % 2 == 0) pictureBoxArray[x, y].BackgroundImage = Resources.White;
                        else pictureBoxArray[x, y].BackgroundImage = Resources.Black;
                    }
                    if (y % 2 == 1)
                    {
                        if (x % 2 == 0) pictureBoxArray[x, y].BackgroundImage = Resources.Black;
                        else pictureBoxArray[x, y].BackgroundImage = Resources.White;
                    }
                    tableLayoutPanel1.Controls.Add(pictureBoxArray[x, y], x, y);
                }
            }
        }

        public void set_the_images_on_control_board()
        {
            pictureBoxArray[0, 0].Image = Resources.WhiteRook;
            pictureBoxArray[7, 0].Image = Resources.WhiteRook;
            pictureBoxArray[0, 7].Image = Resources.BlackRook;
            pictureBoxArray[7, 7].Image = Resources.BlackRook;

            pictureBoxArray[1, 0].Image = Resources.WhiteKnight;
            pictureBoxArray[6, 0].Image = Resources.WhiteKnight;
            pictureBoxArray[1, 7].Image = Resources.BlackKnight;
            pictureBoxArray[6, 7].Image = Resources.BlackKnight;

            pictureBoxArray[2, 0].Image = Resources.WhiteBishop;
            pictureBoxArray[5, 0].Image = Resources.WhiteBishop;
            pictureBoxArray[2, 7].Image = Resources.BlackBishop;
            pictureBoxArray[5, 7].Image = Resources.BlackBishop;

            pictureBoxArray[3, 0].Image = Resources.WhiteQueen;
            pictureBoxArray[3, 7].Image = Resources.BlackQueen;

            pictureBoxArray[4, 0].Image = Resources.WhiteKing;
            pictureBoxArray[4, 7].Image = Resources.BlackKing;

            for (int i = 0; i < 8; i++)
            {
                pictureBoxArray[i, 1].Image = Resources.WhitePawn;
                pictureBoxArray[i, 6].Image = Resources.BlackPawn;
            }
        }
    }
}

