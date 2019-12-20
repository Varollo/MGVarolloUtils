using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGVarolloUtils
{
    public class Transform
    {
        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        public Transform()
        {
            position = new Vector2(0f, 0f);
            rotation = 0f;
            scale = new Vector2(1f, 1f);
        }

        public Transform(Vector2 position, float rotation, Vector2 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }
    }
}
