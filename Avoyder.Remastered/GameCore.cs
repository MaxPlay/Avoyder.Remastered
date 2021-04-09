using Avoyder.Remastered.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Avoyder.Remastered
{
    public class GameCore : Game
    {
        public static GameServiceContainer GameServices { get; private set; }

        public GameCore()
        {
            GameServices = Services;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Services.AddService(Content);
            Services.AddService<IAssetService>(new AssetService(Content));
            Services.AddService(new GraphicsDeviceManager(this));
            Services.AddService(new InputService());
        }

        protected override void Initialize()
        {
            Services.AddService(new SpriteBatch(GraphicsDevice));
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            Services.GetService<InputService>().Update();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
