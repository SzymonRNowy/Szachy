using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public class NoPiece : PieceAbstract
    {
        public NoPiece(int pos_x, int pos_y, string color) : base(pos_x, pos_y, color)
        {
            this.type = "NoPiece";
            this.attacklist = new List<Tuple<int, int>>();
        }

        public override bool piece_move_conditions(int to_pos_x, int to_pos_y)
        {
            return false;
        }
        public override List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y)
        {
            List<Tuple<int, int>> empty = new List<Tuple<int, int>>();
            return empty;
        }
    }

}
