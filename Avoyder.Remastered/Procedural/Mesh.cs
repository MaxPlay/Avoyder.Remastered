using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avoyder.Remastered.Procedural
{
    public class Mesh<TVertex> : IMesh<TVertex> where TVertex : IVertexType
    {
        public List<TVertex> Vertices { get; } = new List<TVertex>();

        public List<int> Triangles { get; } = new List<int>();

        IReadOnlyList<TVertex> IMesh<TVertex>.Vertices => Vertices;

        IReadOnlyList<int> IMesh<TVertex>.Triangles => Triangles;

        public void AddVertex(TVertex vertex) => Vertices.Add(vertex);

        public void AddTriangle(int a, int b, int c)
        {
            Triangles.Add(a);
            Triangles.Add(b);
            Triangles.Add(c);
        }

        public void AddQuad(int a, int b, int c, int d)
        {
            AddTriangle(a, b, c);
            AddTriangle(b, d, c);
        }

        public void FinalizeMesh()
        {
            Vertices.TrimExcess();
            Triangles.TrimExcess();
        }
    }
}
