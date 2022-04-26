using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;
namespace Snake
{
    class Input             //This class reads the users keyboard input. Somehow.
    {
        private static Hashtable keyTable = new Hashtable();        //This is supposed to be the most efficient way to do this. Problem is i dont really understand how it works.
        public static bool KeyPress (Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }
        public static void ChangeState(Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}
