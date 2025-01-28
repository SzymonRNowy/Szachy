using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public class Knight : PieceAbstract
    {
        public Knight(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "Knight";
            this.attacklist = new List<Tuple<int, int>>();
        }
        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {

            int x_difference = Math.Abs(this.pos_x - to_pos_x);
            int y_difference = Math.Abs(this.pos_y - to_pos_y);

            if ((x_difference == 2 && y_difference == 1) || (x_difference == 1 && y_difference == 2)) return true;
            else return false;
        }

        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            List<Tuple<int, int>> empty = new List<Tuple<int, int>>();
            return empty;
        }
    }
}
