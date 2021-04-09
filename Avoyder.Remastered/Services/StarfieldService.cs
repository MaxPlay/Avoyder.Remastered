using Avoyder.Remastered.Procedural;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Avoyder.Remastered.Services
{
    public class StarfieldService
    {
        private readonly IAssetService assetService;
        private Effect starfieldEffect;
        private IMesh<VertexPositionColor> starfieldMesh;
        private List<Texture2D> planets;

        public StarfieldService()
        {
            assetService = GameCore.GameServices.GetService<IAssetService>();
            var graphicsDeviceManager = GameCore.GameServices.GetService<GraphicsDeviceManager>();
            starfieldMesh = GenerateMesh(graphicsDeviceManager.PreferredBackBufferWidth, graphicsDeviceManager.PreferredBackBufferHeight, new Color(10, 10, 255));
        }

        private IMesh<VertexPositionColor> GenerateMesh(int preferredBackBufferWidth, int preferredBackBufferHeight, Color color)
        {
            Mesh<VertexPositionColor> mesh = new Mesh<VertexPositionColor>();
            mesh.AddVertex(new VertexPositionColor() { Color = color, Position = new Vector3(0, 0, 0) });
            mesh.AddVertex(new VertexPositionColor() { Color = color, Position = new Vector3(preferredBackBufferWidth, 0, 0) });
            mesh.AddVertex(new VertexPositionColor() { Color = color, Position = new Vector3(0, preferredBackBufferHeight, 0) });
            mesh.AddVertex(new VertexPositionColor() { Color = color, Position = new Vector3(preferredBackBufferWidth, preferredBackBufferHeight, 0) });
            mesh.AddQuad(0, 1, 2, 3);
            return mesh;
        }

        public void Draw()
        {
            // TODO(ms): Draw mesh here using the effect
        }
    }
}
