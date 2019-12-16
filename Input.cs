using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MGVarolloUtils
{
    /// <summary>
    /// Utility class for input management
    /// </summary>
    public static class Input
    {
        private static List<Button> inputButtons = new List<Button>();
        
        /// <summary>
        /// Saves a button
        /// </summary>
        /// <param name="name">Name of the button</param>
        /// <param name="key">Key asigned to the button</param>
        public static void CreateButton(string name, Keys key = Keys.None)
        {
            Button btn = new Button();
            btn.key = key;
            btn.name = name;
            btn.previousState = false;

            inputButtons.Add(btn);
        }

        /// <summary>
        /// Removes a saved button
        /// </summary>
        /// <param name="name">The name of the button</param>
        public static void RemoveButton(string name)
        {
            inputButtons.Remove(getButton(name));
        }

        /// <summary>
        /// Checks if the button is pressed
        /// in the current frame
        /// </summary>
        /// <param name="name">The name of the button</param>
        /// <returns>
        /// Returns true if the button is pressed this frame
        /// </returns>
        public static bool OnButtonDown(string name)
        {
            Button btn = getButton(name);
            if (btn == null) return false;

            bool currentState = Keyboard.GetState().IsKeyDown(btn.key);
            if(currentState != btn.previousState && currentState == true)
            {
                btn.previousState = currentState;
                return true;
            }
            else
            {
                btn.previousState = currentState;
                return false;
            }
        }

        /// <summary>
        /// Checks if the button is released
        /// in the current frame
        /// </summary>
        /// <param name="name">The name of the button</param>
        /// <returns>
        /// Returns true if the button is released this frame
        /// </returns>
        public static bool OnButtonUp(string name)
        {
            Button btn = getButton(name);
            if (btn == null) return false;

            bool currentState = Keyboard.GetState().IsKeyDown(btn.key);
            if (currentState != btn.previousState && currentState == false)
            {
                btn.previousState = currentState;
                return true;
            }
            else
            {
                btn.previousState = currentState;
                return false;
            }
        }

        /// <summary>
        /// Checks if the button is being pressed
        /// </summary>
        /// <param name="name">The name of the button</param>
        /// <returns>
        /// Returns true if the button is being pressed
        /// </returns>
        public static bool IsButtonDown(string name)
        {
            Button btn = getButton(name);
            if (btn == null) return false;

            bool state = Keyboard.GetState().IsKeyDown(btn.key);
            btn.previousState = state;
            return state;
        }
        private static bool IsButtonDown(Button btn)
        {
            bool state = Keyboard.GetState().IsKeyDown(btn.key);
            btn.previousState = state;
            return state;
        }

        /// <summary>
        /// Checks if the button is not being pressed
        /// </summary>
        /// <param name="name">The name of the button</param>
        /// <returns>
        /// Returns true if the button is not being pressed
        /// </returns>
        public static bool isButtonUp(string name)
        {
            Button btn = getButton(name);
            if (btn == null) return false;

            bool state = Keyboard.GetState().IsKeyUp(btn.key);
            btn.previousState = state;
            return state;
        }
        private static bool isButtonUp(Button btn)
        {
            bool state = Keyboard.GetState().IsKeyUp(btn.key);
            btn.previousState = state;
            return state;
        }

        private static Button getButton(string name)
        {
            return Array.Find(inputButtons.ToArray(), b => b.name == name);
        }
    }

    public class Button
    {
        public string name;
        public Keys key;

        public bool previousState;
    }
}
