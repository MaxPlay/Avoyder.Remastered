using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Avoyder.Remastered.Services
{
    public class InputService
    {
        private class InputDevice<T>
        {
            public T Current;
            public T Last;

            public void Update(T newCurrent)
            {
                Last = Current;
                Current = newCurrent;
            }
        }

        private readonly InputDevice<KeyboardState> keyboard = new InputDevice<KeyboardState>();
        private readonly InputDevice<MouseState> mouse = new InputDevice<MouseState>();
        private readonly Dictionary<int, InputDevice<GamePadState>> gamepads = new Dictionary<int, InputDevice<GamePadState>>();

        public void Update()
        {
            keyboard.Update(Keyboard.GetState());
            mouse.Update(Mouse.GetState());
            for (int i = 0; i < GamePad.MaximumGamePadCount; i++)
            {
                GamePadState gamePadState = GamePad.GetState(i);
                if (gamePadState.IsConnected)
                {
                    if (!gamepads.ContainsKey(i))
                        gamepads[i] = new InputDevice<GamePadState>();
                    gamepads[i].Update(gamePadState);
                }
                else
                {
                    gamepads.Remove(i);
                }
            }
        }
    }
}
