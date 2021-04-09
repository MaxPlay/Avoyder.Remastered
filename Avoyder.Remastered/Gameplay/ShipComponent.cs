using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Avoyder.Remastered.Gameplay
{
    public class ShipComponent
    {
        public class Configuration
        {
            public List<Rectangle> Collision;
            public Dictionary<int, string> Textures;
            public Point Position;
            public int Health;
        }

        private readonly SpriteBatch spriteBatch;
        private readonly IAssetService assetService;

        public ShipComponent()
        {
            spriteBatch = GameCore.GameServices.GetService<SpriteBatch>();
            assetService = GameCore.GameServices.GetService<IAssetService>();
        }

        public List<Rectangle> Collision { get; }

        /// <summary>
        /// Textures by damage state with 0 being undamaged
        /// </summary>
        public Dictionary<int, Texture2D> Textures { get; }

        public Point Position { get; }

        public int Health { get; set; }

        public int DamageFrame => Math.Max(0, 2 - Health / 20);

        public void TakeDamage(int damage)
        {
            Health = Math.Max(0, Health - damage);
        }

        public void Heal(int healAmount)
        {
            Health = Math.Min(Health + healAmount, 50);
        }

        public void Draw(Vector2 location)
        {
            if (!Textures.TryGetValue(DamageFrame, out Texture2D texture))
                texture = Textures.Last().Value;

            spriteBatch.Draw(texture, location + Position.ToVector2(), Color.White);
        }

        public void Load()
        {

        }
    }
}