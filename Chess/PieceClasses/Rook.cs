using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public class Rook : PieceAbstract
    {
        public Rook(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "Rook";
            this.attacklist = new List<Tuple<int, int>>();
        }

        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if ((x_difference != 0 && y_difference == 0) ^ (x_difference == 0 && y_difference != 0)) return true;
            else return false;
        }

        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (piece_move_conditions(to_pos_x, to_pos_y))
            {
                if (x_difference != 0)
                {
                    int xdiff_sign = x_difference > 0 ? 1 : x_difference < 0 ? -1 : 0;
                    for (int i = 1; i < Math.Abs(x_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + i * xdiff_sign, this.pos_y);
                        coordinates.Add(coordinate);
                    }

                }
                if (y_difference != 0)
                {
                    int ydiff_sign = y_difference > 0 ? 1 : y_difference < 0 ? -1 : 0;
                    for (int i = 1; i < Math.Abs(y_difference); i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x, this.pos_y + i * ydiff_sign);
                        coordinates.Add(coordinate);
                    }
                }
            }
            return coordinates;
        }
    }
}
