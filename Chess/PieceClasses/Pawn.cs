using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public class Pawn : PieceAbstract
    {
        public Pawn(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "Pawn";
            this.attacklist = new List<Tuple<int, int>>();
            
        }

        //ruch w przod - tylko jesli  board[to_x, to_y].piece.type == "NoPiece"
        //ruch skos - tylko jeśli board[to_x, to_y].piece.color == enemy_color()
        public bool is_moving_forward(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;
            if (x_difference == 0)
            {
                //ruchy o 2 pola na 1 ruchu pionka, wyjatek
                if (this.pos_y == 1 && this.color == "white" && (y_difference == 2 || y_difference == 1)) return true;
                else if (this.pos_y == 6 && this.color == "black" && (y_difference == -2 || y_difference == -1)) return true;
                //normalne ruchy
                else if (this.color == "white" && y_difference == 1) return true;
                else if (this.color == "black" && y_difference == -1) return true;
            }
            return false;
        }
        public bool is_moving_diagonally(int to_pos_x, int to_pos_y)
        {          
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (Math.Abs(x_difference) == 1)
            {
                if (this.color == "white" && y_difference == 1) return true;
                else  if (this.color == "black" && y_difference == -1) return true;
                return false;
            }
            else return false;
        }
        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {
            if (is_moving_diagonally(to_pos_x, to_pos_y) || is_moving_forward(to_pos_x, to_pos_y)) return true;
            return false;
        }

        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
            if (Math.Abs(to_pos_y - this.pos_y) < 2) {return coordinates;}
            else
            {
                int y_difference = to_pos_y - this.pos_y;

                if (piece_move_conditions(to_pos_x, to_pos_y))
                {
                    if ((this.color == "white") && (y_difference == 2))
                    {
                        var coordinate = Tuple.Create(this.pos_x,this.pos_y + 1);
                        coordinates.Add(coordinate);
                    }
                    else if ((this.color == "black") && (y_difference == -2))
                    {
                        var coordinate = Tuple.Create(this.pos_x, this.pos_y - 1);
                        coordinates.Add(coordinate);
                    }
                }
            }
            return coordinates;
        }
    }
}