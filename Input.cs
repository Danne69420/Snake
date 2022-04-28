using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;
namespace Snake
{
    class Input             //This class reads the users keyboard input.
    {
        private static Hashtable keyTable = new Hashtable();        //A hashtable is a table of codes which each have a corresponding value
        public static bool KeyPress (Keys key)          //In this case the hashtable uses the codes for the keys on the keyboard
        {
            if (keyTable[key] == null)          //This is a failsafe. In case the method recieves a key that does not have a value it simply returns false. 
            {
                return false;
            }
            return (bool)keyTable[key];             //This return wether the keys value is true or false, pressed or not. 
        }
        public static void ChangeState(Keys key, bool state)        //This changes the hashtable values whenever a key is pressed. 
        {
            keyTable[key] = state;
        }
    }
}
