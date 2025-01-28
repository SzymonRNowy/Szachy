using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    //queen TODO
    public class Queen : PieceAbstract
    {
        public Queen(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "Queen";
            this.attacklist = new List<Tuple<int, int>>();
        }
        public  bool bishop_move_conditions(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (Math.Abs(x_difference) == Math.Abs(y_difference)) return true;
            else return false;

        }

        public  bool rook_move_conditions(int to_pos_x, int to_pos_y)
        {
            int x_difference = Math.Abs(this.pos_x - to_pos_x);
            int y_difference = Math.Abs(this.pos_y - to_pos_y);

            if ((x_difference != 0 && y_difference == 0) ^ (x_difference == 0 && y_difference != 0)) return true;
            else return false;

        }
        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (this.rook_move_conditions(to_pos_x, to_pos_y) || this.bishop_move_conditions(to_pos_x, to_pos_y)) return true;
            else return false;


        }
        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;
            List<Tuple<int, int>> coord_list = new List<Tuple<int, int>>();

            if (this.bishop_move_conditions(to_pos_x, to_pos_y))
            {
                if (x_difference > 0 && y_difference > 0)
                {
                    for (int i = 1; i < Math.Abs(x_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + i, this.pos_y + i);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference < 0 && y_difference < 0)
                {
                    for (int i = 1; i < Math.Abs(x_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x - i, this.pos_y - i);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference > 0 && y_difference < 0)
                {
                    for (int i = 1; i < Math.Abs(x_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + i, this.pos_y - i);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference < 0 && y_difference > 0)
                {
                    for (int i = 1; i < Math.Abs(x_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x - i, this.pos_y + i);
                        coord_list.Add(coordinate);
                    }
                }
            }
            else if (this.rook_move_conditions(to_pos_x, to_pos_y))
            {
                if (x_difference == 0 && y_difference > 0)
                {
                    for (int x = 0; x < Math.Abs(y_difference) - 1; x++)
                    {
                        var coordinate = Tuple.Create(this.pos_x, this.pos_y+x+1);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference == 0 && y_difference < 0)
                {
                    for (int x = 0; x < Math.Abs(y_difference) - 1; x++)
                    {
                        var coordinate = Tuple.Create(this.pos_x, this.pos_y - x - 1);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference > 0 && y_difference == 0)
                {
                    for (int x = 0; x < Math.Abs(x_difference) - 1; x++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + x + 1, this.pos_y);
                        coord_list.Add(coordinate);
                    }
                }
                if (x_difference < 0 && y_difference == 0)
                {
                    for (int x = 0; x < Math.Abs(x_difference) - 1; x++)
                    {
                        var coordinate = Tuple.Create(this.pos_x - x - 1, this.pos_y);
                        coord_list.Add(coordinate);

                    }
                }
            }
            return coord_list;
        }
    }  
}

