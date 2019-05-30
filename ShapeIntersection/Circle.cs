namespace ShapeIntersection
{
    class Circle : Shape
    {
        float radius;
        public float Radius { get => radius; }


        public Circle(int id, float radius, Vector2 centrePos)
        {
            this.id = id;
            this.radius = radius;
            this.centrePos = centrePos;
        }

        public override bool IsOverlapped(Shape other)
        {
            bool result = false;

            if (other is Circle)
            {
                Circle otherCircle = other as Circle;
                result = Util.CheckOverlapBetweenCircles(this, otherCircle);
            }
            else if (other is Rectangle)
            {
                Rectangle otherRect = other as Rectangle;
                result = Util.CheckOverlapBetweenCircleAndRectangle(this, otherRect);
            }

            return result;
        }
    }
}
