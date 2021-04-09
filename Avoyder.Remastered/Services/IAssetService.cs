using Avoyder.Remastered.Core;
using Microsoft.Xna.Framework.Graphics;

namespace Avoyder.Remastered
{
    public interface IAssetService
    {
        public Texture2D GetTexture(Name name);

        public Effect GetEffect(Name name);
    }
}