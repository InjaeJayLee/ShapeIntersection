namespace ShapeIntersection
{
    struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    abstract class Shape
    {
        public int id;
        public Vector2 centrePos;

        public abstract bool IsOverlapped(Shape other);
    }
}
