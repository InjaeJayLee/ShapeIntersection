using System.Collections.Generic;
using System;

namespace ShapeIntersection
{
    class Util
    {
        // Calculate the square of distance between two points
        public static float CalculateSquareDistBetweenTwoPoints(Vector2 p1, Vector2 p2)
        {
            return CalculatePowerOf(p1.x - p2.x) + CalculatePowerOf(p1.y - p2.y);
        }

        // Calculate the power of a number
        public static float CalculatePowerOf(float num)
        {
            return num * num;
        }

        // Check if overlapping between two circles
        public static bool CheckOverlapBetweenCircles(Circle lhs, Circle rhs)
        {
            bool result = false;

            float squareDistance = CalculateSquareDistBetweenTwoPoints(lhs.centrePos, rhs.centrePos);
            float sqaureRadius = CalculatePowerOf(lhs.Radius + rhs.Radius);

            if (squareDistance <= sqaureRadius)
                result = true;

            return result;
        }

        // Check if overlapping between two rectangles
        public static bool CheckOverlapBetweenRectangles(Rectangle lhs, Rectangle rhs)
        {
            bool result = false;

            float lhsLeft = lhs.centrePos.x - lhs.HalfWidth;
            float lhsRight = lhs.centrePos.x + lhs.HalfWidth;
            float lhsBottom = lhs.centrePos.y - lhs.HalfHeight;
            float lhsTop = lhs.centrePos.y + lhs.HalfHeight;

            float rhsLeft = rhs.centrePos.x - rhs.HalfWidth;
            float rhsRight = rhs.centrePos.x + rhs.HalfWidth;
            float rhsBottom = rhs.centrePos.y - rhs.HalfHeight;
            float rhsTop = rhs.centrePos.y + rhs.HalfHeight;

            if (lhsLeft <= rhsRight && lhsRight >= rhsLeft && lhsBottom <= rhsTop && lhsTop >= rhsBottom)
                result = true;

            return result;
        }

        // Check if overlapping between a circle and a rectangle
        public static bool CheckOverlapBetweenCircleAndRectangle(Circle circle, Rectangle rect)
        {
            bool result = false;

            // each vertex of the rectangle
            Vector2 rectLeftTop = new Vector2(rect.centrePos.x - rect.HalfWidth, rect.centrePos.y + rect.HalfHeight);
            Vector2 rectLeftBottom = new Vector2(rect.centrePos.x - rect.HalfWidth, rect.centrePos.y - rect.HalfHeight);
            Vector2 rectRightTop = new Vector2(rect.centrePos.x + rect.HalfWidth, rect.centrePos.y + rect.HalfHeight);
            Vector2 rectRightBottom = new Vector2(rect.centrePos.x + rect.HalfWidth, rect.centrePos.y - rect.HalfHeight);

            // each square of distance betweem the centre point of the circle and each vertex of the rectangle
            float dist1 = CalculateSquareDistBetweenTwoPoints(circle.centrePos, rectLeftTop);
            float dist2 = CalculateSquareDistBetweenTwoPoints(circle.centrePos, rectLeftBottom);
            float dist3 = CalculateSquareDistBetweenTwoPoints(circle.centrePos, rectRightTop);
            float dist4 = CalculateSquareDistBetweenTwoPoints(circle.centrePos, rectRightBottom);

            // the square of the circle's radius
            float squareRadius = CalculatePowerOf(circle.Radius);

            // when the circle collides with any vertex of the rectangle
            if (dist1 <= squareRadius || dist2 <= squareRadius || dist3 <= squareRadius || dist4 <= squareRadius)
            {
                result = true;
            }
            // when the circle collides with any edge of the rectangle
            else
            {
                float rectLeft = rect.centrePos.x - rect.HalfWidth;
                float rectRight = rect.centrePos.x + rect.HalfWidth;
                float rectBottom = rect.centrePos.y - rect.HalfHeight;
                float rectTop = rect.centrePos.y + rect.HalfHeight;

                if ((circle.centrePos.x >= rectLeft && circle.centrePos.x <= rectRight)
                    || (circle.centrePos.y >= rectBottom && circle.centrePos.y <= rectTop))
                {
                    float extendedRectLeft = rectLeft - circle.Radius;
                    float extendedRectRight = rectRight + circle.Radius;
                    float extendedRectBottom = rectBottom - circle.Radius;
                    float extendedRectTop = rectTop + circle.Radius;

                    if (circle.centrePos.x <= extendedRectRight && circle.centrePos.x >= extendedRectLeft
                    && circle.centrePos.y <= extendedRectTop && circle.centrePos.y >= extendedRectBottom)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        // Find lists of overlapped shapes
        public static Dictionary<int, List<int>> FindIntersections(List<Shape> shapes)
        {
            // the number of shapes
            int numOfShapes = shapes.Count;

            // the dictionary result to return
            var intersectionResult = new Dictionary<int, List<int>>(numOfShapes);

            // add each unique shape ID
            for (int i = 0; i < numOfShapes; i++)
            {
                if (intersectionResult.ContainsKey(shapes[i].id))
                {
                    Console.WriteLine("The same ID already exists!");
                    intersectionResult.Clear();
                    return intersectionResult;
                }

                intersectionResult.Add(shapes[i].id, new List<int>());
            }

            // check collision
            for (int i = 0; i < numOfShapes; i++)
            {
                for (int j = i + 1; j < numOfShapes; j++)
                {
                    if (shapes[i].IsOverlapped(shapes[j]))
                    {
                        intersectionResult[shapes[i].id].Add(shapes[j].id);
                        intersectionResult[shapes[j].id].Add(shapes[i].id);
                    }
                }
            }

            return intersectionResult;
        }
    }
}
