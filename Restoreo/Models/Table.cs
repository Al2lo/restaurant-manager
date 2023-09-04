using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoreo
{
    public class Table
    {
        public int id { get; set; }
        public int canvasLeft { get; set; }
        public int canvasTop { get; set; }
        public string pathImgFree { get; set; }
        public string pathImgNoFree { get; set; }
        public string pathImgSelect { get; set; }
        public int sizes { get; set; }
        public int places { get; set; }
        public bool vip { get; set; }
        public bool isEnter { get; set; }
        public bool isFree { get; set; }

        public Table(int id,int canvasLeft, int canvasTop, string pathImgFree, string pathImgNoFree, string pathImgSelect, int sizes, int places, string vip,bool isEnter = false, bool isFree = true)
        {
            this.id = id;
            this.canvasLeft = canvasLeft;
            this.canvasTop = canvasTop;
            this.pathImgFree = pathImgFree;
            this.pathImgNoFree = pathImgNoFree;
            this.isEnter = isEnter;
            this.isFree = isFree;
            this.pathImgSelect = pathImgSelect;
            this.sizes = sizes;
            this.places = places;
            if (vip == "true") this.vip = true;
            else this.vip = false;
        }
        public Table()
        { }
    }
}
