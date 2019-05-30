namespace ShapeIntersection
{
    class Rectangle : Shape
    {
        float halfWidth;
        public float HalfWidth { get => halfWidth; }

        float halfHeight;
        public float HalfHeight { get => halfHeight; }


        public Rectangle(int id, Vector2 centrePos, float width, float height)
        {
            this.id = id;
            this.centrePos = centrePos;
            halfWidth = width / 2.0f;
            halfHeight = height / 2.0f;
        }

        public override bool IsOverlapped(Shape other)
        {
            bool result = false;

            if (other is Circle)
            {
                Circle otherCircle = other as Circle;
                result = Util.CheckOverlapBetweenCircleAndRectangle(otherCircle, this);
            }
            else if (other is Rectangle)
            {
                Rectangle otherRect = other as Rectangle;
                result = Util.CheckOverlapBetweenRectangles(this, otherRect);
            }

            return result;
        }
    }
}
