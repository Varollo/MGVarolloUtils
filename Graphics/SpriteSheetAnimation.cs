using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGVarolloUtils.Graphics
{
    public class SpriteSheetAnimation
    {
        public readonly Texture2D texture;
        public readonly int totalFrames;
        public readonly int frameWidth;
        public readonly int frameHeight;
        public readonly Vector2 padding;

        public int currentFrameIndex;

        public Rectangle currentFrameRect() => new Rectangle(currentFrameIndex * frameWidth + (currentFrameIndex + 1) * (int)padding.X,
            currentFrameIndex * frameHeight + (currentFrameIndex + 1) * (int)padding.X, frameWidth, frameHeight);
    }
}
