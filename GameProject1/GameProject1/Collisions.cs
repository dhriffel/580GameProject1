using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject1
{
    public static class Collisions
    {
        public static bool CollidesWith(this BoundingRectangle a, BoundingRectangle b)
        {
            return !(a.X + a.Width <= b.X    // a is to the left of b
                || a.X >= b.X + b.Width     // a is to the right of b
                || a.Y + a.Height <= b.Y    // a is above b
                || a.Y >= b.X + b.Height);   // a is below b
        }
        public static bool TouchingLeft(this BoundingRectangle a, BoundingRectangle b)
        {
            return a.X + a.Width >= b.X &&
                a.X < b.X &&
                a.Y + a.Height > b.Y &&
                a.Y < b.Y + b.Height;
        }
        public static bool TouchingRight(this BoundingRectangle a, BoundingRectangle b)
        {
            return a.X <= b.X + b.Width &&
                a.X + a.Width > b.X + b.Width &&
                a.Y + a.Height > b.Y &&
                a.Y < b.Y + b.Height;
        }
        public static bool TouchingTop(this BoundingRectangle a, BoundingRectangle b)
        {
            return a.Y + a.Height >= b.Y &&
                a.Y < b.Y &&
                a.X + a.Width > b.X &&
                a.X < b.X + b.Width;
        }
        public static bool TouchingBottom(this BoundingRectangle a, BoundingRectangle b)
        {
            return a.Y <=  b.Y + b.Height &&
                a.Y + a.Height > b.Y + b.Height &&
                a.X + a.Width > b.X &&
                a.X < b.X + b.Width;
        }
    }
}
