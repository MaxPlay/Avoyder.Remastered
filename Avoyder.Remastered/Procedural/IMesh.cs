using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Avoyder.Remastered.Procedural
{
    public interface IMesh<TVertex> where TVertex : IVertexType
    {
        public IReadOnlyList<TVertex> Vertices { get; }

        public IReadOnlyList<int> Triangles { get; }
    }
}