using Avoyder.Remastered.Services;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Avoyder.Remastered.Gameplay
{
    public class Player
    {
        private readonly InputService inputService;

        public List<ShipComponent> Components { get; }

        public List<ShipWeapon> Weapons { get; }

        public Player()
        {
            inputService = GameCore.GameServices.GetService<InputService>();
        }

        public void Update(GameTime gameTime)
        {

        }
    }
}
