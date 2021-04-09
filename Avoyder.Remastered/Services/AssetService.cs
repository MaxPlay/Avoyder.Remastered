using Avoyder.Remastered.Core;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avoyder.Remastered.Services
{
    public class AssetService : IAssetService
    {
        private readonly Dictionary<Name, Texture2D> textures = new Dictionary<Name, Texture2D>();
        private readonly Dictionary<Name, Effect> effects = new Dictionary<Name, Effect>();
        private readonly ContentManager contentManager;

        public AssetService(ContentManager contentManager)
        {
            this.contentManager = contentManager;
        }

        public Effect GetEffect(Name name)
        {
            if (!effects.TryGetValue(name, out Effect effect))
            {
                effect = contentManager.Load<Effect>(name);
                effects.Add(name, effect);
            }
            return effect;
        }

        public Texture2D GetTexture(Name name)
        {
            if (!textures.TryGetValue(name, out Texture2D texture))
            {
                texture = contentManager.Load<Texture2D>(name);
                textures.Add(name, texture);
            }
            return texture;
        }
    }
}
