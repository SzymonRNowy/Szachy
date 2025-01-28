using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieceClassesLib
{
    public abstract class PieceAbstract
    {
        public int pos_x { get; set; } = 0;
        public int pos_y { get; set; } = 0;
        public string color { get; set; } = "No color";
        public string type { get; set; } = "NoPiece";
        public List<Tuple<int, int>> attacklist { get; set; } = new List<Tuple<int, int>>();


        protected PieceAbstract(int posx, int posy, string color)
        {
            this.pos_x = posx;
            this.pos_y = posy;
            this.color = color;
        }
        public abstract bool piece_move_conditions(int to_pos_x, int to_pos_y);
        public abstract List<Tuple<int, int>> squares_coordinates_on_move_path(int to_pos_x, int to_pos_y);

        public void add_to_attack_list(int to_pos_x, int to_pos_y)
        {

            Tuple<int,int> position = Tuple.Create(to_pos_x, to_pos_y);
            this.attacklist.Add(position);

        }

    }

}