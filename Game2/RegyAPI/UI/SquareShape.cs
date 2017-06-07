using System; 
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class SquareShape : Shapes
    {
       
        public SquareShape(int _x, int _y, int _height, int _width, Color _col) : base(_x, _y, _height, _width, _col)
        {
            height = _height;
            width = _width;
            x = _x;
            y = _y;
            color = _col;
            texture = new Texture2D(GameServices.GetService<GraphicsDevice>(), width, height);
            createShape();
        }

        public override void createShape()
        {
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                //the function applies the color according to the specified pixel
                data[pixel] = color;
            }

            //set the color
            texture.SetData(data);
        }
        
    }
}
