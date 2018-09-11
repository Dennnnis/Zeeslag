using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zeeslag
{
    public enum ShipCode
    {
        Vliegdekschip = 1,
        Slagschip,
        Torpedobootjager,
        Patrouilleschip
    }

    public enum Section
    {
        Front = 0,
        Middle,
        Back
    }

    public class Cell
    {
        //TODO change bool(s) to int and use bitwise operators

        public bool isSelection = false;
        public bool isShip = false;
        public ShipCode shipCode;
        public int number;
        public bool right;

        //For enemy grid
        public bool missed = false;
        public bool hit = false;

        //Don't send
        public bool hidden = false;

        public static int GetLength(ShipCode c)
        {
            switch (c)
            {
                case ShipCode.Vliegdekschip: return 5;
                case ShipCode.Slagschip: return 4;
                case ShipCode.Torpedobootjager: return 3;
                case ShipCode.Patrouilleschip: return 2;
            }
            throw new Exception("Unknown ship");
        }

        public static string GetName(ShipCode t)
        {
            switch (t)
            {
                case ShipCode.Vliegdekschip: return "Vliegdekschip";
                case ShipCode.Torpedobootjager: return "Torpedobootjager";
                case ShipCode.Slagschip: return "Slagschip";
                case ShipCode.Patrouilleschip:  return "Patrouilleschip";
            }
            return "Unknown name";
        }

        public Bitmap GetBitmap(Section s)
        {
            Bitmap fixImage(Bitmap img)
            {
                if (!right) img = (Bitmap)Global.RotateImage(img, 90);
                return img;
            }

            switch(shipCode)
            {
                case ShipCode.Vliegdekschip:

                    switch(s)
                    {
                        case Section.Front:  return fixImage(Properties.Resources.ShipVF);
                        case Section.Middle: return fixImage(Properties.Resources.ShipVC);
                        case Section.Back:   return fixImage(Properties.Resources.ShipVB);
                        default: return null;
                    }
                case ShipCode.Slagschip:

                    switch (s)
                    {
                        case Section.Front: return fixImage(Properties.Resources.ShipSF);
                        case Section.Middle: return fixImage(Properties.Resources.ShipSC);
                        case Section.Back: return fixImage(Properties.Resources.ShipSB);
                        default: return null;
                    }
                case ShipCode.Torpedobootjager:

                    switch (s)
                    {
                        case Section.Front: return fixImage(Properties.Resources.ShipTF);
                        case Section.Middle: return fixImage(Properties.Resources.ShipTC);
                        case Section.Back: return fixImage(Properties.Resources.ShipTB);
                        default: return null;
                    }
                case ShipCode.Patrouilleschip:

                    switch (s)
                    {
                        case Section.Front: return fixImage(Properties.Resources.ShipPF);
                        case Section.Back: return fixImage(Properties.Resources.ShipPB);
                        default: return null;
                    }
            }
            return null;
        }
    }
}
