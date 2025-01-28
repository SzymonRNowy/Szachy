using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public class Bishop : PieceAbstract
    {
        public Bishop(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "Bishop";
            this.attacklist = new List<Tuple<int, int>>();
        }
        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (Math.Abs(x_difference) == Math.Abs(y_difference)) return true;
            else return false;

        }

        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            List<Tuple<int, int>> coordinates = new List<Tuple<int, int>>();
            int x_difference = to_pos_x - this.pos_x;
            int y_difference = to_pos_y - this.pos_y;

            if (piece_move_conditions(to_pos_x, to_pos_y))
            {

                if (x_difference > 0 && y_difference > 0)
                {
                    for (int i = 0; i < Math.Abs(x_difference) - 1; i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + i + 1, this.pos_y + i + 1);
                        coordinates.Add(coordinate);
                    }
                }
                if (x_difference < 0 && y_difference < 0)
                {
                    for (int i = 0; i < Math.Abs(x_difference) - 1; i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x - i - 1, this.pos_y - i - 1);
                        coordinates.Add(coordinate);
                    }
                }
                if (x_difference > 0 && y_difference < 0)
                {
                    for (int i = 0; i < Math.Abs(x_difference) - 1; i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x + i + 1, this.pos_y - i - 1);
                        coordinates.Add(coordinate);
                    }
                }
                if (x_difference < 0 && y_difference > 0)
                {
                    for (int i = 0; i < Math.Abs(x_difference) - 1; i++)
                    {
                        var coordinate = Tuple.Create(this.pos_x - i - 1, this.pos_y + i + 1);
                        coordinates.Add(coordinate);
                    }
                }
            }
            return coordinates;
        }

    }
}
